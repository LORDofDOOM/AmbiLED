using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ScreenshotInterface;
//using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
//using System.Windows;
//using System.Windows.Interop;
using System.Xml;

// DX Hook
using EasyHook;

// DFMirage Driver
using MirrSharp.Driver; // Platform target --> x86


/*
Copyright 2011 Mariusz Grzybacz

This file is part of AmbiLEDd.

AmbiLEDd is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

AmbiLEDd is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

namespace AmbiLEDd
{

    public partial class AmbiLEDdForm : Form
    {
        private String ChannelName = null;
        private IpcServerChannel ScreenshotServer;

        public AmbiLEDdForm()
        {
            InitializeComponent();
        }

        Socket m_socClient;

        int swidth, sheight, _p_swidth, _p_sheight;
        // Global must be here!
        int _lb = 0, _le = 0, _rb = 0, _re = 0, _tb = 0, _te = 0;

        DateTime StartMeasureTime;
        DateTime EndMeasureTime;
        TimeSpan diffMeasure;
        TimeSpan SleepTime;

        int processId = 0;

        Process _process;

        Stopwatch timer = new Stopwatch();

        //readonly DesktopMirror _mirror = new DesktopMirror();
        DesktopMirror _mirror;

        private bool _capturing;
        private Image _finderHome;
        private Image _finderGone;
        private Cursor _cursorDefault;
        private Cursor _cursorFinder;
        private IntPtr _hPreviousWindow;


        //*/  DWM operations to perform DWM disable/enable
        public class DWM
        {
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableComposition(bool bEnable);
        }
        // */
        
        void _mirror_DesktopChange(object sender, DesktopMirror.DesktopChangeEventArgs e)
        {
            txtDebugLog.Text = String.Format("Changed rect is {0},{1} ; {2}, {3} ({4})\r\n{5}", e.x1, e.y1, e.x2, e.y2, e.type, txtDebugLog.Text);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            _cursorDefault = Cursor.Current;
            _cursorFinder = EmbeddedResources.LoadCursor(EmbeddedResources.Finder);
            _finderHome = EmbeddedResources.LoadImage(EmbeddedResources.FinderHome);
            _finderGone = EmbeddedResources.LoadImage(EmbeddedResources.FinderGone);

            _pictureBox.Image = _finderHome;

            EnumScreens();

            // Initialise the IPC server
            ScreenshotServer = RemoteHooking.IpcCreateServer<ScreenshotInterface.ScreenshotInterface>(
                ref ChannelName,
                WellKnownObjectMode.Singleton);

            ScreenshotManager.OnScreenshotDebugMessage += new ScreenshotDebugMessage(ScreenshotManager_OnScreenshotDebugMessage);

            XmlDocument settings = new XmlDataDocument();
            settings.Load(Application.StartupPath + "\\AmbiLEDd.xml");
            XmlElement root = settings.DocumentElement;
            for (int I = 0; I < root.ChildNodes.Count; I++)
            {
                if (root.ChildNodes[I].Name == "minimized")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }

                else if (root.ChildNodes[I].Name == "LeftScanBegin")
                    LeftBegin.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "LeftScanEnd")
                    LeftEnd.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "TopScanBegin")
                    TopBegin.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "TopScanEnd")
                    TopEnd.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RightScanBegin")
                    RightBegin.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RightScanEnd")
                    RightEnd.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "Interval")
                {
                    global.var_Interval = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    TimerDelay.Value = global.var_Interval;
                    //CaptureTimer.Interval = global.var_Interval;
                }
                else if (root.ChildNodes[I].Name == "ReduceLevel")
                {
                    ReduceLevel.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    global.var_ReduceToWidth = (int)ReduceLevel.Value;
                }
                else if (root.ChildNodes[I].Name == "AutoEnable")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        AutoEnable.Checked = true;
                        EnableBtn.Enabled = false;
                    }
                    else
                    {
                        AutoEnable.Checked = false;
                    }
                }
                else if (root.ChildNodes[I].Name == "DisableDWM")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        global.DisableDWM = true;
                        cbDisableDWM.Checked = true;
                    }
                    else
                    {
                        global.DisableDWM = false;
                        cbDisableDWM.Checked = false;
                    }
                }
                else if (root.ChildNodes[I].Name == "ProcessName")
                {
                    ProcessName.Text = root.ChildNodes[I].InnerText;
                }
                else if (root.ChildNodes[I].Name == "VertexProcessing")
                {
                    global.var_VertexMode = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    if (global.var_VertexMode == 0)
                    {
                        lbVertexProcessing.Text = "HardwareVertex";
                    }
                    else if (global.var_VertexMode == 1)
                    {
                        lbVertexProcessing.Text = "SoftwareVertex";
                    }
                    else if (global.var_VertexMode == 2)
                    {
                        lbVertexProcessing.Text = "PureDevice";
                    }
                }
                else if (root.ChildNodes[I].Name == "Display")
                {
                    if (Convert.ToInt32(root.ChildNodes[I].InnerText, 10) <= global.NrDisplays)
                    {
                        global.SelectedDisplay = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                        lbDisplays.SelectedIndex = global.SelectedDisplay;
                    }
                    else
                    {
                        global.SelectedDisplay = 0;
                        lbDisplays.SelectedIndex = 0;
                    }
                }

            }

            if (UacHelper.IsProcessElevated)
            {
                label5.ForeColor = Color.DarkGreen;
                label5.Text = "OK";
            }
            else
            {
                RegisterGAC.Checked = false;
                RegisterGAC.Enabled = false;
                label5.ForeColor = Color.DarkRed;
                label5.Text = "Nope... Direct3DHook-ScreenInject cannot be registred.";
            }

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisableWorkingUnit();

            bool close = true;
            this.TopMost = false;

            /* // exit dialog
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "AmbiLEDd", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    close = true;
                }
            }
            else
            {
                close = true;
            }
            // */

            if (close)
            {
                XmlDocument settings = new XmlDataDocument();

                settings.Load(Application.StartupPath + "\\AmbiLEDd.xml");
                XmlElement root = settings.DocumentElement;
                for (int I = 0; I < root.ChildNodes.Count; I++)
                {
                    if (root.ChildNodes[I].Name == "enabled")
                    {
                        if (global.Enabled == true)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "minimized")
                    {
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    }

                    else if (root.ChildNodes[I].Name == "LeftScanBegin")
                        root.ChildNodes[I].InnerText = LeftBegin.Value.ToString();
                    else if (root.ChildNodes[I].Name == "LeftScanEnd")
                        root.ChildNodes[I].InnerText = LeftEnd.Value.ToString();
                    else if (root.ChildNodes[I].Name == "TopScanBegin")
                        root.ChildNodes[I].InnerText = TopBegin.Value.ToString();
                    else if (root.ChildNodes[I].Name == "TopScanEnd")
                        root.ChildNodes[I].InnerText = TopEnd.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RightScanBegin")
                        root.ChildNodes[I].InnerText = RightBegin.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RightScanEnd")
                        root.ChildNodes[I].InnerText = RightEnd.Value.ToString();
                    else if (root.ChildNodes[I].Name == "Interval")
                        root.ChildNodes[I].InnerText = global.var_Interval.ToString();
                    else if (root.ChildNodes[I].Name == "ReduceLevel")
                        root.ChildNodes[I].InnerText = global.var_ReduceToWidth.ToString();
                    else if (root.ChildNodes[I].Name == "AutoEnable")
                    {
                        if (AutoEnable.Checked == true)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "DisableDWM")
                    {
                        if (global.DisableDWM == true)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "ProcessName")
                    {
                        root.ChildNodes[I].InnerText = ProcessName.Text;
                    }
                    else if (root.ChildNodes[I].Name == "VertexProcessing")
                    {
                        root.ChildNodes[I].InnerText = global.var_VertexMode.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "Display")
                        root.ChildNodes[I].InnerText = global.SelectedDisplay.ToString();
                }
                settings.Save(Application.StartupPath + "\\AmbiLEDd.xml");

            }
            else
            {
                e.Cancel = true;
                this.TopMost = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnableBtn_Click(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void SendData() //send out the colors
        {
            string colourData;
            bool failed = false;
            colourData = "#" + BitConverter.ToString(global.SendByte).Replace("-", string.Empty) + "$";

            if (global._connected)
                try
                {
                    Object objData = colourData;
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                    m_socClient.Send(byData);
                }
                catch (SocketException se)
                {
                    if (global._net_socket_debug) MessageBox.Show(se.Message);
                    failed = true;
                    //CloseConnection();
                }
            if (failed)
            {
                CloseConnection();
                OpenConnection();
            }
        }

        /* // Do we really need this?
        private void SendQuit() //send out the colors
        {
            string sendText = "#clnt_dis$";

            if (global._connected)
            {
                try
                {
                    Object objData = sendText;
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                    m_socClient.Send(byData);
                }
                catch (SocketException se)
                {
                    if (global._net_socket_debug) MessageBox.Show(se.Message);
                    global._connected = false;
                    CloseConnection();
                }
            }
        }
        // */

        private void EnumScreens()
        {
            Screen[] screens = Screen.AllScreens;
            int upperBound = screens.GetUpperBound(0);
            global.NrDisplays = upperBound;

            for (int I = 0; I <= upperBound; I++)
            {
                lbDisplays.Items.Add(I.ToString() + ": (" + Screen.AllScreens[I].Bounds.Width + "x" + Screen.AllScreens[I].Bounds.Height + ")");
            }
        }

        private void CloseConnection()
        {
            //SendQuit();
            try
            {
                m_socClient.Close();
            }
            catch (SocketException se)
            {
                if (global._net_socket_debug) MessageBox.Show(se.Message);
            }
            global._connected = false;
        }

        private void OpenConnection()
        {
			try
			{
				//create a new client socket ...
				m_socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                String szIPSelected = "127.0.0.1";
                String szPort = "32890";
                int alPort = System.Convert.ToInt32(szPort, 10);
			
				System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
				System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
				m_socClient.Connect(remoteEndPoint);
				//String szData  = "Hello There";
				//byte[] byData = System.Text.Encoding.ASCII.GetBytes(szData);
				//m_socClient.Send(byData);
                global._connected = true;
			}
			catch (SocketException se)
			{
                global._connected = false;
				if (global._net_socket_debug) MessageBox.Show ( se.Message );
			}
  		}

        void GrabColors(Bitmap bitmap)
        {
            int redL = 0, greenL = 0, blueL = 0;
            int redR = 0, greenR = 0, blueR = 0;
            int redT = 0, greenT = 0, blueT = 0;
            int CounterL = 0, CounterR = 0, CounterT = 0;
            bool read = false;

            Color c = Color.Black;

            FastBitmap b = new FastBitmap(bitmap);
            b.LockImage();

            swidth = bitmap.Width;
            sheight = bitmap.Height;

            if (swidth != _p_swidth || sheight != _p_sheight)
            {
                _p_swidth = swidth;
                _p_sheight = sheight;
                _lb = swidth * (int)LeftBegin.Value / 100;
                _le = swidth * (int)LeftEnd.Value / 100;
                _rb = swidth * (int)RightBegin.Value / 100;
                _re = swidth * (int)RightEnd.Value / 100;
                _tb = sheight * (int)TopBegin.Value / 100;
                _te = sheight * (int)TopEnd.Value / 100;
            }

            for (int PixelY = 1; PixelY < sheight; PixelY += 1)
            {
                for (int PixelX = 1; PixelX < swidth; PixelX += 1)
                {
                    read = false;

                    if (PixelX >= _lb && PixelX <= _le)
                    {
                        if (read == false)
                        {
                            c = b.GetPixel(PixelX, PixelY);
                            read = true;
                        }
                        redL += c.R;
                        greenL += c.G;
                        blueL += c.B;
                        CounterL++;
                    }
                    if (PixelX >= _rb && PixelX <= _re)
                    {
                        if (read == false)
                        {
                            c = b.GetPixel(PixelX, PixelY);
                            read = true;
                        }
                        redR += c.R;
                        greenR += c.G;
                        blueR += c.B;
                        CounterR++;
                    }
                    if (PixelY >= _tb && PixelY <= _te)
                    {
                        if (read == false)
                        {
                            c = b.GetPixel(PixelX, PixelY);
                            read = true;
                        }
                        redT += c.R;
                        greenT += c.G;
                        blueT += c.B;
                        CounterT++;
                    }

                }
            }

            b.UnlockImage();

            //Dispose causes error while updating picturebox
            //bitmap.Dispose();

            if ((this.WindowState != FormWindowState.Minimized) && (ShowDebugDiag.Checked))
            {
                //label36.Text = MyScreen.Bounds.Width + "x" + MyScreen.Bounds.Height + " (" + MyScreen.Bounds.Left + ", " + MyScreen.Bounds.Top + ")";
                ShowPreview.Invoke(new MethodInvoker(delegate() { ShowPreview.Text = swidth.ToString() + "x" + sheight.ToString(); } ));
                label80.Invoke(new MethodInvoker(delegate() { label80.Text = CounterL.ToString(); } ));
                label77.Invoke(new MethodInvoker(delegate() { label77.Text = CounterR.ToString(); } ));
                label82.Invoke(new MethodInvoker(delegate() { label82.Text = CounterT.ToString(); } ));
            }
            if (CounterL > 0)
            {
                redL /= CounterL;
                greenL /= CounterL;
                blueL /= CounterL;
            }
            if (CounterR > 0)
            {
                redR /= CounterR;
                greenR /= CounterR;
                blueR /= CounterR;
            }
            if (CounterT > 0)
            {
                redT /= CounterT;
                greenT /= CounterT;
                blueT /= CounterT;
            }
            //if (redL > 0 || greenL > 0 || blueL > 0 || redR > 0 || greenR > 0 || blueR > 0 || redT > 0 || greenT > 0 || blueT > 0)
            {
                Array.Copy(global.CurrentColor, global.PreviousColor, 9);

                global.CurrentColor[0] = redL;
                global.CurrentColor[3] = greenL;
                global.CurrentColor[6] = blueL;
                global.CurrentColor[2] = redR;
                global.CurrentColor[5] = greenR;
                global.CurrentColor[8] = blueR;
                global.CurrentColor[1] = redT;
                global.CurrentColor[4] = greenT;
                global.CurrentColor[7] = blueT;

                global.RealByte[0] = redL;
                global.RealByte[3] = greenL;
                global.RealByte[6] = blueL;
                global.RealByte[2] = redR;
                global.RealByte[5] = greenR;
                global.RealByte[8] = blueR;
                global.RealByte[1] = redT;
                global.RealByte[4] = greenT;
                global.RealByte[7] = blueT;
            }

            for (int I = 0; I < 9; I++)
            {
                global.SendByte[I] = (byte)(global.CurrentColor[I]);
            }
        }

        private void SendColours()
        {
            bool send = false;
            for (int I = 0; I < 9; I++)
            {
                if (global.SendByte[I] != global.OldSendByte[I])
                {
                    send = true;
                }
            }

            if (send)
            {
                if (global._connected)
                    SendData(); //send the values
                else
                    OpenConnection();

                if ((this.WindowState != FormWindowState.Minimized) && (ShowDebugDiag.Checked)) //Show the average colors on screen
                {
                    try
                    {
                        ColorLeft.Invoke(new MethodInvoker(delegate() { ColorLeft.BackColor = Color.FromArgb((int)global.SendByte[0], (int)global.SendByte[3], (int)global.SendByte[6]); }));
                        ColorTop.Invoke(new MethodInvoker(delegate() { ColorTop.BackColor = Color.FromArgb((int)global.SendByte[1], (int)global.SendByte[4], (int)global.SendByte[7]); }));
                        ColorRight.Invoke(new MethodInvoker(delegate() { ColorRight.BackColor = Color.FromArgb((int)global.SendByte[2], (int)global.SendByte[5], (int)global.SendByte[8]); }));

                        label44.Invoke(new MethodInvoker(delegate() { label44.Text = global.RealByte[1].ToString() + "/" + global.SendByte[1].ToString(); }));
                        label43.Invoke(new MethodInvoker(delegate() { label43.Text = global.RealByte[4].ToString() + "/" + global.SendByte[4].ToString(); }));
                        label42.Invoke(new MethodInvoker(delegate() { label42.Text = global.RealByte[7].ToString() + "/" + global.SendByte[7].ToString(); }));
                        label48.Invoke(new MethodInvoker(delegate() { label48.Text = global.RealByte[0].ToString() + "/" + global.SendByte[0].ToString(); }));
                        label47.Invoke(new MethodInvoker(delegate() { label47.Text = global.RealByte[3].ToString() + "/" + global.SendByte[3].ToString(); }));
                        label45.Invoke(new MethodInvoker(delegate() { label45.Text = global.RealByte[6].ToString() + "/" + global.SendByte[6].ToString(); }));
                        label54.Invoke(new MethodInvoker(delegate() { label54.Text = global.RealByte[2].ToString() + "/" + global.SendByte[2].ToString(); }));
                        label53.Invoke(new MethodInvoker(delegate() { label53.Text = global.RealByte[5].ToString() + "/" + global.SendByte[5].ToString(); }));
                        label52.Invoke(new MethodInvoker(delegate() { label52.Text = global.RealByte[8].ToString() + "/" + global.SendByte[8].ToString(); }));
                    }
                    catch { }
                }
                //this.Text = "sending";
            }
            else
            {
                //this.Text = "not sending";
            }

            Array.Copy(global.SendByte, global.OldSendByte, 9);
        }

        public static Bitmap CreateThumbnail(Bitmap loBMP, int lnWidth, int lnHeight)
        {
            Bitmap bmpOut = null;

            try
            {

                // Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;

                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                /*
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;
                // */

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                if (lnNewHeight < 0) lnNewHeight = 1;
                if (lnNewWidth < 0) lnNewWidth = 1;
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                // g.InterpolationMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                // g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }

        /// <summary>
        /// Create the screen shot request
        /// </summary>
        void DoRequest()
        {
            if (global.MethodReady && global.Enabled && global.ReadyToCapture)
            {
                StartMeasureTime = DateTime.Now;
                global.ReadyToCapture = false;

                if (rbDirect3D9.Checked || rbDirect3D10.Checked || rbDirect3D11.Checked)
                    ScreenshotManager.AddScreenshotRequest(processId,
                        new ScreenshotRequest(new System.Drawing.Rectangle
                            (global.Request_X, global.Request_Y, global.Request_W, global.Request_H),
                                global.var_ReduceToWidth), DXCallback);
                else if (rbNET.Checked || rbGDI.Checked || rbMirrorDriver.Checked) scProcess();
            }
        }

        /// <summary>
        /// The callback for when the screenshot has been taken
        /// </summary>
        void scProcess()
        {
            try
            {
                //Bitmap ;
                Bitmap CapturedImage = null;

                if (rbMirrorDriver.Checked)
                    CapturedImage = _mirror.GetScreen();
                else
                {
                    ScreenCapture sc = new ScreenCapture();


                    int tWidth = global.var_ReduceToWidth;
                    int tHeight = 10;

                    if (tWidth > 1)
                    {
                        tHeight = (int)(global.var_ReduceToWidth / 1.6);
                    }
                    if (tHeight <= 1 || tWidth <= 1)
                    {
                        tWidth = 192;
                        tHeight = 120;
                    }

                    if (cbAdapter.Checked)
                    {
                        if (rbGDI.Checked) CapturedImage = sc.GDICaptureScreen(global.SelectedDisplay, tWidth, tHeight);
                        else if (rbNET.Checked) CapturedImage = sc.NETCaptureScreen(global.SelectedDisplay);
                    }
                    else if ((_textBoxHandle.Text != "") && (cbHandle.Checked))
                    {
                        IntPtr hWnd;
                        hWnd = (IntPtr)Convert.ToInt32(_textBoxHandle.Text);
                        if (rbGDI.Checked) CapturedImage = sc.GDICaptureWindow(hWnd);
                        else if (rbNET.Checked) CapturedImage = sc.NETCaptureWindow(hWnd);
                    }
                    else
                    {
                        if (rbGDI.Checked) CapturedImage = sc.GDICaptureWindow(Win32.GetDesktopWindow());
                        else if (rbNET.Checked) CapturedImage = sc.NETCaptureWindow(Win32.GetDesktopWindow());
                    }
                }

                if (CapturedImage != null)
                {
                    Bitmap ResizedImage;

                    int nWidth = 1, nHeight = 1;

                    if (CapturedImage.Size.Width > global.var_ReduceToWidth)
                    {
                        nWidth = global.var_ReduceToWidth;
                        double ndHeight = CapturedImage.Height / (CapturedImage.Width / global.var_ReduceToWidth);
                        if (ndHeight < 1) ndHeight = 1;
                        nHeight = (int)ndHeight;
                    }
                    else
                    {
                        nWidth = CapturedImage.Width;
                        nHeight = CapturedImage.Height;
                    }
                    ResizedImage = CreateThumbnail(CapturedImage, nWidth, nHeight);
                    //else ResizedImage = CapturedImage;

                    // Get Data
                    GrabColors(ResizedImage);

                    // Send Colors on seperate thread
                    Thread tSendColors = new Thread(new ThreadStart(SendColours));
                    tSendColors.Start();

                    // Measure time
                    EndMeasureTime = DateTime.Now;
                    diffMeasure = EndMeasureTime - StartMeasureTime;

                    if (diffMeasure < TimeSpan.FromMilliseconds(global.var_Interval))
                        SleepTime = TimeSpan.FromMilliseconds(global.var_Interval) - diffMeasure;
                    else
                        SleepTime = TimeSpan.FromMilliseconds(0);


                    if (ShowFPS.Checked && this.WindowState != FormWindowState.Minimized)
                        ShowFPS.Invoke(new MethodInvoker(delegate() { ShowFPS.Text = "FPS: " + Utility.CalculateFrameRate().ToString(); }));

                    if (measure.Checked && this.WindowState != FormWindowState.Minimized)
                    {
                        label87.Invoke(new MethodInvoker(delegate() { label87.Text = diffMeasure.ToString(); }));
                        label8.Invoke(new MethodInvoker(delegate() { label8.Text = SleepTime.ToString(); }));
                    }

                    if (ShowPreview.Checked && this.WindowState != FormWindowState.Minimized)
                    {
                        pictureBox1.Invoke(new MethodInvoker(delegate()
                        {
                            if (pictureBox1.Image != null)
                            {
                                pictureBox1.Image.Dispose();
                            }
                            /* Size needs +2
                            if (pictureBox1.Size != ResizedImage.Size)
                                pictureBox1.Size = ResizedImage.Size;
                            // */
                            if ((pictureBox1.Size.Width + 2) != ResizedImage.Size.Width) pictureBox1.Width = ResizedImage.Width + 2;
                            if ((pictureBox1.Size.Height + 2) != ResizedImage.Size.Height) pictureBox1.Height = ResizedImage.Height + 2;

                            pictureBox1.Image = ResizedImage;
                        })
                        );
                    }

                }

                // Sleep Interval..
                Thread.Sleep(SleepTime);

                global.ReadyToCapture = true;

                Thread t = new Thread(new ThreadStart(DoRequest));
                t.Start();

                if (CapturedImage != null) CapturedImage.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// The callback for when the screenshot has been taken
        /// </summary>
        /// <param name="clientPID"></param>
        /// <param name="status"></param>
        /// <param name="screenshotResponse"></param>
        void DXCallback(Int32 clientPID, ResponseStatus status, ScreenshotResponse screenshotResponse)
        {

            try
            {
                if (screenshotResponse != null && screenshotResponse.CapturedBitmap != null)
                {
                    // Get Data
                    GrabColors(screenshotResponse.CapturedBitmapAsImage);

                    // Send Colors on seperate thread
                    Thread tSendColors = new Thread(new ThreadStart(SendColours));
                    tSendColors.Start();

                    // Measure time
                    EndMeasureTime = DateTime.Now;
                    diffMeasure = EndMeasureTime - StartMeasureTime;

                    if (diffMeasure < TimeSpan.FromMilliseconds(global.var_Interval))
                    {
                        SleepTime = TimeSpan.FromMilliseconds(global.var_Interval) - diffMeasure;
                    } else {
                        SleepTime = TimeSpan.FromMilliseconds(0);
                    }

                    if (ShowFPS.Checked && this.WindowState != FormWindowState.Minimized)
                        ShowFPS.Invoke(new MethodInvoker(delegate() { ShowFPS.Text = "FPS: " + Utility.CalculateFrameRate().ToString(); }));

                    // Additional ...
                    if (measure.Checked && this.WindowState != FormWindowState.Minimized)
                    {
                        label87.Invoke(new MethodInvoker(delegate() { label87.Text = diffMeasure.ToString(); } ));
                        label8.Invoke(new MethodInvoker(delegate() { label8.Text = SleepTime.ToString(); }));
                        //label87.Text = diffMeasure.ToString();
                        //label8.Text = SleepTime.ToString();
                    }
                    if (ShowPreview.Checked && this.WindowState != FormWindowState.Minimized)
                    {
                        pictureBox1.Invoke(new MethodInvoker(delegate()
                        {
                            if (pictureBox1.Image != null)
                            {
                                pictureBox1.Image.Dispose();
                            }
                            /* Size +2
                            if (pictureBox1.Size != screenshotResponse.CapturedBitmapAsImage.Size)
                                pictureBox1.Size = screenshotResponse.CapturedBitmapAsImage.Size;
                            // */
                            if ((pictureBox1.Size.Width + 2) != screenshotResponse.CapturedBitmapAsImage.Size.Width) pictureBox1.Width = screenshotResponse.CapturedBitmapAsImage.Size.Width + 2;
                            if ((pictureBox1.Size.Height + 2) != screenshotResponse.CapturedBitmapAsImage.Size.Height) pictureBox1.Height = screenshotResponse.CapturedBitmapAsImage.Size.Height + 2;

                            pictureBox1.Image = screenshotResponse.CapturedBitmapAsImage;
                        })
                        );
                    }

                    screenshotResponse.CapturedBitmapAsImage.Dispose();

                    // Sleep Interval..
                    Thread.Sleep(SleepTime);
                }

                global.ReadyToCapture = true;

                Thread t = new Thread(new ThreadStart(DoRequest));
                t.Start();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Display debug messages from the target process
        /// </summary>
        /// <param name="clientPID"></param>
        /// <param name="message"></param>
        void ScreenshotManager_OnScreenshotDebugMessage(int clientPID, string message)
        {
            txtDebugLog.Invoke(new MethodInvoker(delegate()
            {
                txtDebugLog.Text = String.Format("{0}:{1}\r\n{2}", clientPID, message, txtDebugLog.Text);
            })
            );
        }

        /// <summary>
        /// Bring the target window to the front and wait for it to be visible
        /// </summary>
        /// <remarks>If the window does not come to the front within approx. 30 seconds an exception is raised</remarks>
        private void BringProcessWindowToFront(Process process)
        {
            if (process == null)
                return;
            IntPtr handle = process.MainWindowHandle;
            int i = 0;

            while (!NativeMethods.IsWindowInForeground(handle))
            {
                if (i == 0)
                {
                    // Initial sleep if target window is not in foreground - just to let things settle
                    //Thread.Sleep(25);
                }

                if (NativeMethods.IsIconic(handle))
                {
                    // Minimized so send restore
                    NativeMethods.ShowWindow(handle, NativeMethods.WindowShowStyle.Restore);
                }
                else
                {
                    // Already Maximized or Restored so just bring to front
                    NativeMethods.SetForegroundWindow(handle);
                }
                Thread.Sleep(1);
                //Thread.Sleep(25);

                // Check if the target process main window is now in the foreground
                if (NativeMethods.IsWindowInForeground(handle))
                {
                    // Leave enough time for screen to redraw
                    // **********************************
                    //Thread.Sleep(100);
                    return;
                }

                // Prevent an infinite loop
                if (i > 45000) // about 45secs
                {
                    throw new Exception("Could not set process window to the foreground");
                }
                i++;
            }
        }

        private void AttachProcess()
        {
            bool newInstanceFound = false;

            while (!newInstanceFound)
            {
                Process[] processes = Process.GetProcessesByName(global.trg_ProcessName);
                foreach (Process process in processes)
                {
                    // Simply attach to the first one found.

                    // If the process doesn't have a mainwindowhandle yet, skip it (we need to be able to get the hwnd to set foreground etc)
                    if (process.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }

                    Direct3DVersion direct3DVersion = Direct3DVersion.Direct3D9;

                    if (rbDirect3D11.Checked)
                    {
                        direct3DVersion = Direct3DVersion.Direct3D11;
                    }
                    else if (rbDirect3D10.Checked)
                    {
                        direct3DVersion = Direct3DVersion.Direct3D10;
                    }
                    else if (rbDirect3D9.Checked)
                    {
                        direct3DVersion = Direct3DVersion.Direct3D9;
                    }

                    // Keep track of hooked processes in case more than one need to be hooked
                    HookManager.AddHookedProcess(process.Id);

                    processId = process.Id;
                    _process = process;

                    // Inject DLL into target process
                    RemoteHooking.Inject(
                        process.Id,
                        InjectionOptions.Default,
                        "ScreenshotInject.dll", // 32-bit version (the same because AnyCPU) could use different assembly that links to 32-bit C++ helper dll
                        "ScreenshotInject.dll", // 64-bit version (the same because AnyCPU) could use different assembly that links to 64-bit C++ helper dll
                        // the optional parameter list...
                        ChannelName, // The name of the IPC channel for the injected assembly to connect to
                        direct3DVersion, // The direct3DVersion used in the target application
                        global.var_VertexMode // VertexMode
                        );

                    // Ensure the target process is in the foreground,
                    // this prevents an issue where the target app appears to be in 
                    // the foreground but does not receive any user inputs.
                    // Note: the first Alt+Tab out of the target application after injection
                    //       may still be an issue - switching between windowed and 
                    //       fullscreen fixes the issue however (see ScreenshotInjection.cs for another option)
                    BringProcessWindowToFront(process);

                    newInstanceFound = true;
                    break;
                }
                //Thread.Sleep(10);
            }

            global.MethodReady = true;
        }

        private void PrepareMethod()
        {
            if (rbDirect3D9.Checked || rbDirect3D10.Checked || rbDirect3D11.Checked)
            {
                if (RegisterGAC.Enabled && RegisterGAC.Checked)
                {
                    // NOTE: On some 64-bit setups this doesn't work so well.
                    //       Sometimes if using a 32-bit target, it will not find the GAC assembly
                    //       without a machine restart, so requires manual insertion into the GAC
                    // Alternatively if the required assemblies are in the target applications
                    // search path they will load correctly.

                    // Must be running as Administrator to allow dynamic registration in GAC
                    Config.Register("ScreenshotInjector",
                        "ScreenshotInject.dll");
                }

                AttachProcess();
            }
            else if (rbNET.Checked)
            {
                global.MethodReady = true;
            }
            else if (rbGDI.Checked)
            {
                global.MethodReady = true;
            }
            else if (rbDirect3D9FrontBuffer.Checked)
            {
                global.MethodReady = true;
            }
            else if (rbOpenGL.Checked)
            {
                global.MethodReady = true;
            }
            else if (rbMirrorDriver.Checked)
            {
                _mirror = new DesktopMirror();
                _mirror.DesktopChange += _mirror_DesktopChange;

                global.MethodReady = true;

                try { _mirror.Load(); }
                catch (Exception ex)
                {
                    txtDebugLog.Text = String.Format("DFMirage error: {0})\r\n{1}", ex.Message, txtDebugLog.Text);
                    global.MethodReady = false;
                }

                try { _mirror.Connect(); }
                catch (Exception ex)
                {
                    txtDebugLog.Text = String.Format("DFMirage error: {0})\r\n{1}", ex.Message, txtDebugLog.Text);
                    global.MethodReady = false;
                }

                try
                { _mirror.Start(); }
                catch (Exception ex)
                {
                    txtDebugLog.Text = String.Format("DFMirage error: {0})\r\n{1}", ex.Message, txtDebugLog.Text);
                    global.MethodReady = false;
                }

            }
        }

        private void ReleaseMethod()
        {
            if (rbMirrorDriver.Checked)
            {
                _mirror.Stop();
                _mirror.Disconnect();
                _mirror.Unload();
                _mirror.Dispose();
            }
        }

        private void DisableWorkingUnit()
        {
            if (global.Enabled)
            {
                // Reset Injection status
                global.MethodReady = false;
                // Enabled?
                global.Enabled = false;
                // Reset Trigger Run status
                global.TriggeredRun = false;

                // If socket connected then Close Connection
                if (global._connected) CloseConnection();

                if (global.DisableDWM) DWM.DwmEnableComposition(true);

                this.Text = "AmbiLEDd.NET v3 DISABLED";
                EnableBtn.Text = "Enable";
                disableToolStripMenuItem.Text = "Enable";
                
                //Maybe some fadeout procedure before clearing?
                //Fade -------------
                Array.Clear(global.SendByte, 0, 9);

                ReleaseMethod();

                rbMirrorDriver.Enabled = true;
                rbDirect3D9FrontBuffer.Enabled = false;
                rbDirect3D9.Enabled = true;
                rbDirect3D10.Enabled = true;
                rbDirect3D11.Enabled = true;
                rbGDI.Enabled = true;
                rbNET.Enabled = true;
                rbOpenGL.Enabled = false;
                lbVertexProcessing.Enabled = true;
            }
        }

        private void EnableWorkingUnit()
        {
            if (!global.Enabled)
            {
                rbMirrorDriver.Enabled = false;
                rbDirect3D9FrontBuffer.Enabled = false;
                rbDirect3D9.Enabled = false;
                rbDirect3D10.Enabled = false;
                rbDirect3D11.Enabled = false;
                rbGDI.Enabled = false;
                rbNET.Enabled = false;
                rbOpenGL.Enabled = false;
                lbVertexProcessing.Enabled = false;

                if (global.DisableDWM) DWM.DwmEnableComposition(false);

                // Enabled?
                global.Enabled = true;
                // Reset ReadyToCapture
                global.ReadyToCapture = true;
                PrepareMethod();

                // If socket disconnected then Open Connection
                if (global._connected == false)
                { 
                    OpenConnection(); 
                }
                else
                {
                    DisableWorkingUnit();
                }

                Array.Clear(global.CurrentColor, 0, 9);
                EnableBtn.Text = "Disable";
                disableToolStripMenuItem.Text = "Disable";
                this.Text = "AmbiLEDd.NET v3";
                DoRequest();
            }
        }

        private void EnableDisable()
        {
            if (global.Enabled)
            {
                DisableWorkingUnit();
            }
            else
            {
                EnableWorkingUnit();
            }
        }

        private void TimerDelay_ValueChanged(object sender, EventArgs e)
        {
            global.var_Interval = (int)TimerDelay.Value;
        }

        private void AutoDetect_Tick(object sender, EventArgs e)
        {
            bool prs_FoundNew = false;
            bool prs_FoundOld = false;
            Process[] prs = Process.GetProcesses();
            //*
            if (global.TriggeredRun && global.trg_ProcessName != "")
            {
                foreach (Process proces in prs)
                {
                    if (proces.ProcessName == global.trg_ProcessName) prs_FoundOld = true;
                }
                if (!prs_FoundOld) DisableWorkingUnit();
            }
            // */
            //
            if (!global.TriggeredRun)
            {
                foreach (Process proces in prs)
                {
                    string[] split = ProcessName.Text.Split(new Char[] { '|' });

                    foreach (string s in split)
                    {
                        if (proces.ProcessName == s.Trim())
                        {
                            global.trg_ProcessName = s.Trim();
                            label2.Text = global.trg_ProcessName;
                            prs_FoundNew = true;
                        }
                        if (prs_FoundNew) break;
                    }
                    if (prs_FoundNew) break;
                }
            }

            if (prs_FoundNew && !global.Enabled && AutoEnable.Checked)
            {
                global.TriggeredRun = true;
                //DWM.DwmEnableComposition(false);
                EnableWorkingUnit();
            }
        }

        private void AutoEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoEnable.Checked)
            {
                EnableBtn.Enabled = false;
            }
            else
            {
                EnableBtn.Enabled = true;
            }
        }

        private void ReduceLevel_ValueChanged(object sender, EventArgs e)
        {
            global.var_ReduceToWidth = (int)ReduceLevel.Value;
        }

        private void VertexProcessing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVertexProcessing.Text == "HardwareVertex")
            {
                global.var_VertexMode = 0;
            }
            else if (lbVertexProcessing.Text == "SoftwareVertex")
            {
                global.var_VertexMode = 1;
            }
            else if (lbVertexProcessing.Text == "PureDevice")
            {
                global.var_VertexMode = 2;
            }
        }

        private void lnDFMirage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.demoforge.com/dfmirage.htm");
        }

        /// <summary>
        /// Processes window messages sent to the Spy Window
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                /*
                 * stop capturing events as soon as the user releases the left mouse button
                 * */
                case (int)Win32.WindowMessages.WM_LBUTTONUP:
                    CaptureMouse(false);
                    break;
                /*
                 * handle all the mouse movements
                 * */
                case (int)Win32.WindowMessages.WM_MOUSEMOVE:
                    HandleMouseMovements();
                    break;
            };

            base.WndProc(ref m);
        }

        /// <summary>
        /// Processes the mouse down events for the finder tool 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cbHandle.Checked) cbHandle.Checked = true;
            if (cbAdapter.Checked) cbAdapter.Checked = false;
            if (e.Button == MouseButtons.Left)
                CaptureMouse(true);
        }

        /// <summary>
        /// Returns the caption of a window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        private string GetWindowText(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(256);
            Win32.GetWindowText(hWnd, sb, 256);
            return sb.ToString();
        }

        /// <summary>
        /// Returns the name of a window's class
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        private string GetClassName(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(256);
            Win32.GetClassName(hWnd, sb, 256);
            return sb.ToString();
        }

        /// <summary>
        /// Captures or releases the mouse
        /// </summary>
        /// <param name="captured"></param>
        private void CaptureMouse(bool captured)
        {
            // if we're supposed to capture the window
            if (captured)
            {
                // capture the mouse movements and send them to ourself
                Win32.SetCapture(this.Handle);

                // set the mouse cursor to our finder cursor
                Cursor.Current = _cursorFinder;

                // change the image to the finder gone image
                _pictureBox.Image = _finderGone;
            }
            // otherwise we're supposed to release the mouse capture
            else
            {
                // so release it
                Win32.ReleaseCapture();

                // put the default cursor back
                Cursor.Current = _cursorDefault;

                // change the image back to the finder at home image
                _pictureBox.Image = _finderHome;

                // and finally refresh any window that we were highlighting
                if (_hPreviousWindow != IntPtr.Zero)
                {
                    WindowHighlighter.Refresh(_hPreviousWindow);
                    _hPreviousWindow = IntPtr.Zero;
                }
            }

            // save our capturing state
            _capturing = captured;
        }

        /// <summary>
        /// Handles all mouse move messages sent to the Spy Window
        /// </summary>
        private void HandleMouseMovements()
        {
            // if we're not capturing, then bail out
            if (!_capturing)
                return;

            try
            {
                // capture the window under the cursor's position
                IntPtr hWnd = Win32.WindowFromPoint(Cursor.Position);

                // if the window we're over, is not the same as the one before, and we had one before, refresh it
                if (_hPreviousWindow != IntPtr.Zero && _hPreviousWindow != hWnd)
                    WindowHighlighter.Refresh(_hPreviousWindow);

                // if we didn't find a window.. that's pretty hard to imagine. lol
                if (hWnd == IntPtr.Zero)
                {
                    _textBoxHandle.Text = null;
                    _textBoxClass.Text = null;
                    _textBoxText.Text = null;
                    _textBoxStyle.Text = null;
                    _textBoxRect.Text = null;
                }
                else
                {
                    // save the window we're over
                    _hPreviousWindow = hWnd;

                    // handle
                    _textBoxHandle.Text = string.Format("{0}", hWnd.ToInt32().ToString());

                    // class
                    _textBoxClass.Text = this.GetClassName(hWnd);

                    // caption
                    _textBoxText.Text = this.GetWindowText(hWnd);

                    Win32.Rect rc = new Win32.Rect();
                    Win32.GetWindowRect(hWnd, ref rc);

                    // rect
                    _textBoxRect.Text = string.Format("[{0} x {1}], ({2},{3})-({4},{5})", rc.right - rc.left, rc.bottom - rc.top, rc.left, rc.top, rc.right, rc.bottom);

                    // highlight the window
                    WindowHighlighter.Highlight(hWnd);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void lbDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            global.SelectedDisplay = Convert.ToInt32(lbDisplays.Text[0].ToString(), 10);
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://qnapclub.pl/qnas/AmbiLED/");
        }

        private void cbDisableDWM_CheckedChanged(object sender, EventArgs e)
        {
            global.DisableDWM = cbDisableDWM.Checked;
        }


    }
}