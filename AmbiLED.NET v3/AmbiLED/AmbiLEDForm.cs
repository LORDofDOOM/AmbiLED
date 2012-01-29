using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;
/*
Copyright 2011 Mariusz Grzybacz

This file is part of AmbiLED.

AmbiLED is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

AmbiLED is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/


namespace AmbiLED
{
    public partial class AmbiLEDForm : Form
    {
        public AsyncCallback pfnWorkerCallBack;
        public Socket m_socListener;
        public Socket m_socWorker;

        string FPS_Cycles, FPS_Received;

        string _received_d;
        byte c_data;
        // byte c_char;
        ushort checksum;

        DateTime StartMeasureTime;
        DateTime EndMeasureTime;
        TimeSpan diffMeasure;
        TimeSpan SleepTime;
        

        public AmbiLEDForm()
        {

            InitializeComponent();

        }

        public class DWM
        {
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableComposition(bool bEnable);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

            XmlDocument settings = new XmlDataDocument();
            settings.Load(Application.StartupPath + "\\AmbiLED.xml");
            XmlElement root = settings.DocumentElement;
            for (int I = 0; I < root.ChildNodes.Count; I++)
            {
                if (root.ChildNodes[I].Name == "comport")
                {
                    txtPortname.Text = root.ChildNodes[I].InnerText;
                }

                else if (root.ChildNodes[I].Name == "baudrate")
                {
                    comboBaud.Text = root.ChildNodes[I].InnerText;
                }
                else if (root.ChildNodes[I].Name == "color")
                {
                    Colorslider.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    global.var_ColorSlider = (int)Colorslider.Value;
                }
                else if (root.ChildNodes[I].Name == "minimized")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
                else if (root.ChildNodes[I].Name == "mode")
                {
                    if (root.ChildNodes[I].InnerText == "movie")
                    {
                        global.Mode = 0;                        
                        ModeCombo.Text = "Movie";
                        ModeCombo2.Text = "Movie";
                    }
                    else if (root.ChildNodes[I].InnerText == "gaming")
                    {
                        global.Mode = 1;
                        ModeCombo.Text = "Gaming";
                        ModeCombo2.Text = "Gaming";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                    }
                    else if (root.ChildNodes[I].InnerText == "10*movie smooth")
                    {
                        global.Mode = 2;
                        ModeCombo.Text = "10*Movie smooth";
                        ModeCombo2.Text = "10*Movie smooth";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                    }
                    else if (root.ChildNodes[I].InnerText == "True-Cinema +Expansion")
                    {
                        global.Mode = 3;
                        ModeCombo.Text = "True-Cinema +Expansion";
                        ModeCombo2.Text = "True-Cinema +Expansion";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                    }
                    else if (root.ChildNodes[I].InnerText == "(temp1)")
                    {
                        global.Mode = 4;
                        ModeCombo.Text = "(temp1)";
                        ModeCombo2.Text = "(temp1)";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                    }
                    else if (root.ChildNodes[I].InnerText == "(temp2)")
                    {
                        global.Mode = 5;
                        ModeCombo.Text = "(temp2)";
                        ModeCombo2.Text = "(temp2)";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                    }
                    else if (root.ChildNodes[I].InnerText == "(temp3)")
                    {
                        global.Mode = 6;
                        ModeCombo.Text = "(temp3)";
                        ModeCombo2.Text = "(temp3)";
                        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                    }
                }
                else if (root.ChildNodes[I].Name == "DynamicControl")
                {
                    if (root.ChildNodes[I].InnerText == "(HSL)HSB.Brightness")
                    {
                        global.in_DynamicControl = 0;
                        DynamicControl.Text = "(HSL)HSB.Brightness";
                    }
                    else if (root.ChildNodes[I].InnerText == "HSV.Value")
                    {
                        global.in_DynamicControl = 1;
                        DynamicControl.Text = "HSV.Value";
                    }
                    else if (root.ChildNodes[I].InnerText == "Scene Difference")
                    {
                        global.in_DynamicControl = 2;
                        DynamicControl.Text = "Scene Difference";
                    }
                }
                else if (root.ChildNodes[I].Name == "controller")
                {
                    if (root.ChildNodes[I].InnerText == "v1 v2")
                    {
                        global.Controller = 0;
                        Controller.Text = "v1 v2";
                    }
                    else if (root.ChildNodes[I].InnerText == "v3")
                    {
                        global.Controller = 1;
                        Controller.Text = "v3";
                    }
                }
                else if (root.ChildNodes[I].Name == "GammaEvent")
                {
                    global.var_GammaEvent = Convert.ToByte(root.ChildNodes[I].InnerText, 10);
                    UpdateGammaEvent();
                }
                else if (root.ChildNodes[I].Name == "expand")
                {
                    if (root.ChildNodes[I].InnerText == "1")
                    {
                        radioButton1.Checked = true;
                        global.var_ExpandMode = 1;
                    }
                    else if (root.ChildNodes[I].InnerText == "2")
                    {
                        radioButton2.Checked = true;
                        global.var_ExpandMode = 2;
                    }
                    else
                    {
                        radioButton3.Checked = true;
                        global.var_ExpandMode = 3;
                    }
                }
                else if (root.ChildNodes[I].Name == "maxmultiply")
                {
                    numericUpDown1.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    global.var_MaxMultiply = (int)numericUpDown1.Value;
                }
                else if (root.ChildNodes[I].Name == "ProgressiveThreshold")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        ProgressiveThreshold.Checked = true;
                    }
                    else
                    {
                        ProgressiveThreshold.Checked = false;
                    }
                }
                else if (root.ChildNodes[I].Name == "DynamicSmoothRadius")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        DynamicSmoothRadius.Checked = true;
                    }
                    else
                    {
                        DynamicSmoothRadius.Checked = false;
                    }
                }
                else if (root.ChildNodes[I].Name == "QuantizeLevel")
                {
                    QuantizeLevel.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    global.var_QuantizeLevel = (int)QuantizeLevel.Value;
                }
                else if (root.ChildNodes[I].Name == "DarknessThreshold")
                {
                    DarknessThreshold.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    DarknessThresholdUpDown.Value = DarknessThreshold.Value;
                    global.var_DarknessThreshold = (int)DarknessThreshold.Value;
                }
                else if (root.ChildNodes[I].Name == "AggressiveThreshold")
                {
                    AggressiveThreshold.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    AggressiveThresholdUpDown.Value = AggressiveThreshold.Value;
                    global.var_AggressiveThreshold = AggressiveThreshold.Value;
                }
                else if (root.ChildNodes[I].Name == "MaxSmoothRadius")
                {
                    MaxSmoothRadius.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    MaxSmoothRadiusUpDown.Value = MaxSmoothRadius.Value;
                    global.var_MaxSmoothRadius = MaxSmoothRadius.Value;
                }
                else if (root.ChildNodes[I].Name == "MinSmoothRadius")
                {
                    MinSmoothRadius.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    MinSmoothRadiusUpDown.Value = MinSmoothRadius.Value;
                    global.var_MinSmoothRadius = MinSmoothRadius.Value;
                }
                else if (root.ChildNodes[I].Name == "SlideDelay")
                {
                    DynamicRadiusSlideDelay.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    DynamicRadiusSlideDelayUpDown.Value = DynamicRadiusSlideDelay.Value;
                    global.var_SlideDelay = DynamicRadiusSlideDelay.Value;
                }
                else if (root.ChildNodes[I].Name == "DarknessLimit")
                {
                    DarknessLimit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    DarknessLimitUpDown.Value = DarknessLimit.Value;
                    global.var_DarknessLimit = DarknessLimit.Value;
                }
                else if (root.ChildNodes[I].Name == "DarknessLimitMethod")
                {
                    if (root.ChildNodes[I].InnerText == "HSB")
                    {
                        global.in_DarknessLimitMethod = 0;
                        DarknessLimitMethod.Text = "HSB";
                    }
                    else if (root.ChildNodes[I].InnerText == "HSV")
                    {
                        global.in_DarknessLimitMethod = 1;
                        DarknessLimitMethod.Text = "HSV";
                    }
                }
                else if (root.ChildNodes[I].Name == "RedLeft")
                    RedLeft.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedTop")
                    RedTop.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedRight")
                    RedRight.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenLeft")
                    GreenLeft.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenTop")
                    GreenTop.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenRight")
                    GreenRight.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueLeft")
                    BlueLeft.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueTop")
                    BlueTop.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueRight")
                    BlueRight.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);

                else if (root.ChildNodes[I].Name == "RedLeftOnStart")
                    RedLeftOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedTopOnStart")
                    RedTopOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedRightOnStart")
                    RedRightOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenLeftOnStart")
                    GreenLeftOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenTopOnStart")
                    GreenTopOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenRightOnStart")
                    GreenRightOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueLeftOnStart")
                    BlueLeftOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueTopOnStart")
                    BlueTopOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueRightOnStart")
                    BlueRightOnStart.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);

                else if (root.ChildNodes[I].Name == "RedLeftOnExit")
                    RedLeftOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedTopOnExit")
                    RedTopOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "RedRightOnExit")
                    RedRightOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenLeftOnExit")
                    GreenLeftOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenTopOnExit")
                    GreenTopOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "GreenRightOnExit")
                    GreenRightOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueLeftOnExit")
                    BlueLeftOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueTopOnExit")
                    BlueTopOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                else if (root.ChildNodes[I].Name == "BlueRightOnExit")
                    BlueRightOnExit.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);

                else if (root.ChildNodes[I].Name == "GammaLevel")
                {
                    GammaValue.Value = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    UpdateGamma();
                }

                else if (root.ChildNodes[I].Name == "Interval")
                {
                    global.var_Interval = Convert.ToInt32(root.ChildNodes[I].InnerText, 10);
                    IntelliInterval.Value = global.var_Interval;
                }
                else if (root.ChildNodes[I].Name == "showoutput")
                {
                    if (root.ChildNodes[I].InnerText == "true")
                    {
                        ShowOutput.Checked = true;
                        global.ShowOutput = true;
                    }
                    else
                    {
                        ShowOutput.Checked = false;
                        global.ShowOutput = false;
                    }
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
                else if (root.ChildNodes[I].Name == "ProcessName")
                {
                    ProcessName.Text = root.ChildNodes[I].InnerText;
                }
            }
            
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            if (serialPort1.IsOpen == false)
                try
                {
                    OpenSerial();
                    SendOnStart();
                    serialPort1.Close();
                    serialPort1.Dispose();
                }
                catch { }
        }

        private void ApplyColours()
        {
            Array.Copy(global.PreviousColor9, global.PreviousColor10, 9);
            Array.Copy(global.PreviousColor8, global.PreviousColor9, 9);
            Array.Copy(global.PreviousColor7, global.PreviousColor8, 9);
            Array.Copy(global.PreviousColor6, global.PreviousColor7, 9);
            Array.Copy(global.PreviousColor5, global.PreviousColor6, 9);
            Array.Copy(global.PreviousColor4, global.PreviousColor5, 9);
            Array.Copy(global.PreviousColor3, global.PreviousColor4, 9);
            Array.Copy(global.PreviousColor2, global.PreviousColor3, 9);
            Array.Copy(global.PreviousColor, global.PreviousColor2, 9);
            Array.Copy(global.CurrentColor, global.PreviousColor, 9);
            Array.Copy(global.ReceivedRGB, global.CurrentColor, 9);
        }
        private void ApplyColours(int I)
        {
            global.PreviousColor10[I] = global.PreviousColor9[I];
            global.PreviousColor10[I + 3] = global.PreviousColor9[I + 3];
            global.PreviousColor10[I + 6] = global.PreviousColor9[I + 6];

            global.PreviousColor9[I] = global.PreviousColor8[I];
            global.PreviousColor9[I + 3] = global.PreviousColor8[I + 3];
            global.PreviousColor9[I + 6] = global.PreviousColor8[I + 6];

            global.PreviousColor8[I] = global.PreviousColor7[I];
            global.PreviousColor8[I + 3] = global.PreviousColor7[I + 3];
            global.PreviousColor8[I + 6] = global.PreviousColor7[I + 6];

            global.PreviousColor7[I] = global.PreviousColor6[I];
            global.PreviousColor7[I + 3] = global.PreviousColor6[I + 3];
            global.PreviousColor7[I + 6] = global.PreviousColor6[I + 6];

            global.PreviousColor6[I] = global.PreviousColor5[I];
            global.PreviousColor6[I + 3] = global.PreviousColor5[I + 3];
            global.PreviousColor6[I + 6] = global.PreviousColor5[I + 6];

            global.PreviousColor5[I] = global.PreviousColor4[I];
            global.PreviousColor5[I + 3] = global.PreviousColor4[I + 3];
            global.PreviousColor5[I + 6] = global.PreviousColor4[I + 6];

            global.PreviousColor4[I] = global.PreviousColor3[I];
            global.PreviousColor4[I + 3] = global.PreviousColor3[I + 3];
            global.PreviousColor4[I + 6] = global.PreviousColor3[I + 6];

            global.PreviousColor3[I] = global.PreviousColor2[I];
            global.PreviousColor3[I + 3] = global.PreviousColor2[I + 3];
            global.PreviousColor3[I + 6] = global.PreviousColor2[I + 6];

            global.PreviousColor2[I] = global.PreviousColor[I];
            global.PreviousColor2[I + 3] = global.PreviousColor[I + 3];
            global.PreviousColor2[I + 6] = global.PreviousColor[I + 6];

            global.PreviousColor[I] = global.CurrentColor[I];
            global.PreviousColor[I + 3] = global.CurrentColor[I + 3];
            global.PreviousColor[I + 6] = global.CurrentColor[I + 6];

            global.CurrentColor[I] = global.ReceivedRGB[I];
            global.CurrentColor[I + 3] = global.ReceivedRGB[I + 3];
            global.CurrentColor[I + 6] = global.ReceivedRGB[I + 6];
        }

        void VoodooInput()
        {
            if ((this.WindowState != FormWindowState.Minimized) && (ShowDebugDiag.Checked))
            {
                try
                {
                    cLeft.Invoke(new MethodInvoker(delegate() { cLeft.BackColor = Color.FromArgb((int)global.tempReceivedRGB[0], (int)global.tempReceivedRGB[3], (int)global.tempReceivedRGB[6]); }));
                    cTop.Invoke(new MethodInvoker(delegate() { cTop.BackColor = Color.FromArgb((int)global.tempReceivedRGB[1], (int)global.tempReceivedRGB[4], (int)global.tempReceivedRGB[7]); }));
                    cRight.Invoke(new MethodInvoker(delegate() { cRight.BackColor = Color.FromArgb((int)global.tempReceivedRGB[2], (int)global.tempReceivedRGB[5], (int)global.tempReceivedRGB[8]); }));
                }
                catch { }
            }


            float x;

            // Quantize -- not really mathematics but works
            for (int I = 0; I < 9; I++)
                global.tempReceivedRGB[I] = 
                    ((int)((float)global.tempReceivedRGB[I] / global.var_QuantizeLevel)
                    * global.var_QuantizeLevel);

            // DarknessThreshold
            for (int I = 0; I < 3; I += 1)
                if ((global.tempReceivedRGB[I] < global.var_DarknessThreshold)
                    && (global.tempReceivedRGB[I + 3] < global.var_DarknessThreshold)
                    && (global.tempReceivedRGB[I + 6] < global.var_DarknessThreshold))
                {
                    global.tempReceivedRGB[I] = 0;
                    global.tempReceivedRGB[I + 3] = 0;
                    global.tempReceivedRGB[I + 6] = 0;
                }

            // Progressive Threshold -- not sure if it's ok
            if (global._ProgressiveThreshold == true)
                for (int I = 0; I < 9; I++)
                {
                    x = global.tempReceivedRGB[I] * 100 / 255;
                    global.tempReceivedRGB[I] = (int)((float)global.tempReceivedRGB[I] * x / 100);
                }

            // Expand mode + Multiply
            if (global.var_ExpandMode == 2)
            {
                int[] Highest = new int[3] { 0, 0, 0 };
                for (int I = 0; I < 9; I += 3)
                {
                    if (Highest[0] < global.tempReceivedRGB[I]) Highest[0] = global.tempReceivedRGB[I];
                    if (Highest[1] < global.tempReceivedRGB[I + 1]) Highest[1] = global.tempReceivedRGB[I + 1];
                    if (Highest[2] < global.tempReceivedRGB[I + 2]) Highest[2] = global.tempReceivedRGB[I + 2];
                }
                float[] Multiply = new float[3];
                for (int I = 0; I < 3; I++)
                {
                    Multiply[I] = 255.0F / (float)Highest[I];
                    if (Multiply[I] > global.var_MaxMultiply) Multiply[I] = global.var_MaxMultiply;
                }
                for (int I = 0; I < 9; I += 3)
                {
                    global.tempReceivedRGB[I] = (int)((float)global.tempReceivedRGB[I] * Multiply[0]);
                    global.tempReceivedRGB[I + 1] = (int)((float)global.tempReceivedRGB[I + 1] * Multiply[1]);
                    global.tempReceivedRGB[I + 2] = (int)((float)global.tempReceivedRGB[I + 2] * Multiply[2]);
                }
            }

            if (global.var_ExpandMode == 3)
            {
                int Highest = 0;
                for (int I = 0; I < 9; I++)
                {
                    if (Highest < global.tempReceivedRGB[I])
                        Highest = global.tempReceivedRGB[I];
                }
                float Multiply = 255.0F / (float)Highest;
                if (Multiply > global.var_MaxMultiply)
                {
                    Multiply = global.var_MaxMultiply;
                }
                for (int I = 0; I < 9; I++)
                {
                    global.tempReceivedRGB[I] = (int)((float)global.tempReceivedRGB[I] * Multiply);
                }
            }

            if (global.var_DarknessLimit > 0)
            {
                for (int I = 0; I < 3; I += 1)
                {
                    if (global.in_DarknessLimitMethod == 0)
                    {
                        Color c = Color.FromArgb((int)global.tempReceivedRGB[I], (int)global.tempReceivedRGB[I + 3], (int)global.tempReceivedRGB[I + 6]);
                        RGBHSL.HSL hsl = RGBHSL.GetHSL(c);
                        if ((hsl.L * 255) < global.var_DarknessLimit) hsl.L = global.var_DarknessLimit * 255;
                        c = RGBHSL.GetRGB(hsl);
                        global.tempReceivedRGB[I] = c.R;
                        global.tempReceivedRGB[I + 3] = c.G;
                        global.tempReceivedRGB[I + 6] = c.B;
                    }
                    else if (global.in_DarknessLimitMethod == 1)
                    {
                        Color c = Color.FromArgb((int)global.tempReceivedRGB[I], (int)global.tempReceivedRGB[I + 3], (int)global.tempReceivedRGB[I + 6]);
                        RGBHSV.HSV hsv = RGBHSV.GetHSV(c);
                        if ((hsv.V * 255) < global.var_DarknessLimit) hsv.V = global.var_DarknessLimit * 255;
                        c = RGBHSV.GetRGB(hsv.H, hsv.S, hsv.V);
                        global.tempReceivedRGB[I] = c.R;
                        global.tempReceivedRGB[I + 3] = c.G;
                        global.tempReceivedRGB[I + 6] = c.B;
                    }

                }
            }
        }
        
        void VoodooOutput()
        {
            if (global._listening == false)
            {
                StartListening();
            }

            /*
            ComPort.Text = global.ReceivedRGB[0].ToString();
            label2.Text = global.ReceivedRGB[1].ToString();
            label22.Text = global.ReceivedRGB[2].ToString();
            label31.Text = global.ReceivedRGB[3].ToString();
            label84.Text = global.ReceivedRGB[4].ToString();
            label86.Text = global.ReceivedRGB[5].ToString();
            label30.Text = global.ReceivedRGB[6].ToString();
             */

            //movie
            if (global.Mode == 0)
            {
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                //DeskCapture();
                ApplyColours();
                int Red = 0, Green = 0, Blue = 0, Average = 0;
                for (int I = 0; I < 3; I++) //Copy the current color into the send byte array
                {
                    //Red = (global.CurrentColor[I] + global.PreviousColor[I] + global.PreviousColor2[I]) / 3;
                    //Green = (global.CurrentColor[I + 3] + global.PreviousColor[I + 3] + global.PreviousColor2[I + 3]) / 3;
                    //Blue = (global.CurrentColor[I + 6] + global.PreviousColor[I + 6] + global.PreviousColor2[I + 6]) / 3;
                    //Red = global.PreviousColor[I];
                    //Green = global.PreviousColor[I + 3];
                    //Blue = global.PreviousColor[I + 6];
                    Red = global.CurrentColor[I];
                    Green = global.CurrentColor[I + 3];
                    Blue = global.CurrentColor[I + 6];

                    Average = (Red + Green + Blue) / 3;

                    //Increase of color by extrapolation, or interpolation, I don't know :P
                    Red = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Red) / 10);
                    Green = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Green) / 10);
                    Blue = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Blue) / 10);
                    
                    if (Red > 255) Red = 255;
                    if (Green > 255) Green = 255;
                    if (Blue > 255) Blue = 255;
                    if (Red < 0) Red = 0;
                    if (Green < 0) Green = 0;
                    if (Blue < 0) Blue = 0;

                    global.SendByte[I] = (byte)Red;
                    global.SendByte[I + 3] = (byte)Green;
                    global.SendByte[I + 6] = (byte)Blue;

                }
            }

            //gaming
            else if (global.Mode == 1)
            {
                // System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                ApplyColours();
                global.Counter++;
                if (global.Counter == 10)
                {
                    global.Counter = 0;
                    //DeskCapture();
                    int Red = 0, Green = 0, Blue = 0, Average = 0;
                    for (int I = 0; I < 3; I++) //Copy the current color into the send byte array
                    {
                        Red = global.PreviousColor[I];
                        Green = global.PreviousColor[I + 3];
                        Blue = global.PreviousColor[I + 6];

                        Average = (Red + Green + Blue) / 3;

                        Red = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Red) / 10);
                        Green = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Green) / 10);
                        Blue = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Blue) / 10);

                        if (Red > 255) Red = 255;
                        if (Green > 255) Green = 255;
                        if (Blue > 255) Blue = 255;
                        if (Red < 0) Red = 0;
                        if (Green < 0) Green = 0;
                        if (Blue < 0) Blue = 0;

                        global.SendByte[I] = (byte)Red;
                        global.SendByte[I + 3] = (byte)Green;
                        global.SendByte[I + 6] = (byte)Blue;

                    }

                }
                else
                {
                    int Red = 0, Green = 0, Blue = 0, Average = 0;
                    for (int I = 0; I < 3; I++) //Copy the current color into the send byte array
                    {
                        Red = global.PreviousColor[I] + ((global.CurrentColor[I] - global.PreviousColor[I]) * global.Counter / 10);
                        Green = global.PreviousColor[I + 3] + ((global.CurrentColor[I + 3] - global.PreviousColor[I + 3]) * global.Counter / 10);
                        Blue = global.PreviousColor[I + 6] + ((global.CurrentColor[I + 6] - global.PreviousColor[I + 6]) * global.Counter / 10);


                        
                        Average = (Red + Green + Blue) / 3;

                        Red = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Red) / 10);
                        Green = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Green) / 10);
                        Blue = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Blue) / 10);

                        if (Red > 255) Red = 255;
                        if (Green > 255) Green = 255;
                        if (Blue > 255) Blue = 255;
                        if (Red < 0) Red = 0;
                        if (Green < 0) Green = 0;
                        if (Blue < 0) Blue = 0;

                        global.SendByte[I] = (byte)Red;
                        global.SendByte[I + 3] = (byte)Green;
                        global.SendByte[I + 6] = (byte)Blue;

                    }
                
                
                }

            }
            else if (global.Mode == 2)
            {
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
//                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                //DeskCapture();
                ApplyColours();
                int Red = 0, Green = 0, Blue = 0, Average = 0;
                for (int I = 0; I < 3; I++) //Copy the current color into the send byte array
                {
                    Red = (global.CurrentColor[I] + global.PreviousColor[I] + global.PreviousColor2[I] + global.PreviousColor3[I] + global.PreviousColor4[I] + global.PreviousColor5[I] + global.PreviousColor6[I] + global.PreviousColor7[I] + global.PreviousColor8[I] + global.PreviousColor9[I]) / 10;
                    Green = (global.CurrentColor[I + 3] + global.PreviousColor[I + 3] + global.PreviousColor2[I + 3] + global.PreviousColor3[I + 3] + global.PreviousColor4[I + 3] + global.PreviousColor5[I + 3] + global.PreviousColor6[I + 3] + global.PreviousColor7[I + 3] + global.PreviousColor8[I + 3] + global.PreviousColor9[I + 3]) / 10;
                    Blue = (global.CurrentColor[I + 6] + global.PreviousColor[I + 6] + global.PreviousColor2[I + 6] + global.PreviousColor3[I + 6] + global.PreviousColor4[I + 6] + global.PreviousColor5[I + 6] + global.PreviousColor6[I + 6] + global.PreviousColor7[I + 6] + global.PreviousColor8[I + 6] + global.PreviousColor9[I + 6]) / 10;

                    Average = (Red + Green + Blue) / 3;

                    //Increase of color by extrapolation, or interpolation, I don't know :P
                    Red = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Red) / 10);
                    Green = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Green) / 10);
                    Blue = (10 - global.var_ColorSlider) * Average / 10 + ((global.var_ColorSlider * Blue) / 10);

                    if (Red > 255) Red = 255;
                    if (Green > 255) Green = 255;
                    if (Blue > 255) Blue = 255;
                    if (Red < 0) Red = 0;
                    if (Green < 0) Green = 0;
                    if (Blue < 0) Blue = 0;

                    global.SendByte[I] = (byte)Red;
                    global.SendByte[I + 3] = (byte)Green;
                    global.SendByte[I + 6] = (byte)Blue;

                }
            }
            else if (global.Mode == 3)
            {
                // System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;

                for (int I = 0; I < 3; I++) //Get colors from ReceivedRGB (real-timesocket)
                {                           //and check for Cycles change
                    bool _trg_Aggressive = false;
                    int Red = 0, Green = 0, Blue = 0;
                    int rDiff = 0, gDiff = 0, bDiff = 0;

                    if (global.DynamicRadius) global.__slidecounter[I]++;
                    global.CycleCounter[I]++; // Cycle count

                    // Prevent divide by zero
                    if (global.Cycles[I] == 0) global.Cycles[I] = 1;
                    if (global.temp_Cycles[I] == 0) global.temp_Cycles[I] = 1;

                    // calculate RGB differents
                    rDiff = global.ReceivedRGB[I] - global.PreviousColor[I];
                    if (rDiff < 0) rDiff *= -1; // rDiff
                    gDiff = global.ReceivedRGB[I + 3] - global.PreviousColor[I + 3];
                    if (gDiff < 0) gDiff *= -1; // gDiff
                    bDiff = global.ReceivedRGB[I + 6] - global.PreviousColor[I + 6];
                    if (bDiff < 0) bDiff *= -1; // bDiff

                    // check for AGGRESSIVE ATTACK: if diff of ANY oftwo last colours
                    // is > global.var_AggressiveThreshold ($X = 128)
                    if ((rDiff > global.var_AggressiveThreshold
                        || gDiff > global.var_AggressiveThreshold
                        || bDiff > global.var_AggressiveThreshold))
                        _trg_Aggressive = true; // SET AGGRESSIVE TRIGGER
                    
                    if (_trg_Aggressive) // when =1
                    {   //do AGGRESSIVE ATTACK on current [I] RGB channel
                        global.PreviousColor[I] = global.ReceivedRGB[I];
                        global.PreviousColor[I + 3] = global.ReceivedRGB[I + 3];
                        global.PreviousColor[I + 6] = global.ReceivedRGB[I + 6];
                        global.CurrentColor[I] = global.ReceivedRGB[I];
                        global.CurrentColor[I + 3] = global.ReceivedRGB[I + 3];
                        global.CurrentColor[I + 6] = global.ReceivedRGB[I + 6];
                        
                        rDiff = 0; gDiff = 0; bDiff = 0; //reset Diff

                        if (this.WindowState != FormWindowState.Minimized)
                        {   //display Aggressive change ------------------
                            try //prevent error when app closing
                            {
                                AggressiveIndicator.Invoke(new MethodInvoker(delegate() { AggressiveIndicator.Text = global.__progresschars[global.__aggressivecount * 2].ToString() + global.__progresschars[global.__aggressivecount * 2 + 1].ToString(); }));
                            }
                            catch { }
                            global.__aggressivecount++;
                            if (global.__aggressivecount == 4) global.__aggressivecount = 0;
                        }
                    }
                    

                    // ------ Create color from ReceivedRGB (needed to get Brightness level)
                    global.cReceivedRGB[I] = Color.FromArgb(global.ReceivedRGB[I],
                        global.ReceivedRGB[I + 3], global.ReceivedRGB[I + 6]);

                    int _input_Drange = 100;

                    if (global.in_DynamicControl == 0)
                    { // ---- Get Brightness from HSB (Brightness controls Smooth Radius)
                        global.dynamicValue[I] = Convert.ToInt32(
                            global.cReceivedRGB[I].GetBrightness() * _input_Drange);
                    }
                    else if (global.in_DynamicControl == 1)
                    { // ---- Get Value from HSV (Value controls Smooth Radius)
                        global.dynamicValue[I] = Convert.ToInt32(
                            RGBHSV.GetHSV(global.cReceivedRGB[I]).V  * _input_Drange);
                    }
                    else if (global.in_DynamicControl == 2)
                    { // ---- Get Scene Difference (Difference controls Smooth Radius)
                        global.dynamicValue[I] = (rDiff + gDiff + bDiff) * _input_Drange / (3 * 255);
                    }

                    if (!global.DynamicRadius) global.Cycles[I] = global.var_MaxSmoothRadius;
                    else //-- Calculate new smooth cycles number from brightness level
                        global.temp_Cycles[I] = global.var_MinSmoothRadius + ((global.var_MaxSmoothRadius - global.var_MinSmoothRadius) - (global.dynamicValue[I])
                            * (global.var_MaxSmoothRadius - global.var_MinSmoothRadius) / _input_Drange);
                    // ---------------------------------------------------------------------

                    // ------ While DynamicRadius and new radius value comes...
                    if ((global.temp_Cycles[I] != global.Cycles[I]) && (global.DynamicRadius))
                    {   // -- Perform Reset Smooth (1. Get previous; 2. Set new Cycles no.; 3. Reset Counter no.;
                        
                        // -- use last counter value
                        int _temp_Cycles = global.CycleCounter[I] - 1;
                        // -- prevent crash / divide by zero
                        if (global.CycleCounter[I] < 1) _temp_Cycles = 1;
                        
                        Red = global.PreviousColor[I] + ((global.CurrentColor[I] - global.PreviousColor[I]) * _temp_Cycles / global.Cycles[I]);
                        Green = global.PreviousColor[I + 3] + ((global.CurrentColor[I + 3] - global.PreviousColor[I + 3]) * _temp_Cycles / global.Cycles[I]);
                        Blue = global.PreviousColor[I + 6] + ((global.CurrentColor[I + 6] - global.PreviousColor[I + 6]) * _temp_Cycles / global.Cycles[I]);

                        // -- Slide with a Delay 
                        if (global.__slidecounter[I] >= global.var_SlideDelay)
                        {
                            //global.Cycles[I] = global.temp_Cycles[I];
                            global.__slidecounter[I] = 0;
                            if (global.temp_Cycles[I] > global.Cycles[I]) global.Cycles[I]++;
                            if (global.temp_Cycles[I] < global.Cycles[I]) global.Cycles[I]--;
                        } // -------------------

                        // -- 1. Reset counter; 2. Apply NEW previous colour
                        global.CycleCounter[I] = 1;
                        global.PreviousColor[I] = Red;
                        global.PreviousColor[I + 3] = Green;
                        global.PreviousColor[I + 6] = Blue;
                    }
                    // ---------------------------------------------------------------------

                    // ------ Smooth Colours by Radius
                    if ((global.CycleCounter[I] >= global.Cycles[I]) || (_trg_Aggressive))
                    { // ---- cycle finish
                        ApplyColours(I);
                        // why PreviousColor? becauce after Apply, our Current is in Previous now
                        Red = global.PreviousColor[I];
                        Green = global.PreviousColor[I + 3];
                        Blue = global.PreviousColor[I + 6];
                        global.CycleCounter[I] = 0;
                    }
                    else
                    { // ---- calculate 
                        Red = global.PreviousColor[I] + ((global.CurrentColor[I] - global.PreviousColor[I]) * global.CycleCounter[I] / global.Cycles[I]);
                        Green = global.PreviousColor[I + 3] + ((global.CurrentColor[I + 3] - global.PreviousColor[I + 3]) * global.CycleCounter[I] / global.Cycles[I]);
                        Blue = global.PreviousColor[I + 6] + ((global.CurrentColor[I + 6] - global.PreviousColor[I + 6]) * global.CycleCounter[I] / global.Cycles[I]);
                    }
                    // ---------------------------------------------------------------------

                    
                    // SAVE THEM INTO SENDBYTE
                    global.SendByte[I] = (byte)Red;
                    global.SendByte[I + 3] = (byte)Green;
                    global.SendByte[I + 6] = (byte)Blue;
                }

            }
            // */


            /*
            DebugTextBox.Clear();
            DebugTextBox.Text += "tmpdiff: " + global._tmp_diff[0].ToString("000") + " " + global._tmp_diff[1].ToString("000") + " " + global._tmp_diff[2].ToString("000") + "\r\n";
            DebugTextBox.Text += "tCycles: " + global.temp_Cycles[0].ToString("000") + " " + global.temp_Cycles[1].ToString("000") + " " + global.temp_Cycles[2].ToString("000") + "\r\n";
            DebugTextBox.Text += " Cycles: " + global.Cycles[0].ToString("000") + " " + global.Cycles[1].ToString("000") + " " + global.Cycles[2].ToString("000") + "\r\n";
            DebugTextBox.Text += "Counter: " + global.CycleCounter[0].ToString("000") + " " + global.CycleCounter[1].ToString("000") + " " + global.CycleCounter[2].ToString("000") + "\r\n";
            // */

            //This was added later, so it looks ugly :P

            /*
            if ((this.WindowState != FormWindowState.Minimized) && (ShowFPS.Checked))
                ShowFPS.Text = "FPS: " + Utility.CalculateFrameRate().ToString();
            // */
            
            //*
            bool send = false;

            for (int I = 0; I < 9; I++)
            {
                // Gamma | Event: Output data
                if (global.var_GammaEvent == 2)
                {
                    global.SendByte[I] = global.GammaArray[global.SendByte[I]];
                }

                // bool send = true;
                if (global.SendByte[I] != global.OldSendByte[I])
                {
                    send = true;
                }
            }
            //*/

            //if (true)
            if (send == true)
            {
                Array.Copy(global.SendByte, global.OldSendByte, 9);
                //*
                if ((this.WindowState != FormWindowState.Minimized) && (ShowDebugDiag.Checked))
                {
                    try
                    {
                        label44.Invoke(new MethodInvoker(delegate() { label44.Text = global.ReceivedRGB[1].ToString() + "/" + global.SendByte[1].ToString(); }));
                        label43.Invoke(new MethodInvoker(delegate() { label43.Text = global.ReceivedRGB[4].ToString() + "/" + global.SendByte[4].ToString(); }));
                        label42.Invoke(new MethodInvoker(delegate() { label42.Text = global.ReceivedRGB[7].ToString() + "/" + global.SendByte[7].ToString(); }));
                        label48.Invoke(new MethodInvoker(delegate() { label48.Text = global.ReceivedRGB[0].ToString() + "/" + global.SendByte[0].ToString(); }));
                        label47.Invoke(new MethodInvoker(delegate() { label47.Text = global.ReceivedRGB[3].ToString() + "/" + global.SendByte[3].ToString(); }));
                        label45.Invoke(new MethodInvoker(delegate() { label45.Text = global.ReceivedRGB[6].ToString() + "/" + global.SendByte[6].ToString(); }));
                        label54.Invoke(new MethodInvoker(delegate() { label54.Text = global.ReceivedRGB[2].ToString() + "/" + global.SendByte[2].ToString(); }));
                        label53.Invoke(new MethodInvoker(delegate() { label53.Text = global.ReceivedRGB[5].ToString() + "/" + global.SendByte[5].ToString(); }));
                        label52.Invoke(new MethodInvoker(delegate() { label52.Text = global.ReceivedRGB[8].ToString() + "/" + global.SendByte[8].ToString(); }));

                        //current smooth radius
                        radiusLeft.Invoke(new MethodInvoker(delegate() { radiusLeft.Value = global.Cycles[0]; }));
                        radiusTop.Invoke(new MethodInvoker(delegate() { radiusTop.Value = global.Cycles[1]; }));
                        radiusRight.Invoke(new MethodInvoker(delegate() { radiusRight.Value = global.Cycles[2]; }));

                        //destination smooth radius
                        dradiusLeft.Invoke(new MethodInvoker(delegate() { dradiusLeft.Value = global.temp_Cycles[0]; }));
                        dradiusTop.Invoke(new MethodInvoker(delegate() { dradiusTop.Value = global.temp_Cycles[1]; }));
                        dradiusRight.Invoke(new MethodInvoker(delegate() { dradiusRight.Value = global.temp_Cycles[2]; }));

                        //brightness level
                        dynamicValueLeft.Invoke(new MethodInvoker(delegate() { dynamicValueLeft.Value = (int)global.dynamicValue[0]; }));
                        dynamicValueTop.Invoke(new MethodInvoker(delegate() { dynamicValueTop.Value = (int)global.dynamicValue[1]; }));
                        dynamicValueRight.Invoke(new MethodInvoker(delegate() { dynamicValueRight.Value = (int)global.dynamicValue[2]; }));

                        //voodoo input
                        viLeft.Invoke(new MethodInvoker(delegate() { viLeft.BackColor = global.cReceivedRGB[0]; }));
                        viTop.Invoke(new MethodInvoker(delegate() { viTop.BackColor = global.cReceivedRGB[1]; }));
                        viRight.Invoke(new MethodInvoker(delegate() { viRight.BackColor = global.cReceivedRGB[2]; }));

                        //voodoo output
                        voLeft.Invoke(new MethodInvoker(delegate() { voLeft.BackColor = Color.FromArgb((int)global.SendByte[0], (int)global.SendByte[3], (int)global.SendByte[6]); }));
                        voTop.Invoke(new MethodInvoker(delegate() { voTop.BackColor = Color.FromArgb((int)global.SendByte[1], (int)global.SendByte[4], (int)global.SendByte[7]); }));
                        voRight.Invoke(new MethodInvoker(delegate() { voRight.BackColor = Color.FromArgb((int)global.SendByte[2], (int)global.SendByte[5], (int)global.SendByte[8]); }));

                        //received rgb
                        ColorLeft.Invoke(new MethodInvoker(delegate() { ColorLeft.BackColor = Color.FromArgb((int)global.SendByte[0], (int)global.SendByte[3], (int)global.SendByte[6]); }));
                        ColorTop.Invoke(new MethodInvoker(delegate() { ColorTop.BackColor = Color.FromArgb((int)global.SendByte[1], (int)global.SendByte[4], (int)global.SendByte[7]); }));
                        ColorRight.Invoke(new MethodInvoker(delegate() { ColorRight.BackColor = Color.FromArgb((int)global.SendByte[2], (int)global.SendByte[5], (int)global.SendByte[8]); }));
                    }
                    catch { }
                }
                // */

                // Colour Compensation
                global.SendByte[0] = (byte)((int)global.SendByte[0] * RedLeft.Value / 255);
                global.SendByte[1] = (byte)((int)global.SendByte[1] * RedTop.Value / 255);
                global.SendByte[2] = (byte)((int)global.SendByte[2] * RedRight.Value / 255);
                global.SendByte[3] = (byte)((int)global.SendByte[3] * GreenLeft.Value / 255);
                global.SendByte[4] = (byte)((int)global.SendByte[4] * GreenTop.Value / 255);
                global.SendByte[5] = (byte)((int)global.SendByte[5] * GreenRight.Value / 255);
                global.SendByte[6] = (byte)((int)global.SendByte[6] * BlueLeft.Value / 255);
                global.SendByte[7] = (byte)((int)global.SendByte[7] * BlueTop.Value / 255);
                global.SendByte[8] = (byte)((int)global.SendByte[8] * BlueRight.Value / 255);
                
                /*
                Thread t = new Thread(new ThreadStart(Send));
                t.Start();
                // */
                Send(); //send the values

                //this.Text = "sending";
            }
            else
            {
                //this.Text = "not sending";
            }

        }






        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool close = false;
            this.TopMost = false;

            if (global.Enabled)
            {
                DisableWorkingUnit();
            }
/*
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "AmbiLED", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    close = true;
                }
            }
            else
            {
                close = true;
            }
*/
            close = true;
            if (close)
            {
                XmlDocument settings = new XmlDataDocument();

                settings.Load(Application.StartupPath + "\\AmbiLED.xml");
                XmlElement root = settings.DocumentElement;
                for (int I = 0; I < root.ChildNodes.Count; I++)
                {
                    if (root.ChildNodes[I].Name == "comport")
                    {
                        root.ChildNodes[I].InnerText = txtPortname.Text;
                    }

                    else if (root.ChildNodes[I].Name == "baudrate")
                    {
                        root.ChildNodes[I].InnerText = serialPort1.BaudRate.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "color")
                    {
                        root.ChildNodes[I].InnerText = global.var_ColorSlider.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "expand")
                    {
                        if (radioButton1.Checked)
                            root.ChildNodes[I].InnerText = "1";
                        else if (radioButton2.Checked)
                            root.ChildNodes[I].InnerText = "2";
                        else
                            root.ChildNodes[I].InnerText = "3";
                    }
                    else if (root.ChildNodes[I].Name == "maxmultiply")
                    {
                        root.ChildNodes[I].InnerText = global.var_MaxMultiply.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "ProgressiveThreshold")
                    {
                        if (ProgressiveThreshold.Checked == true)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "DynamicSmoothRadius")
                    {
                        if (DynamicSmoothRadius.Checked == true)
                        {
                            root.ChildNodes[I].InnerText = "true";
                        }
                        else
                        {
                            root.ChildNodes[I].InnerText = "false";
                        }
                    } 
                    else if (root.ChildNodes[I].Name == "QuantizeLevel")
                    {
                        root.ChildNodes[I].InnerText = QuantizeLevel.Value.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "DarknessThreshold")
                    {
                        root.ChildNodes[I].InnerText = DarknessThreshold.Value.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "enabled")
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
                    else if (root.ChildNodes[I].Name == "mode")
                    {
                        if (global.Mode == 0)
                        {
                            root.ChildNodes[I].InnerText = "movie";
                        }
                        else if (global.Mode == 1)
                        {
                            root.ChildNodes[I].InnerText = "gaming";
                        }
                        else if (global.Mode == 2)
                        {
                            root.ChildNodes[I].InnerText = "10*movie smooth";
                        }
                        else if (global.Mode == 3)
                        {
                            root.ChildNodes[I].InnerText = "True-Cinema +Expansion";
                        }
                        else if (global.Mode == 4)
                        {
                            root.ChildNodes[I].InnerText = "(temp1)";
                        }
                        else if (global.Mode == 5)
                        {
                            root.ChildNodes[I].InnerText = "(temp2)";
                        }
                        else if (global.Mode == 6)
                        {
                            root.ChildNodes[I].InnerText = "(temp3)";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "DynamicControl")
                    {
                        if (global.in_DynamicControl == 0)
                        {
                            root.ChildNodes[I].InnerText = "(HSL)HSB.Brightness";
                        }
                        else if (global.in_DynamicControl == 1)
                        {
                            root.ChildNodes[I].InnerText = "HSV.Value";
                        }
                        else if (global.in_DynamicControl == 2)
                        {
                            root.ChildNodes[I].InnerText = "Scene Difference";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "controller")
                    {
                        if (global.Controller == 0)
                        {
                            root.ChildNodes[I].InnerText = "v1 v2";
                        }
                        else if (global.Controller == 1)
                        {
                            root.ChildNodes[I].InnerText = "v3";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "GammaEvent")
                    {
                        root.ChildNodes[I].InnerText = global.var_GammaEvent.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "AggressiveThreshold")
                    {
                        root.ChildNodes[I].InnerText = global.var_AggressiveThreshold.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "MaxSmoothRadius")
                    {
                        root.ChildNodes[I].InnerText = global.var_MaxSmoothRadius.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "MinSmoothRadius")
                    {
                        root.ChildNodes[I].InnerText = global.var_MinSmoothRadius.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "SlideDelay")
                    {
                        root.ChildNodes[I].InnerText = global.var_SlideDelay.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "DarknessLimit")
                    {
                        root.ChildNodes[I].InnerText = global.var_DarknessLimit.ToString();
                    }
                    else if (root.ChildNodes[I].Name == "DarknessLimitMethod")
                    {
                        if (global.in_DarknessLimitMethod == 0)
                        {
                            root.ChildNodes[I].InnerText = "HSB";
                        }
                        else if (global.in_DarknessLimitMethod == 1)
                        {
                            root.ChildNodes[I].InnerText = "HSV";
                        }
                    }
                    else if (root.ChildNodes[I].Name == "RedLeft")
                        root.ChildNodes[I].InnerText = RedLeft.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedTop")
                        root.ChildNodes[I].InnerText = RedTop.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedRight")
                        root.ChildNodes[I].InnerText = RedRight.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenLeft")
                        root.ChildNodes[I].InnerText = GreenLeft.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenTop")
                        root.ChildNodes[I].InnerText = GreenTop.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenRight")
                        root.ChildNodes[I].InnerText = GreenRight.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueLeft")
                        root.ChildNodes[I].InnerText = BlueLeft.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueTop")
                        root.ChildNodes[I].InnerText = BlueTop.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueRight")
                        root.ChildNodes[I].InnerText = BlueRight.Value.ToString();

                    else if (root.ChildNodes[I].Name == "RedLeftOnStart")
                        root.ChildNodes[I].InnerText = RedLeftOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedTopOnStart")
                        root.ChildNodes[I].InnerText = RedTopOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedRightOnStart")
                        root.ChildNodes[I].InnerText = RedRightOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenLeftOnStart")
                        root.ChildNodes[I].InnerText = GreenLeftOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenTopOnStart")
                        root.ChildNodes[I].InnerText = GreenTopOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenRightOnStart")
                        root.ChildNodes[I].InnerText = GreenRightOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueLeftOnStart")
                        root.ChildNodes[I].InnerText = BlueLeftOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueTopOnStart")
                        root.ChildNodes[I].InnerText = BlueTopOnStart.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueRightOnStart")
                        root.ChildNodes[I].InnerText = BlueRightOnStart.Value.ToString();

                    else if (root.ChildNodes[I].Name == "RedLeftOnExit")
                        root.ChildNodes[I].InnerText = RedLeftOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedTopOnExit")
                        root.ChildNodes[I].InnerText = RedTopOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "RedRightOnExit")
                        root.ChildNodes[I].InnerText = RedRightOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenLeftOnExit")
                        root.ChildNodes[I].InnerText = GreenLeftOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenTopOnExit")
                        root.ChildNodes[I].InnerText = GreenTopOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "GreenRightOnExit")
                        root.ChildNodes[I].InnerText = GreenRightOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueLeftOnExit")
                        root.ChildNodes[I].InnerText = BlueLeftOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueTopOnExit")
                        root.ChildNodes[I].InnerText = BlueTopOnExit.Value.ToString();
                    else if (root.ChildNodes[I].Name == "BlueRightOnExit")
                        root.ChildNodes[I].InnerText = BlueRightOnExit.Value.ToString();

                    else if (root.ChildNodes[I].Name == "GammaLevel")
                        root.ChildNodes[I].InnerText = global.var_GammaValueInt.ToString();

                    else if (root.ChildNodes[I].Name == "Interval")
                        root.ChildNodes[I].InnerText = global.var_Interval.ToString();

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
                    else if (root.ChildNodes[I].Name == "showoutput")
                    {
                        if (ShowOutput.Checked == true)
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
                }
                settings.Save(Application.StartupPath + "\\AmbiLED.xml");

                if (serialPort1.IsOpen == false) OpenSerial();

                SendOnExit();

                serialPort1.Close();
                serialPort1.Dispose();
            }
            else
            {
                e.Cancel = true;
                this.TopMost = true;
            }
        }

        private void StopListening()
        {
            try
            {
                m_socWorker.Close();
                m_socListener.Close();
                global._listening = false;
                c_data = 0;
                _received_d = "";
            }
            catch (SocketException se)
            {
                if (global._net_socket_debug == true) MessageBox.Show(se.Message);
                global._listening = false;
                c_data = 0;
                _received_d = "";
            }
            catch
            {
                global._listening = false;
                c_data = 0;
                _received_d = "";
            }
        }

        private void StartListening()
        {
            try
            {
                //create the listening socket...
                m_socListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, 32890);
                //bind to local IP Address...
                m_socListener.Bind(ipLocal);
                //start listening...
                m_socListener.Listen(4);
                // create the call back for any client connections...
                m_socListener.BeginAccept(new AsyncCallback(OnClientConnect), null);
                global._listening = true;

            }
            catch (SocketException se)
            {
                if (global._net_socket_debug == true) MessageBox.Show(se.Message);
            }
        }

        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                m_socWorker = m_socListener.EndAccept(asyn);

                WaitForData(m_socWorker);
            }
            catch (ObjectDisposedException)
            {
                if (global._net_socket_debug == true) System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
                StopListening();
            }
            catch (SocketException se)
            {
                if (global._net_socket_debug == true) MessageBox.Show(se.Message);
                StopListening();
            }

        }
        public class CSocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1];
        }

        public void WaitForData(System.Net.Sockets.Socket soc)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                CSocketPacket theSocPkt = new CSocketPacket();
                theSocPkt.thisSocket = soc;
                // now start to listen for any data...
                soc.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                if (global._net_socket_debug == true) MessageBox.Show(se.Message);
                StopListening();
            }

        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            bool resetconnection = false;
            try
            {
                CSocketPacket theSockId = (CSocketPacket)asyn.AsyncState;
                //end receive...
                int iRx = 0;
                iRx = theSockId.thisSocket.EndReceive(asyn);
                //char[] chars = new char[iRx + 1];
                //System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                //int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                //System.String szData = new System.String(chars);
                string _receiveddata = System.Text.Encoding.UTF8.GetString(theSockId.dataBuffer, 0, iRx);
                string _hexchar;
                if (_receiveddata == "#") c_data = 1;
                if (c_data > 0)
                {
                    if (_receiveddata == "$")
                    {
                        if (_received_d.Length == (9 * 2))
                            // ComPort.Text = _received_d;
                            for (int I = 0; I < 9; I++)
                            {
                                _hexchar = _received_d[I * 2].ToString() + _received_d[I * 2 + 1].ToString();
                                // Gamma | Event: Input data
                                if (global.var_GammaEvent == 1)
                                {
                                    global.tempReceivedRGB[I] = global.GammaArray[int.Parse(_hexchar, System.Globalization.NumberStyles.HexNumber)];
                                }
                                else
                                {
                                    global.tempReceivedRGB[I] = int.Parse(_hexchar, System.Globalization.NumberStyles.HexNumber);
                                }
                            }

                        if ((_received_d.Length == "clnt_dis".Length) && (_received_d == "clnt_dis"))
                            resetconnection = true;

                        c_data = 0;
                        _received_d = "";

                        VoodooInput();
                        Array.Copy(global.tempReceivedRGB, global.ReceivedRGB, 9);
                        global.trg_Received = true;
                    }
                    else if (_receiveddata != "#")
                    {
                        _received_d = _received_d + _receiveddata;
                    }
                }
                if (resetconnection == true)
                {
                    StopListening();
                    StartListening();
                }
                else
                {
                    WaitForData(m_socWorker);
                }
            }
            catch (ObjectDisposedException)
            {
                if (global._net_socket_debug == true) System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
                StopListening();
            }
            catch (SocketException se)
            {
                if (global._net_socket_debug == true) MessageBox.Show(se.Message);
                StopListening();
            }
        }

        private string HexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        private void Send() //send out the colors
        {
            if (serialPort1.IsOpen)
            {
                if (global.Controller == 1)
                {
                    checksum = 0;
                    global.SendData[0] = global.v3_ident;
                    for (int I = 0; I < 9; I++)
                    {
                        global.SendData[I + 1] = global.SendByte[I];
                        checksum += global.SendByte[I];
                    }
                    checksum = (ushort)(65535 - checksum);
                    string s_checksum = HexString2Ascii(checksum.ToString("X4"));

                    global.SendData[10] = Convert.ToByte(s_checksum[0]);
                    global.SendData[11] = Convert.ToByte(s_checksum[1]);

                    serialPort1.Write(global.SendData, 0, 12);

                    if (global.ShowOutput == true && this.WindowState != FormWindowState.Minimized)
                    {
                        string datasend = "";
                        for (int I = 0; I < 12; I++)
                        {
                            datasend += global.SendData[I].ToString("X2") + " ";
                        }
                        label23.Text = datasend;
                    }
                }
                else
                {
                    serialPort1.Write(global.SendByte, 0, 9);
                    if (global.ShowOutput == true && this.WindowState != FormWindowState.Minimized)
                    {
                        string datasend = "";
                        for (int I = 0; I < 9; I++)
                        {
                            datasend += global.SendByte[I].ToString("X2") + " ";
                        }
                        label23.Text = datasend;
                    }
                }
            }
        }

        private bool OpenSerial()
        {
            try
            {
                txtPortname.Enabled = false;
                comboBaud.Enabled = false;
                serialPort1.PortName = txtPortname.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBaud.Text, 10);
                serialPort1.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Error opening com port", "Error");
                return false;
            }
        }

        private void SendOnExit()
        {
            Array.Clear(global.SendByte, 0, 9);

            global.SendByte[0] = (byte)((int)RedLeftOnExit.Value);
            global.SendByte[1] = (byte)((int)RedTopOnExit.Value);
            global.SendByte[2] = (byte)((int)RedRightOnExit.Value);

            global.SendByte[3] = (byte)((int)GreenLeftOnExit.Value);
            global.SendByte[4] = (byte)((int)GreenTopOnExit.Value);
            global.SendByte[5] = (byte)((int)GreenRightOnExit.Value);

            global.SendByte[6] = (byte)((int)BlueLeftOnExit.Value);
            global.SendByte[7] = (byte)((int)BlueTopOnExit.Value);
            global.SendByte[8] = (byte)((int)BlueRightOnExit.Value);

            System.Threading.Thread.Sleep(100);

            Send(); //send the values

            /*
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(global.SendByte, 0, 9); //send 9 zero chars to turn off the lights

                while (serialPort1.BytesToWrite != 0)//wait for the serial port to finish sending
                {
                }
                serialPort1.Close();//close the serial port
            }
            serialPort1.Dispose();
             */
        }

        //new
        private void SendOnStart()
        {
            Array.Clear(global.SendByte, 0, 9);

            global.SendByte[0] = (byte)((int)RedLeftOnStart.Value);
            global.SendByte[1] = (byte)((int)RedTopOnStart.Value);
            global.SendByte[2] = (byte)((int)RedRightOnStart.Value);

            global.SendByte[3] = (byte)((int)GreenLeftOnStart.Value);
            global.SendByte[4] = (byte)((int)GreenTopOnStart.Value);
            global.SendByte[5] = (byte)((int)GreenRightOnStart.Value);

            global.SendByte[6] = (byte)((int)BlueLeftOnStart.Value);
            global.SendByte[7] = (byte)((int)BlueTopOnStart.Value);
            global.SendByte[8] = (byte)((int)BlueRightOnStart.Value);

            Array.Copy(global.SendByte, global.ReceivedRGB, 9);
            Array.Copy(global.SendByte, global.OldSendByte, 9);
            Array.Copy(global.SendByte, global.PreviousColor10, 9);
            Array.Copy(global.SendByte, global.PreviousColor9, 9);
            Array.Copy(global.SendByte, global.PreviousColor8, 9);
            Array.Copy(global.SendByte, global.PreviousColor7, 9);
            Array.Copy(global.SendByte, global.PreviousColor6, 9);
            Array.Copy(global.SendByte, global.PreviousColor5, 9);
            Array.Copy(global.SendByte, global.PreviousColor4, 9);
            Array.Copy(global.SendByte, global.PreviousColor3, 9);
            Array.Copy(global.SendByte, global.PreviousColor2, 9);
            Array.Copy(global.SendByte, global.PreviousColor, 9);
            Array.Copy(global.SendByte, global.CurrentColor, 9);

            c_data = 0;
            _received_d = "";

            global.Cycles[0] = global.var_MaxSmoothRadius - 1;
            global.Cycles[1] = global.var_MaxSmoothRadius - 1;
            global.Cycles[2] = global.var_MaxSmoothRadius - 1;

            System.Threading.Thread.Sleep(0);

            Send(); //send the values

        }
        //

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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void DoRequest()
        {
            if (global.Enabled && global.ReadyToGet)
            {
                StartMeasureTime = DateTime.Now;
                global.ReadyToGet = false;
                VoodooOutput();
                Callback();
            }
        }

        void Callback()
        {
            if (!global._listening) StartListening();

            if (!global.trg_Received)
            {
                // Measure time
                EndMeasureTime = DateTime.Now;
                diffMeasure = EndMeasureTime - StartMeasureTime;

                if (diffMeasure < TimeSpan.FromMilliseconds(global.var_Interval))
                {
                    SleepTime = TimeSpan.FromMilliseconds(global.var_Interval) - diffMeasure;
                }
                else
                {
                    SleepTime = TimeSpan.FromMilliseconds(0);
                }

                // Sleep Interval..
                Thread.Sleep(SleepTime);
            }
            else
            {
                global.trg_Received = false;
                if ((this.WindowState != FormWindowState.Minimized) && (ShowFPS.Checked))
                    FPS_Received = Utility.CalculateFrameRate_2().ToString();
            }

            if ((this.WindowState != FormWindowState.Minimized) && (ShowFPS.Checked))
            {
                FPS_Cycles = Utility.CalculateFrameRate_1().ToString();
                //used to protect from error while user push mainform close
                try
                {
                    ShowFPS.Invoke(new MethodInvoker(delegate() { ShowFPS.Text = "FPS: " + FPS_Received + "/" + FPS_Cycles; }));
                    label68.Invoke(new MethodInvoker(delegate() { label68.Text = diffMeasure.ToString(); }));
                    label69.Invoke(new MethodInvoker(delegate() { label69.Text = SleepTime.ToString(); }));
                }
                catch { }
            }

            global.ReadyToGet = true;

            Thread t = new Thread(new ThreadStart(DoRequest));
            t.Start();
        }

        private void DisableWorkingUnit()
        {
            if (global.Enabled)
            {
                // Enabled?
                global.Enabled = false;
                // Reset Trigger Run status
                global.TriggeredRun = false;


                if (global._listening == true) StopListening();
                //DWM.DwmEnableComposition(true);

                this.Text = "AmbiLED.NET v3 DISABLED";
                EnableBtn.Text = "Enable";
                disableToolStripMenuItem.Text = "Enable";
                // DISABLE LOOP
                //Maybe some fadeout procedure before clearing?
                //Fade -------------
                Array.Clear(global.SendByte, 0, 9);
                /*
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(global.SendByte, 0, 9); //send 9 zero chars to turn off the lights
                    serialPort1.Close();
                }
                // */
                txtPortname.Enabled = true;
                comboBaud.Enabled = true;
                SendOnStart();
                serialPort1.Close();
                serialPort1.Dispose();
            }
        }

        private void EnableWorkingUnit()
        {
            if (!global.Enabled)
            {
                // Enabled?
                global.Enabled = true;

                if (global._listening == false) {
                    StartListening();
                } else {
                    DisableWorkingUnit();
                }
                //DWM.DwmEnableComposition(false);

                if (serialPort1.IsOpen == false) OpenSerial();

                Array.Clear(global.CurrentColor, 0, 9);
                EnableBtn.Text = "Disable";
                disableToolStripMenuItem.Text = "Disable";
                this.Text = "AmbiLED.NET v3";
                DoRequest();
            }
        }

        private void EnableBtn_Click(object sender, EventArgs e)
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        private void ModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModeCombo.Text == "Movie")
            {
                global.Mode = 0;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "Movie";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo.Text == "Gaming")
            {
                global.Mode = 1;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                ModeCombo2.Text = "Gaming";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo.Text == "10*Movie smooth")
            {
                global.Mode = 2;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "10*Movie smooth";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo.Text == "True-Cinema +Expansion")
            {
                global.Mode = 3;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "True-Cinema +Expansion";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo.Text == "(temp1)")
            {
                global.Mode = 4;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp1)";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo.Text == "(temp2)")
            {
                global.Mode = 5;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp2)";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo.Text == "(temp3)")
            {
                global.Mode = 6;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp3)";
                label32.Visible = true;
                label38.Visible = true;
            }
        }

        private void ModeCombo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModeCombo2.Text == "Movie")
            {
                global.Mode = 0;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo.Text = "Movie";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo2.Text == "Gaming")
            {
                global.Mode = 1;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                ModeCombo.Text = "Gaming";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo2.Text == "10*Movie smooth")
            {
                global.Mode = 2;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo.Text = "10*Movie smooth";
                label32.Visible = false;
                label38.Visible = false;
            }
            else if (ModeCombo2.Text == "True-Cinema +Expansion")
            {
                global.Mode = 3;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo.Text = "True-Cinema +Expansion";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo2.Text == "(temp1)")
            {
                global.Mode = 4;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp1)";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo2.Text == "(temp2)")
            {
                global.Mode = 5;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp2)";
                label32.Visible = true;
                label38.Visible = true;
            }
            else if (ModeCombo2.Text == "(temp3)")
            {
                global.Mode = 6;
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
                ModeCombo2.Text = "(temp3)";
                label32.Visible = true;
                label38.Visible = true;
            }
        }


        public static Bitmap CreateThumbnail(Bitmap loBMP, int lnWidth, int lnHeight)
        {

            Bitmap bmpOut = null;

            try
            {

//                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;

                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
/*
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;
 */
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
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
//                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
//                g.InterpolationMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
//                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }

        private void IntelliInterval_ValueChanged(object sender, EventArgs e)
        {
            global.var_Interval = (int)IntelliInterval.Value;
        }

        private void RedTopOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnExit.BackColor = Color.FromArgb((int)RedTopOnExit.Value, (int)GreenTopOnExit.Value, (int)BlueTopOnExit.Value);
        }

        private void GreenTopOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnExit.BackColor = Color.FromArgb((int)RedTopOnExit.Value, (int)GreenTopOnExit.Value, (int)BlueTopOnExit.Value);
        }

        private void BlueTopOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnExit.BackColor = Color.FromArgb((int)RedTopOnExit.Value, (int)GreenTopOnExit.Value, (int)BlueTopOnExit.Value);
        }

        private void RedLeftOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnExit.BackColor = Color.FromArgb((int)RedLeftOnExit.Value, (int)GreenLeftOnExit.Value, (int)BlueLeftOnExit.Value);
        }

        private void GreenLeftOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnExit.BackColor = Color.FromArgb((int)RedLeftOnExit.Value, (int)GreenLeftOnExit.Value, (int)BlueLeftOnExit.Value);
        }

        private void BlueLeftOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnExit.BackColor = Color.FromArgb((int)RedLeftOnExit.Value, (int)GreenLeftOnExit.Value, (int)BlueLeftOnExit.Value);
        }

        private void RedRightOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnExit.BackColor = Color.FromArgb((int)RedRightOnExit.Value, (int)GreenRightOnExit.Value, (int)BlueRightOnExit.Value);
        }

        private void GreenRightOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnExit.BackColor = Color.FromArgb((int)RedRightOnExit.Value, (int)GreenRightOnExit.Value, (int)BlueRightOnExit.Value);
        }

        private void BlueRightOnExit_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnExit.BackColor = Color.FromArgb((int)RedRightOnExit.Value, (int)GreenRightOnExit.Value, (int)BlueRightOnExit.Value);
        }

        private void Colorslider_ValueChanged(object sender, EventArgs e)
        {
            global.var_ColorSlider = (int)Colorslider.Value;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://qnapclub.pl/qnas/AmbiLED/");
        }

        private void RedTopOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnStart.BackColor = Color.FromArgb((int)RedTopOnStart.Value, (int)GreenTopOnStart.Value, (int)BlueTopOnStart.Value);
        }

        private void GreenTopOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnStart.BackColor = Color.FromArgb((int)RedTopOnStart.Value, (int)GreenTopOnStart.Value, (int)BlueTopOnStart.Value);
        }

        private void BlueTopOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorTopOnStart.BackColor = Color.FromArgb((int)RedTopOnStart.Value, (int)GreenTopOnStart.Value, (int)BlueTopOnStart.Value);
        }

        private void RedLeftOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnStart.BackColor = Color.FromArgb((int)RedLeftOnStart.Value, (int)GreenLeftOnStart.Value, (int)BlueLeftOnStart.Value);
        }

        private void GreenLeftOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnStart.BackColor = Color.FromArgb((int)RedLeftOnStart.Value, (int)GreenLeftOnStart.Value, (int)BlueLeftOnStart.Value);
        }

        private void BlueLeftOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorLeftOnStart.BackColor = Color.FromArgb((int)RedLeftOnStart.Value, (int)GreenLeftOnStart.Value, (int)BlueLeftOnStart.Value);
        }

        private void RedRightOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnStart.BackColor = Color.FromArgb((int)RedRightOnStart.Value, (int)GreenRightOnStart.Value, (int)BlueRightOnStart.Value);
        }

        private void GreenRightOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnStart.BackColor = Color.FromArgb((int)RedRightOnStart.Value, (int)GreenRightOnStart.Value, (int)BlueRightOnStart.Value);
        }

        private void BlueRightOnStart_ValueChanged(object sender, EventArgs e)
        {
            ColorRightOnStart.BackColor = Color.FromArgb((int)RedRightOnStart.Value, (int)GreenRightOnStart.Value, (int)BlueRightOnStart.Value);
        }

        private void AutoDetect_Tick(object sender, EventArgs e)
        {
            bool foundit = false;
            Process[] prs = Process.GetProcesses();
            foreach (Process proces in prs)
            {
                string[] split = ProcessName.Text.Split(new Char[] { '|' });

                foreach (string s in split)
                    if (proces.ProcessName == s.Trim())
                        foundit = true;
            }

            if (foundit && global.Enabled == false && AutoEnable.Checked)
            {
                global.TriggeredRun = true;
                //DWM.DwmEnableComposition(false);
                EnableWorkingUnit();
            }
            if (foundit == false && global.TriggeredRun == true)
            {
                //DWM.DwmEnableComposition(true);
                DisableWorkingUnit();
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

        private void Controller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller.Text == "v1 v2")
                global.Controller = 0;
            else if (Controller.Text == "v3")
                global.Controller = 1;
        }

        private void ShowOutput_CheckedChanged(object sender, EventArgs e)
        {
            global.ShowOutput = ShowOutput.Checked;
        }

        private void BuildGamma()
        {
            for (int i = 0; i < 256; ++i)
            {
                global.GammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / global.var_GammaValue)) + 0.5));
            }
        }

        private void DisplayGammaValues()
        {
            string sGammeTable = "";
            byte c = 0;
            for (int i = 0; i < 256; ++i)
            {
                sGammeTable += global.GammaArray[i].ToString("000");
                if (i < 255) sGammeTable += " ";
                if (c >= 15)
                {
                    sGammeTable += "\r\n";
                    c = 0;
                }
                else
                {
                    c++;
                }
            }
            GammaTable.Text = sGammeTable;
        }

        private void UpdateGamma()
        {
            global.var_GammaValueInt = GammaValue.Value;
            global.var_GammaValue = (float)global.var_GammaValueInt / 100;
            GammaLevel.Text = global.var_GammaValue.ToString("0.00");
            BuildGamma();
            DisplayGammaValues();
        }

        private void GammaValue_ValueChanged(object sender, EventArgs e)
        {
            UpdateGamma();
        }

        private void GammaEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GammaEvent.Text == "No gamma")
                global.var_GammaEvent = 0;
            else if (GammaEvent.Text == "Input data")
                global.var_GammaEvent = 1;
            else if (GammaEvent.Text == "Output data")
                global.var_GammaEvent = 2;
        }
        private void UpdateGammaEvent()
        {
            if (global.var_GammaEvent == 0)
            {
                GammaEvent.Text = "No gamma";
            }
            else if (global.var_GammaEvent == 1)
            {
                GammaEvent.Text = "Input data";
            }
            else if (global.var_GammaEvent == 2)
            {
                GammaEvent.Text = "Output data";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            global.var_MaxMultiply = (int)numericUpDown1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                global.var_ExpandMode = 1;
            }
            else if (radioButton2.Checked)
            {
                global.var_ExpandMode = 2;
            }
            else
            {
                global.var_ExpandMode = 3;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                global.var_ExpandMode = 1;
            }
            else if (radioButton2.Checked)
            {
                global.var_ExpandMode = 2;
            }
            else
            {
                global.var_ExpandMode = 3;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                global.var_ExpandMode = 1;
            }
            else if (radioButton2.Checked)
            {
                global.var_ExpandMode = 2;
            }
            else
            {
                global.var_ExpandMode = 3;
            }
        }

        private void QuantizeLevel_ValueChanged(object sender, EventArgs e)
        {
            global.var_QuantizeLevel = (int)QuantizeLevel.Value;
        }

        private void ProgressiveThreshold_CheckedChanged(object sender, EventArgs e)
        {
            global._ProgressiveThreshold = ProgressiveThreshold.Checked;
        }

        private void DarknessThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            DarknessThreshold.Value = (int)DarknessThresholdUpDown.Value;
            global.var_DarknessThreshold = (int)DarknessThresholdUpDown.Value;
        }

        private void DarknessThreshold_Scroll(object sender, EventArgs e)
        {
            DarknessThresholdUpDown.Value = DarknessThreshold.Value;
            global.var_DarknessThreshold = DarknessThreshold.Value;
        }

        private void AggressiveThreshold_ValueChanged(object sender, EventArgs e)
        {
            AggressiveThresholdUpDown.Value = AggressiveThreshold.Value;
            global.var_AggressiveThreshold = AggressiveThreshold.Value;
        }

        private void AggressiveThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            AggressiveThreshold.Value = (int)AggressiveThresholdUpDown.Value;
            global.var_AggressiveThreshold = AggressiveThreshold.Value;
        }

        private void MaxSmoothRadiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            MaxSmoothRadius.Value = (int)MaxSmoothRadiusUpDown.Value;
            global.var_MaxSmoothRadius = MaxSmoothRadius.Value;
        }

        private void MaxSmoothRadius_ValueChanged(object sender, EventArgs e)
        {
            MaxSmoothRadiusUpDown.Value = MaxSmoothRadius.Value;
            global.var_MaxSmoothRadius = MaxSmoothRadius.Value;
        }

        private void DynamicRadiusSlideDelayUpDown_ValueChanged(object sender, EventArgs e)
        {
            DynamicRadiusSlideDelay.Value = (int)DynamicRadiusSlideDelayUpDown.Value;
            global.DynamicRadius = DynamicSmoothRadius.Checked;
        }

        private void DynamicRadiusSlideDelay_ValueChanged(object sender, EventArgs e)
        {
            DynamicRadiusSlideDelayUpDown.Value = DynamicRadiusSlideDelay.Value;
            global.var_SlideDelay = DynamicRadiusSlideDelay.Value;
        }

        private void DynamicSmoothRadius_CheckedChanged(object sender, EventArgs e)
        {
            global.DynamicRadius = DynamicSmoothRadius.Checked;
            DynamicRadiusSlideDelay.Enabled = global.DynamicRadius;
            DynamicRadiusSlideDelayUpDown.Enabled = global.DynamicRadius;
            MinSmoothRadius.Enabled = global.DynamicRadius;
            MinSmoothRadiusUpDown.Enabled = global.DynamicRadius;
            DynamicControl.Enabled = global.DynamicRadius;
        }

        private void MinSmoothRadiusUpDown_ValueChanged(object sender, EventArgs e)
        {
            MinSmoothRadius.Value = (int)MinSmoothRadiusUpDown.Value;
            global.var_MinSmoothRadius = MinSmoothRadius.Value;
        }

        private void MinSmoothRadius_ValueChanged(object sender, EventArgs e)
        {
            MinSmoothRadiusUpDown.Value = MinSmoothRadius.Value;
            global.var_MinSmoothRadius = MinSmoothRadius.Value;
        }

        private void DynamicControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DynamicControl.Text == "(HSL)HSB.Brightness")
                global.in_DynamicControl = 0;
            else if (DynamicControl.Text == "HSV.Value")
                global.in_DynamicControl = 1;
            else if (DynamicControl.Text == "Scene Difference")
                global.in_DynamicControl = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hwZones = 3;
            int hwColours = 3;
            int hwChannels = hwZones * hwColours;

            int hwBytesPerSecond = Convert.ToInt32(comboBaud.Text, 10) / 8;
            //                   = 9600/8 = 1200    (divided by 8 (bits))

            double hwCyclesPerSecond = hwBytesPerSecond / hwChannels;
            //                       = 1200/9 = ~133

            double hwSafeCyclesPerSecond = (int)(hwCyclesPerSecond * 0.85);
            //                           =  ~133 - 15%
            // (safe 15% allows to perform Aggressive Attack immediately)

            // Calculate IntelliInterval Speed
            global.var_Interval = (int)(1000 / hwSafeCyclesPerSecond);
            //                  = (1sec / Cycles)

            if (global.var_Interval < 1) global.var_Interval = 1;
            IntelliInterval.Value = global.var_Interval;

            int defMovieFrameRate = 30;
            double swRealFrames = defMovieFrameRate / 2;
            //               = 30 / 2 = 15
            //  Display 50% real frames

            global.var_MaxSmoothRadius = (int)(hwCyclesPerSecond / swRealFrames);
            if (global.var_MaxSmoothRadius < 1) global.var_MaxSmoothRadius = 1;
            MaxSmoothRadius.Value = global.var_MaxSmoothRadius;
            MaxSmoothRadiusUpDown.Value = global.var_MaxSmoothRadius;

            global.var_MinSmoothRadius = global.var_MaxSmoothRadius;
            MinSmoothRadius.Value = global.var_MinSmoothRadius;
            MinSmoothRadiusUpDown.Value = global.var_MinSmoothRadius;

            global.var_SlideDelay = 1;
            DynamicRadiusSlideDelay.Value = global.var_SlideDelay;
            DynamicRadiusSlideDelayUpDown.Value = global.var_SlideDelay;
        }

        private void DarknessLimit_ValueChanged(object sender, EventArgs e)
        {
            DarknessLimitUpDown.Value = DarknessLimit.Value;
            global.var_DarknessLimit = DarknessLimit.Value;
        }

        private void DarknessLimitUpDown_ValueChanged(object sender, EventArgs e)
        {
            DarknessLimit.Value = (int)DarknessLimitUpDown.Value;
            global.var_DarknessLimit = DarknessLimit.Value;
        }

        private void DarknessLimitMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DarknessLimitMethod.Text == "HSB")
            {
                global.in_DarknessLimitMethod = 0;
            }
            else if (DarknessLimitMethod.Text == "HSV")
            {
                global.in_DarknessLimitMethod = 1;
            }
        }
    }
}