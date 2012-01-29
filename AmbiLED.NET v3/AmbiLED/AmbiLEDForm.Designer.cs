namespace AmbiLED
{
    partial class AmbiLEDForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbiLEDForm));
            this.ColorRight = new System.Windows.Forms.PictureBox();
            this.ColorTop = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtPortname = new System.Windows.Forms.TextBox();
            this.ComPort = new System.Windows.Forms.Label();
            this.comboBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableBtn = new System.Windows.Forms.Button();
            this.RedTop = new System.Windows.Forms.NumericUpDown();
            this.GreenTop = new System.Windows.Forms.NumericUpDown();
            this.BlueTop = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BlueRight = new System.Windows.Forms.NumericUpDown();
            this.GreenRight = new System.Windows.Forms.NumericUpDown();
            this.RedRight = new System.Windows.Forms.NumericUpDown();
            this.gpComPort = new System.Windows.Forms.GroupBox();
            this.ShowOutput = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ProcessName = new System.Windows.Forms.TextBox();
            this.AutoEnable = new System.Windows.Forms.CheckBox();
            this.Controller = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.gpTopOnExit = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.BlueTopOnExit = new System.Windows.Forms.NumericUpDown();
            this.GreenTopOnExit = new System.Windows.Forms.NumericUpDown();
            this.RedTopOnExit = new System.Windows.Forms.NumericUpDown();
            this.ColorTopOnExit = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.BlueLeftOnExit = new System.Windows.Forms.NumericUpDown();
            this.GreenLeftOnExit = new System.Windows.Forms.NumericUpDown();
            this.RedLeftOnExit = new System.Windows.Forms.NumericUpDown();
            this.ColorLeftOnExit = new System.Windows.Forms.PictureBox();
            this.ColorRightOnExit = new System.Windows.Forms.PictureBox();
            this.RedRightOnExit = new System.Windows.Forms.NumericUpDown();
            this.GreenRightOnExit = new System.Windows.Forms.NumericUpDown();
            this.BlueRightOnExit = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ColorLeft = new System.Windows.Forms.PictureBox();
            this.RedLeft = new System.Windows.Forms.NumericUpDown();
            this.GreenLeft = new System.Windows.Forms.NumericUpDown();
            this.BlueLeft = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BlueRightOnStart = new System.Windows.Forms.NumericUpDown();
            this.GreenRightOnStart = new System.Windows.Forms.NumericUpDown();
            this.RedRightOnStart = new System.Windows.Forms.NumericUpDown();
            this.ColorRightOnStart = new System.Windows.Forms.PictureBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BlueLeftOnStart = new System.Windows.Forms.NumericUpDown();
            this.GreenLeftOnStart = new System.Windows.Forms.NumericUpDown();
            this.RedLeftOnStart = new System.Windows.Forms.NumericUpDown();
            this.ColorLeftOnStart = new System.Windows.Forms.PictureBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.BlueTopOnStart = new System.Windows.Forms.NumericUpDown();
            this.GreenTopOnStart = new System.Windows.Forms.NumericUpDown();
            this.RedTopOnStart = new System.Windows.Forms.NumericUpDown();
            this.ColorTopOnStart = new System.Windows.Forms.PictureBox();
            this.AutoDetect = new System.Windows.Forms.Timer(this.components);
            this.GammaPage = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.GammaEvent = new System.Windows.Forms.ComboBox();
            this.GammaTable = new System.Windows.Forms.RichTextBox();
            this.GammaLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GammaValue = new System.Windows.Forms.TrackBar();
            this.VoodooPage = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.voRight = new System.Windows.Forms.PictureBox();
            this.voLeft = new System.Windows.Forms.PictureBox();
            this.voTop = new System.Windows.Forms.PictureBox();
            this.viRight = new System.Windows.Forms.PictureBox();
            this.viLeft = new System.Windows.Forms.PictureBox();
            this.viTop = new System.Windows.Forms.PictureBox();
            this.label71 = new System.Windows.Forms.Label();
            this.ShowDebugDiag = new System.Windows.Forms.CheckBox();
            this.cRight = new System.Windows.Forms.PictureBox();
            this.cLeft = new System.Windows.Forms.PictureBox();
            this.cTop = new System.Windows.Forms.PictureBox();
            this.label70 = new System.Windows.Forms.Label();
            this.dradiusRight = new System.Windows.Forms.NumericUpDown();
            this.dradiusTop = new System.Windows.Forms.NumericUpDown();
            this.dradiusLeft = new System.Windows.Forms.NumericUpDown();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.dynamicValueRight = new System.Windows.Forms.NumericUpDown();
            this.dynamicValueTop = new System.Windows.Forms.NumericUpDown();
            this.dynamicValueLeft = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.ShowFPS = new System.Windows.Forms.CheckBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.radiusRight = new System.Windows.Forms.NumericUpDown();
            this.radiusTop = new System.Windows.Forms.NumericUpDown();
            this.radiusLeft = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.DynamicControl = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.MinSmoothRadiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.MinSmoothRadius = new System.Windows.Forms.TrackBar();
            this.DynamicRadiusSlideDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.DynamicRadiusSlideDelay = new System.Windows.Forms.TrackBar();
            this.AggressiveIndicator = new System.Windows.Forms.Label();
            this.Colorslider = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.MaxSmoothRadiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.MaxSmoothRadius = new System.Windows.Forms.TrackBar();
            this.DynamicSmoothRadius = new System.Windows.Forms.CheckBox();
            this.AggressiveThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.AggressiveThreshold = new System.Windows.Forms.TrackBar();
            this.label30 = new System.Windows.Forms.Label();
            this.ModeCombo2 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.IntelliInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DarknessLimitMethod = new System.Windows.Forms.ComboBox();
            this.DarknessLimitUpDown = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.DarknessLimit = new System.Windows.Forms.TrackBar();
            this.DarknessThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.QuantizeLevel = new System.Windows.Forms.NumericUpDown();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label58 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.DarknessThreshold = new System.Windows.Forms.TrackBar();
            this.ProgressiveThreshold = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LightsSettings = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTop)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRight)).BeginInit();
            this.gpComPort.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gpTopOnExit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTopOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTopOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTopOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTopOnExit)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeftOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeftOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeftOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeftOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRightOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRightOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRightOnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRightOnExit)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeft)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRightOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRightOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRightOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRightOnStart)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeftOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeftOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeftOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeftOnStart)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTopOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTopOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTopOnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTopOnStart)).BeginInit();
            this.GammaPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GammaValue)).BeginInit();
            this.VoodooPage.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusLeft)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSmoothRadiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSmoothRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicRadiusSlideDelayUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicRadiusSlideDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Colorslider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSmoothRadiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSmoothRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggressiveThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggressiveThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntelliInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessLimitUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantizeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessThreshold)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.LightsSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColorRight
            // 
            this.ColorRight.Location = new System.Drawing.Point(101, 17);
            this.ColorRight.Name = "ColorRight";
            this.ColorRight.Size = new System.Drawing.Size(51, 72);
            this.ColorRight.TabIndex = 3;
            this.ColorRight.TabStop = false;
            // 
            // ColorTop
            // 
            this.ColorTop.Location = new System.Drawing.Point(101, 19);
            this.ColorTop.Name = "ColorTop";
            this.ColorTop.Size = new System.Drawing.Size(51, 72);
            this.ColorTop.TabIndex = 4;
            this.ColorTop.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "com4";
            // 
            // txtPortname
            // 
            this.txtPortname.Location = new System.Drawing.Point(75, 16);
            this.txtPortname.Name = "txtPortname";
            this.txtPortname.Size = new System.Drawing.Size(60, 20);
            this.txtPortname.TabIndex = 46;
            this.txtPortname.Text = "COM3";
            // 
            // ComPort
            // 
            this.ComPort.AutoSize = true;
            this.ComPort.Location = new System.Drawing.Point(11, 19);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(58, 13);
            this.ComPort.TabIndex = 47;
            this.ComPort.Text = "Port name:";
            // 
            // comboBaud
            // 
            this.comboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBaud.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBaud.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.comboBaud.Location = new System.Drawing.Point(75, 44);
            this.comboBaud.Name = "comboBaud";
            this.comboBaud.Size = new System.Drawing.Size(60, 21);
            this.comboBaud.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Baudrate:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AmbiLED";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeCombo,
            this.toolStripSeparator1,
            this.disableToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(281, 81);
            // 
            // ModeCombo
            // 
            this.ModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeCombo.Items.AddRange(new object[] {
            "Gaming",
            "Movie",
            "10*Movie smooth",
            "True-Cinema +Expansion",
            "(temp1)",
            "(temp2)",
            "(temp3)"});
            this.ModeCombo.Name = "ModeCombo";
            this.ModeCombo.Size = new System.Drawing.Size(220, 23);
            this.ModeCombo.SelectedIndexChanged += new System.EventHandler(this.ModeCombo_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.disableToolStripMenuItem.Text = "Enable/Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EnableBtn
            // 
            this.EnableBtn.Location = new System.Drawing.Point(14, 123);
            this.EnableBtn.Name = "EnableBtn";
            this.EnableBtn.Size = new System.Drawing.Size(227, 146);
            this.EnableBtn.TabIndex = 52;
            this.EnableBtn.Text = "Enable";
            this.EnableBtn.UseVisualStyleBackColor = true;
            this.EnableBtn.Click += new System.EventHandler(this.EnableBtn_Click);
            // 
            // RedTop
            // 
            this.RedTop.Location = new System.Drawing.Point(50, 19);
            this.RedTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedTop.Name = "RedTop";
            this.RedTop.Size = new System.Drawing.Size(45, 20);
            this.RedTop.TabIndex = 56;
            this.RedTop.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // GreenTop
            // 
            this.GreenTop.Location = new System.Drawing.Point(50, 45);
            this.GreenTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenTop.Name = "GreenTop";
            this.GreenTop.Size = new System.Drawing.Size(45, 20);
            this.GreenTop.TabIndex = 57;
            this.GreenTop.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // BlueTop
            // 
            this.BlueTop.Location = new System.Drawing.Point(50, 71);
            this.BlueTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueTop.Name = "BlueTop";
            this.BlueTop.Size = new System.Drawing.Size(45, 20);
            this.BlueTop.TabIndex = 58;
            this.BlueTop.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Red:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Green:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Blue:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Blue:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Green:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Red:";
            // 
            // BlueRight
            // 
            this.BlueRight.Location = new System.Drawing.Point(48, 71);
            this.BlueRight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueRight.Name = "BlueRight";
            this.BlueRight.Size = new System.Drawing.Size(45, 20);
            this.BlueRight.TabIndex = 64;
            this.BlueRight.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // GreenRight
            // 
            this.GreenRight.Location = new System.Drawing.Point(48, 45);
            this.GreenRight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenRight.Name = "GreenRight";
            this.GreenRight.Size = new System.Drawing.Size(45, 20);
            this.GreenRight.TabIndex = 63;
            this.GreenRight.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // RedRight
            // 
            this.RedRight.Location = new System.Drawing.Point(48, 19);
            this.RedRight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedRight.Name = "RedRight";
            this.RedRight.Size = new System.Drawing.Size(45, 20);
            this.RedRight.TabIndex = 62;
            this.RedRight.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // gpComPort
            // 
            this.gpComPort.Controls.Add(this.ShowOutput);
            this.gpComPort.Controls.Add(this.label32);
            this.gpComPort.Controls.Add(this.label23);
            this.gpComPort.Controls.Add(this.button1);
            this.gpComPort.Controls.Add(this.ProcessName);
            this.gpComPort.Controls.Add(this.AutoEnable);
            this.gpComPort.Controls.Add(this.Controller);
            this.gpComPort.Controls.Add(this.label2);
            this.gpComPort.Controls.Add(this.comboBaud);
            this.gpComPort.Controls.Add(this.ComPort);
            this.gpComPort.Controls.Add(this.txtPortname);
            this.gpComPort.Controls.Add(this.EnableBtn);
            this.gpComPort.Location = new System.Drawing.Point(881, 12);
            this.gpComPort.Name = "gpComPort";
            this.gpComPort.Size = new System.Drawing.Size(255, 371);
            this.gpComPort.TabIndex = 80;
            this.gpComPort.TabStop = false;
            this.gpComPort.Text = "Com Port settings";
            // 
            // ShowOutput
            // 
            this.ShowOutput.AutoSize = true;
            this.ShowOutput.Location = new System.Drawing.Point(14, 100);
            this.ShowOutput.Name = "ShowOutput";
            this.ShowOutput.Size = new System.Drawing.Size(52, 17);
            this.ShowOutput.TabIndex = 56;
            this.ShowOutput.Text = "Data:";
            this.ShowOutput.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 74);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 13);
            this.label32.TabIndex = 57;
            this.label32.Text = "MoMoLight:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.Location = new System.Drawing.Point(72, 101);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 13);
            this.label23.TabIndex = 55;
            this.label23.Text = "?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 49);
            this.button1.TabIndex = 59;
            this.button1.Text = "Recalc Voodoo Speed Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProcessName
            // 
            this.ProcessName.Location = new System.Drawing.Point(14, 294);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(227, 20);
            this.ProcessName.TabIndex = 58;
            this.ProcessName.Text = "mpc-hc";
            // 
            // AutoEnable
            // 
            this.AutoEnable.AutoSize = true;
            this.AutoEnable.Checked = true;
            this.AutoEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoEnable.Location = new System.Drawing.Point(14, 275);
            this.AutoEnable.Name = "AutoEnable";
            this.AutoEnable.Size = new System.Drawing.Size(166, 17);
            this.AutoEnable.TabIndex = 56;
            this.AutoEnable.Text = "Trigger Run <- Process.Name";
            this.AutoEnable.UseVisualStyleBackColor = true;
            this.AutoEnable.CheckedChanged += new System.EventHandler(this.AutoEnable_CheckedChanged);
            // 
            // Controller
            // 
            this.Controller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controller.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Controller.Items.AddRange(new object[] {
            "v1 v2",
            "v3"});
            this.Controller.Location = new System.Drawing.Point(75, 71);
            this.Controller.Name = "Controller";
            this.Controller.Size = new System.Drawing.Size(60, 21);
            this.Controller.TabIndex = 54;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.label56);
            this.groupBox4.Controls.Add(this.label57);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.BlueRight);
            this.groupBox4.Controls.Add(this.GreenRight);
            this.groupBox4.Controls.Add(this.RedRight);
            this.groupBox4.Controls.Add(this.ColorRight);
            this.groupBox4.Location = new System.Drawing.Point(12, 238);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 97);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Right [Colour Compensation]";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(210, 75);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(13, 13);
            this.label52.TabIndex = 101;
            this.label52.Text = "0";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(210, 49);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(13, 13);
            this.label53.TabIndex = 100;
            this.label53.Text = "0";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(210, 23);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(13, 13);
            this.label54.TabIndex = 99;
            this.label54.Text = "0";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(173, 75);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(31, 13);
            this.label55.TabIndex = 98;
            this.label55.Text = "Blue:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(165, 49);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(39, 13);
            this.label56.TabIndex = 97;
            this.label56.Text = "Green:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(174, 23);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(30, 13);
            this.label57.TabIndex = 96;
            this.label57.Text = "Red:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.label43);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.BlueTop);
            this.groupBox5.Controls.Add(this.GreenTop);
            this.groupBox5.Controls.Add(this.RedTop);
            this.groupBox5.Controls.Add(this.ColorTop);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 107);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Top [Colour Compensation]";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(210, 73);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(13, 13);
            this.label42.TabIndex = 91;
            this.label42.Text = "0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(210, 47);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(13, 13);
            this.label43.TabIndex = 90;
            this.label43.Text = "0";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(210, 21);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(13, 13);
            this.label44.TabIndex = 89;
            this.label44.Text = "0";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(173, 73);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(31, 13);
            this.label39.TabIndex = 88;
            this.label39.Text = "Blue:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(165, 47);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(39, 13);
            this.label40.TabIndex = 87;
            this.label40.Text = "Green:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(174, 21);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(30, 13);
            this.label41.TabIndex = 86;
            this.label41.Text = "Red:";
            // 
            // gpTopOnExit
            // 
            this.gpTopOnExit.Controls.Add(this.label33);
            this.gpTopOnExit.Controls.Add(this.label34);
            this.gpTopOnExit.Controls.Add(this.label35);
            this.gpTopOnExit.Controls.Add(this.BlueTopOnExit);
            this.gpTopOnExit.Controls.Add(this.GreenTopOnExit);
            this.gpTopOnExit.Controls.Add(this.RedTopOnExit);
            this.gpTopOnExit.Controls.Add(this.ColorTopOnExit);
            this.gpTopOnExit.Location = new System.Drawing.Point(460, 12);
            this.gpTopOnExit.Name = "gpTopOnExit";
            this.gpTopOnExit.Size = new System.Drawing.Size(168, 107);
            this.gpTopOnExit.TabIndex = 87;
            this.gpTopOnExit.TabStop = false;
            this.gpTopOnExit.Text = "Top on Exit";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 73);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(31, 13);
            this.label33.TabIndex = 61;
            this.label33.Text = "Blue:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(5, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(39, 13);
            this.label34.TabIndex = 60;
            this.label34.Text = "Green:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(14, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 13);
            this.label35.TabIndex = 59;
            this.label35.Text = "Red:";
            // 
            // BlueTopOnExit
            // 
            this.BlueTopOnExit.Location = new System.Drawing.Point(50, 71);
            this.BlueTopOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueTopOnExit.Name = "BlueTopOnExit";
            this.BlueTopOnExit.Size = new System.Drawing.Size(45, 20);
            this.BlueTopOnExit.TabIndex = 58;
            this.BlueTopOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueTopOnExit.ValueChanged += new System.EventHandler(this.BlueTopOnExit_ValueChanged);
            // 
            // GreenTopOnExit
            // 
            this.GreenTopOnExit.Location = new System.Drawing.Point(50, 45);
            this.GreenTopOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenTopOnExit.Name = "GreenTopOnExit";
            this.GreenTopOnExit.Size = new System.Drawing.Size(45, 20);
            this.GreenTopOnExit.TabIndex = 57;
            this.GreenTopOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenTopOnExit.ValueChanged += new System.EventHandler(this.GreenTopOnExit_ValueChanged);
            // 
            // RedTopOnExit
            // 
            this.RedTopOnExit.Location = new System.Drawing.Point(50, 19);
            this.RedTopOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedTopOnExit.Name = "RedTopOnExit";
            this.RedTopOnExit.Size = new System.Drawing.Size(45, 20);
            this.RedTopOnExit.TabIndex = 56;
            this.RedTopOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedTopOnExit.ValueChanged += new System.EventHandler(this.RedTopOnExit_ValueChanged);
            // 
            // ColorTopOnExit
            // 
            this.ColorTopOnExit.Location = new System.Drawing.Point(101, 19);
            this.ColorTopOnExit.Name = "ColorTopOnExit";
            this.ColorTopOnExit.Size = new System.Drawing.Size(51, 72);
            this.ColorTopOnExit.TabIndex = 4;
            this.ColorTopOnExit.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.BlueLeftOnExit);
            this.groupBox7.Controls.Add(this.GreenLeftOnExit);
            this.groupBox7.Controls.Add(this.RedLeftOnExit);
            this.groupBox7.Controls.Add(this.ColorLeftOnExit);
            this.groupBox7.Location = new System.Drawing.Point(460, 125);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(168, 107);
            this.groupBox7.TabIndex = 88;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Left on Exit";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 73);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 13);
            this.label24.TabIndex = 61;
            this.label24.Text = "Blue:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 13);
            this.label25.TabIndex = 60;
            this.label25.Text = "Green:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 59;
            this.label26.Text = "Red:";
            // 
            // BlueLeftOnExit
            // 
            this.BlueLeftOnExit.Location = new System.Drawing.Point(50, 71);
            this.BlueLeftOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueLeftOnExit.Name = "BlueLeftOnExit";
            this.BlueLeftOnExit.Size = new System.Drawing.Size(45, 20);
            this.BlueLeftOnExit.TabIndex = 58;
            this.BlueLeftOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueLeftOnExit.ValueChanged += new System.EventHandler(this.BlueLeftOnExit_ValueChanged);
            // 
            // GreenLeftOnExit
            // 
            this.GreenLeftOnExit.Location = new System.Drawing.Point(50, 45);
            this.GreenLeftOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenLeftOnExit.Name = "GreenLeftOnExit";
            this.GreenLeftOnExit.Size = new System.Drawing.Size(45, 20);
            this.GreenLeftOnExit.TabIndex = 57;
            this.GreenLeftOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenLeftOnExit.ValueChanged += new System.EventHandler(this.GreenLeftOnExit_ValueChanged);
            // 
            // RedLeftOnExit
            // 
            this.RedLeftOnExit.Location = new System.Drawing.Point(50, 19);
            this.RedLeftOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedLeftOnExit.Name = "RedLeftOnExit";
            this.RedLeftOnExit.Size = new System.Drawing.Size(45, 20);
            this.RedLeftOnExit.TabIndex = 56;
            this.RedLeftOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedLeftOnExit.ValueChanged += new System.EventHandler(this.RedLeftOnExit_ValueChanged);
            // 
            // ColorLeftOnExit
            // 
            this.ColorLeftOnExit.Location = new System.Drawing.Point(101, 19);
            this.ColorLeftOnExit.Name = "ColorLeftOnExit";
            this.ColorLeftOnExit.Size = new System.Drawing.Size(51, 72);
            this.ColorLeftOnExit.TabIndex = 4;
            this.ColorLeftOnExit.TabStop = false;
            // 
            // ColorRightOnExit
            // 
            this.ColorRightOnExit.Location = new System.Drawing.Point(101, 19);
            this.ColorRightOnExit.Name = "ColorRightOnExit";
            this.ColorRightOnExit.Size = new System.Drawing.Size(51, 72);
            this.ColorRightOnExit.TabIndex = 4;
            this.ColorRightOnExit.TabStop = false;
            // 
            // RedRightOnExit
            // 
            this.RedRightOnExit.Location = new System.Drawing.Point(50, 19);
            this.RedRightOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedRightOnExit.Name = "RedRightOnExit";
            this.RedRightOnExit.Size = new System.Drawing.Size(45, 20);
            this.RedRightOnExit.TabIndex = 56;
            this.RedRightOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedRightOnExit.ValueChanged += new System.EventHandler(this.RedRightOnExit_ValueChanged);
            // 
            // GreenRightOnExit
            // 
            this.GreenRightOnExit.Location = new System.Drawing.Point(50, 45);
            this.GreenRightOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenRightOnExit.Name = "GreenRightOnExit";
            this.GreenRightOnExit.Size = new System.Drawing.Size(45, 20);
            this.GreenRightOnExit.TabIndex = 57;
            this.GreenRightOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenRightOnExit.ValueChanged += new System.EventHandler(this.GreenRightOnExit_ValueChanged);
            // 
            // BlueRightOnExit
            // 
            this.BlueRightOnExit.Location = new System.Drawing.Point(50, 71);
            this.BlueRightOnExit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueRightOnExit.Name = "BlueRightOnExit";
            this.BlueRightOnExit.Size = new System.Drawing.Size(45, 20);
            this.BlueRightOnExit.TabIndex = 58;
            this.BlueRightOnExit.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueRightOnExit.ValueChanged += new System.EventHandler(this.BlueRightOnExit_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(14, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 59;
            this.label29.Text = "Red:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 47);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 13);
            this.label28.TabIndex = 60;
            this.label28.Text = "Green:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 13);
            this.label27.TabIndex = 61;
            this.label27.Text = "Blue:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.BlueRightOnExit);
            this.groupBox8.Controls.Add(this.GreenRightOnExit);
            this.groupBox8.Controls.Add(this.RedRightOnExit);
            this.groupBox8.Controls.Add(this.ColorRightOnExit);
            this.groupBox8.Location = new System.Drawing.Point(460, 238);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(168, 98);
            this.groupBox8.TabIndex = 89;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Right on Exit";
            // 
            // ColorLeft
            // 
            this.ColorLeft.Location = new System.Drawing.Point(101, 17);
            this.ColorLeft.Name = "ColorLeft";
            this.ColorLeft.Size = new System.Drawing.Size(51, 72);
            this.ColorLeft.TabIndex = 2;
            this.ColorLeft.TabStop = false;
            // 
            // RedLeft
            // 
            this.RedLeft.Location = new System.Drawing.Point(50, 17);
            this.RedLeft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedLeft.Name = "RedLeft";
            this.RedLeft.Size = new System.Drawing.Size(45, 20);
            this.RedLeft.TabIndex = 68;
            this.RedLeft.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // GreenLeft
            // 
            this.GreenLeft.Location = new System.Drawing.Point(50, 43);
            this.GreenLeft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenLeft.Name = "GreenLeft";
            this.GreenLeft.Size = new System.Drawing.Size(45, 20);
            this.GreenLeft.TabIndex = 69;
            this.GreenLeft.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // BlueLeft
            // 
            this.BlueLeft.Location = new System.Drawing.Point(50, 69);
            this.BlueLeft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueLeft.Name = "BlueLeft";
            this.BlueLeft.Size = new System.Drawing.Size(45, 20);
            this.BlueLeft.TabIndex = 70;
            this.BlueLeft.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Red:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "Green:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Blue:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.BlueLeft);
            this.groupBox3.Controls.Add(this.GreenLeft);
            this.groupBox3.Controls.Add(this.RedLeft);
            this.groupBox3.Controls.Add(this.ColorLeft);
            this.groupBox3.Location = new System.Drawing.Point(12, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 107);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Left [Colour Compensation]";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(210, 73);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(13, 13);
            this.label45.TabIndex = 97;
            this.label45.Text = "0";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(210, 47);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(13, 13);
            this.label47.TabIndex = 96;
            this.label47.Text = "0";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(210, 21);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(13, 13);
            this.label48.TabIndex = 95;
            this.label48.Text = "0";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(173, 73);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 94;
            this.label49.Text = "Blue:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(165, 47);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(39, 13);
            this.label50.TabIndex = 93;
            this.label50.Text = "Green:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(174, 21);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(30, 13);
            this.label51.TabIndex = 92;
            this.label51.Text = "Red:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1147, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 91;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(337, 17);
            this.toolStripStatusLabel2.Text = "AmbiLED.NET v3 (2011) build 0903 ^Silas Id, silas@qnapclub.pl";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(175, 17);
            this.toolStripStatusLabel1.Text = "MoMoLight v2/v3 RGB software";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(194, 17);
            this.toolStripStatusLabel3.Text = "http://qnapclub.pl/qnas/AmbiLED/";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.BlueRightOnStart);
            this.groupBox10.Controls.Add(this.GreenRightOnStart);
            this.groupBox10.Controls.Add(this.RedRightOnStart);
            this.groupBox10.Controls.Add(this.ColorRightOnStart);
            this.groupBox10.Location = new System.Drawing.Point(286, 238);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(168, 98);
            this.groupBox10.TabIndex = 92;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Right on Start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Blue:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Green:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "Red:";
            // 
            // BlueRightOnStart
            // 
            this.BlueRightOnStart.Location = new System.Drawing.Point(50, 71);
            this.BlueRightOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueRightOnStart.Name = "BlueRightOnStart";
            this.BlueRightOnStart.Size = new System.Drawing.Size(45, 20);
            this.BlueRightOnStart.TabIndex = 58;
            this.BlueRightOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueRightOnStart.ValueChanged += new System.EventHandler(this.BlueRightOnStart_ValueChanged);
            // 
            // GreenRightOnStart
            // 
            this.GreenRightOnStart.Location = new System.Drawing.Point(50, 45);
            this.GreenRightOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenRightOnStart.Name = "GreenRightOnStart";
            this.GreenRightOnStart.Size = new System.Drawing.Size(45, 20);
            this.GreenRightOnStart.TabIndex = 57;
            this.GreenRightOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenRightOnStart.ValueChanged += new System.EventHandler(this.GreenRightOnStart_ValueChanged);
            // 
            // RedRightOnStart
            // 
            this.RedRightOnStart.Location = new System.Drawing.Point(50, 19);
            this.RedRightOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedRightOnStart.Name = "RedRightOnStart";
            this.RedRightOnStart.Size = new System.Drawing.Size(45, 20);
            this.RedRightOnStart.TabIndex = 56;
            this.RedRightOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedRightOnStart.ValueChanged += new System.EventHandler(this.RedRightOnStart_ValueChanged);
            // 
            // ColorRightOnStart
            // 
            this.ColorRightOnStart.Location = new System.Drawing.Point(101, 19);
            this.ColorRightOnStart.Name = "ColorRightOnStart";
            this.ColorRightOnStart.Size = new System.Drawing.Size(51, 72);
            this.ColorRightOnStart.TabIndex = 4;
            this.ColorRightOnStart.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.BlueLeftOnStart);
            this.groupBox11.Controls.Add(this.GreenLeftOnStart);
            this.groupBox11.Controls.Add(this.RedLeftOnStart);
            this.groupBox11.Controls.Add(this.ColorLeftOnStart);
            this.groupBox11.Location = new System.Drawing.Point(286, 125);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(168, 107);
            this.groupBox11.TabIndex = 91;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Left on Start";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "Blue:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Green:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 59;
            this.label17.Text = "Red:";
            // 
            // BlueLeftOnStart
            // 
            this.BlueLeftOnStart.Location = new System.Drawing.Point(50, 71);
            this.BlueLeftOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueLeftOnStart.Name = "BlueLeftOnStart";
            this.BlueLeftOnStart.Size = new System.Drawing.Size(45, 20);
            this.BlueLeftOnStart.TabIndex = 58;
            this.BlueLeftOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueLeftOnStart.ValueChanged += new System.EventHandler(this.BlueLeftOnStart_ValueChanged);
            // 
            // GreenLeftOnStart
            // 
            this.GreenLeftOnStart.Location = new System.Drawing.Point(50, 45);
            this.GreenLeftOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenLeftOnStart.Name = "GreenLeftOnStart";
            this.GreenLeftOnStart.Size = new System.Drawing.Size(45, 20);
            this.GreenLeftOnStart.TabIndex = 57;
            this.GreenLeftOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenLeftOnStart.ValueChanged += new System.EventHandler(this.GreenLeftOnStart_ValueChanged);
            // 
            // RedLeftOnStart
            // 
            this.RedLeftOnStart.Location = new System.Drawing.Point(50, 19);
            this.RedLeftOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedLeftOnStart.Name = "RedLeftOnStart";
            this.RedLeftOnStart.Size = new System.Drawing.Size(45, 20);
            this.RedLeftOnStart.TabIndex = 56;
            this.RedLeftOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedLeftOnStart.ValueChanged += new System.EventHandler(this.RedLeftOnStart_ValueChanged);
            // 
            // ColorLeftOnStart
            // 
            this.ColorLeftOnStart.Location = new System.Drawing.Point(101, 19);
            this.ColorLeftOnStart.Name = "ColorLeftOnStart";
            this.ColorLeftOnStart.Size = new System.Drawing.Size(51, 72);
            this.ColorLeftOnStart.TabIndex = 4;
            this.ColorLeftOnStart.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label18);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Controls.Add(this.label20);
            this.groupBox12.Controls.Add(this.BlueTopOnStart);
            this.groupBox12.Controls.Add(this.GreenTopOnStart);
            this.groupBox12.Controls.Add(this.RedTopOnStart);
            this.groupBox12.Controls.Add(this.ColorTopOnStart);
            this.groupBox12.Location = new System.Drawing.Point(286, 12);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(168, 107);
            this.groupBox12.TabIndex = 90;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Top on Start";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 61;
            this.label18.Text = "Blue:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 60;
            this.label19.Text = "Green:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 59;
            this.label20.Text = "Red:";
            // 
            // BlueTopOnStart
            // 
            this.BlueTopOnStart.Location = new System.Drawing.Point(50, 71);
            this.BlueTopOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueTopOnStart.Name = "BlueTopOnStart";
            this.BlueTopOnStart.Size = new System.Drawing.Size(45, 20);
            this.BlueTopOnStart.TabIndex = 58;
            this.BlueTopOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueTopOnStart.ValueChanged += new System.EventHandler(this.BlueTopOnStart_ValueChanged);
            // 
            // GreenTopOnStart
            // 
            this.GreenTopOnStart.Location = new System.Drawing.Point(50, 45);
            this.GreenTopOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenTopOnStart.Name = "GreenTopOnStart";
            this.GreenTopOnStart.Size = new System.Drawing.Size(45, 20);
            this.GreenTopOnStart.TabIndex = 57;
            this.GreenTopOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenTopOnStart.ValueChanged += new System.EventHandler(this.GreenTopOnStart_ValueChanged);
            // 
            // RedTopOnStart
            // 
            this.RedTopOnStart.Location = new System.Drawing.Point(50, 19);
            this.RedTopOnStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedTopOnStart.Name = "RedTopOnStart";
            this.RedTopOnStart.Size = new System.Drawing.Size(45, 20);
            this.RedTopOnStart.TabIndex = 56;
            this.RedTopOnStart.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedTopOnStart.ValueChanged += new System.EventHandler(this.RedTopOnStart_ValueChanged);
            // 
            // ColorTopOnStart
            // 
            this.ColorTopOnStart.Location = new System.Drawing.Point(101, 19);
            this.ColorTopOnStart.Name = "ColorTopOnStart";
            this.ColorTopOnStart.Size = new System.Drawing.Size(51, 72);
            this.ColorTopOnStart.TabIndex = 4;
            this.ColorTopOnStart.TabStop = false;
            // 
            // AutoDetect
            // 
            this.AutoDetect.Enabled = true;
            this.AutoDetect.Interval = 50;
            this.AutoDetect.Tick += new System.EventHandler(this.AutoDetect_Tick);
            // 
            // GammaPage
            // 
            this.GammaPage.Controls.Add(this.label36);
            this.GammaPage.Controls.Add(this.GammaEvent);
            this.GammaPage.Controls.Add(this.GammaTable);
            this.GammaPage.Controls.Add(this.GammaLevel);
            this.GammaPage.Controls.Add(this.label3);
            this.GammaPage.Controls.Add(this.GammaValue);
            this.GammaPage.Location = new System.Drawing.Point(4, 22);
            this.GammaPage.Name = "GammaPage";
            this.GammaPage.Size = new System.Drawing.Size(855, 345);
            this.GammaPage.TabIndex = 2;
            this.GammaPage.Text = "Gamma";
            this.GammaPage.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 253);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 13);
            this.label36.TabIndex = 100;
            this.label36.Text = "Event";
            // 
            // GammaEvent
            // 
            this.GammaEvent.FormattingEnabled = true;
            this.GammaEvent.Items.AddRange(new object[] {
            "No gamma",
            "Input data",
            "Output data"});
            this.GammaEvent.Location = new System.Drawing.Point(60, 250);
            this.GammaEvent.Name = "GammaEvent";
            this.GammaEvent.Size = new System.Drawing.Size(121, 21);
            this.GammaEvent.TabIndex = 99;
            this.GammaEvent.SelectedIndexChanged += new System.EventHandler(this.GammaEvent_SelectedIndexChanged);
            // 
            // GammaTable
            // 
            this.GammaTable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GammaTable.Location = new System.Drawing.Point(13, 40);
            this.GammaTable.Name = "GammaTable";
            this.GammaTable.Size = new System.Drawing.Size(508, 204);
            this.GammaTable.TabIndex = 98;
            this.GammaTable.Text = "";
            // 
            // GammaLevel
            // 
            this.GammaLevel.Enabled = false;
            this.GammaLevel.Location = new System.Drawing.Point(60, 11);
            this.GammaLevel.Name = "GammaLevel";
            this.GammaLevel.Size = new System.Drawing.Size(43, 20);
            this.GammaLevel.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Gamma:";
            // 
            // GammaValue
            // 
            this.GammaValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GammaValue.Location = new System.Drawing.Point(106, 11);
            this.GammaValue.Maximum = 200;
            this.GammaValue.Minimum = 1;
            this.GammaValue.Name = "GammaValue";
            this.GammaValue.Size = new System.Drawing.Size(425, 45);
            this.GammaValue.TabIndex = 95;
            this.GammaValue.Value = 100;
            this.GammaValue.ValueChanged += new System.EventHandler(this.GammaValue_ValueChanged);
            // 
            // VoodooPage
            // 
            this.VoodooPage.Controls.Add(this.groupBox13);
            this.VoodooPage.Controls.Add(this.groupBox9);
            this.VoodooPage.Controls.Add(this.groupBox2);
            this.VoodooPage.Location = new System.Drawing.Point(4, 22);
            this.VoodooPage.Name = "VoodooPage";
            this.VoodooPage.Padding = new System.Windows.Forms.Padding(3);
            this.VoodooPage.Size = new System.Drawing.Size(855, 345);
            this.VoodooPage.TabIndex = 0;
            this.VoodooPage.Text = "Voodoo Settings";
            this.VoodooPage.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label69);
            this.groupBox13.Controls.Add(this.label68);
            this.groupBox13.Controls.Add(this.label65);
            this.groupBox13.Controls.Add(this.label64);
            this.groupBox13.Controls.Add(this.label63);
            this.groupBox13.Controls.Add(this.label46);
            this.groupBox13.Controls.Add(this.voRight);
            this.groupBox13.Controls.Add(this.voLeft);
            this.groupBox13.Controls.Add(this.voTop);
            this.groupBox13.Controls.Add(this.viRight);
            this.groupBox13.Controls.Add(this.viLeft);
            this.groupBox13.Controls.Add(this.viTop);
            this.groupBox13.Controls.Add(this.label71);
            this.groupBox13.Controls.Add(this.ShowDebugDiag);
            this.groupBox13.Controls.Add(this.cRight);
            this.groupBox13.Controls.Add(this.cLeft);
            this.groupBox13.Controls.Add(this.cTop);
            this.groupBox13.Controls.Add(this.label70);
            this.groupBox13.Controls.Add(this.dradiusRight);
            this.groupBox13.Controls.Add(this.dradiusTop);
            this.groupBox13.Controls.Add(this.dradiusLeft);
            this.groupBox13.Controls.Add(this.label67);
            this.groupBox13.Controls.Add(this.label66);
            this.groupBox13.Controls.Add(this.dynamicValueRight);
            this.groupBox13.Controls.Add(this.dynamicValueTop);
            this.groupBox13.Controls.Add(this.dynamicValueLeft);
            this.groupBox13.Controls.Add(this.label62);
            this.groupBox13.Controls.Add(this.ShowFPS);
            this.groupBox13.Controls.Add(this.label61);
            this.groupBox13.Controls.Add(this.label60);
            this.groupBox13.Controls.Add(this.radiusRight);
            this.groupBox13.Controls.Add(this.radiusTop);
            this.groupBox13.Controls.Add(this.radiusLeft);
            this.groupBox13.Location = new System.Drawing.Point(526, 9);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(320, 330);
            this.groupBox13.TabIndex = 152;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Debug/Diagnose";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(211, 44);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(13, 13);
            this.label69.TabIndex = 191;
            this.label69.Text = "?";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(211, 20);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(13, 13);
            this.label68.TabIndex = 190;
            this.label68.Text = "?";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(126, 44);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(79, 13);
            this.label65.TabIndex = 189;
            this.label65.Text = "Est. to capture:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(156, 20);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(49, 13);
            this.label64.TabIndex = 188;
            this.label64.Text = "Job time:";
            this.label64.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(156, 219);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(94, 13);
            this.label63.TabIndex = 187;
            this.label63.Text = "<-- Voodoo Output";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(156, 134);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(86, 13);
            this.label46.TabIndex = 186;
            this.label46.Text = "<-- Voodoo Input";
            // 
            // voRight
            // 
            this.voRight.Location = new System.Drawing.Point(102, 215);
            this.voRight.Name = "voRight";
            this.voRight.Size = new System.Drawing.Size(42, 20);
            this.voRight.TabIndex = 185;
            this.voRight.TabStop = false;
            // 
            // voLeft
            // 
            this.voLeft.Location = new System.Drawing.Point(59, 215);
            this.voLeft.Name = "voLeft";
            this.voLeft.Size = new System.Drawing.Size(42, 20);
            this.voLeft.TabIndex = 184;
            this.voLeft.TabStop = false;
            // 
            // voTop
            // 
            this.voTop.Location = new System.Drawing.Point(16, 215);
            this.voTop.Name = "voTop";
            this.voTop.Size = new System.Drawing.Size(42, 20);
            this.voTop.TabIndex = 183;
            this.voTop.TabStop = false;
            // 
            // viRight
            // 
            this.viRight.Location = new System.Drawing.Point(102, 131);
            this.viRight.Name = "viRight";
            this.viRight.Size = new System.Drawing.Size(42, 20);
            this.viRight.TabIndex = 182;
            this.viRight.TabStop = false;
            // 
            // viLeft
            // 
            this.viLeft.Location = new System.Drawing.Point(59, 131);
            this.viLeft.Name = "viLeft";
            this.viLeft.Size = new System.Drawing.Size(42, 20);
            this.viLeft.TabIndex = 181;
            this.viLeft.TabStop = false;
            // 
            // viTop
            // 
            this.viTop.Location = new System.Drawing.Point(16, 131);
            this.viTop.Name = "viTop";
            this.viTop.Size = new System.Drawing.Size(42, 20);
            this.viTop.TabIndex = 180;
            this.viTop.TabStop = false;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(156, 112);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(94, 13);
            this.label71.TabIndex = 179;
            this.label71.Text = "<-- Received RGB";
            // 
            // ShowDebugDiag
            // 
            this.ShowDebugDiag.AutoSize = true;
            this.ShowDebugDiag.Location = new System.Drawing.Point(16, 66);
            this.ShowDebugDiag.Name = "ShowDebugDiag";
            this.ShowDebugDiag.Size = new System.Drawing.Size(115, 17);
            this.ShowDebugDiag.TabIndex = 178;
            this.ShowDebugDiag.Text = "Show Debug/Diag";
            this.ShowDebugDiag.UseVisualStyleBackColor = true;
            // 
            // cRight
            // 
            this.cRight.Location = new System.Drawing.Point(102, 110);
            this.cRight.Name = "cRight";
            this.cRight.Size = new System.Drawing.Size(42, 20);
            this.cRight.TabIndex = 177;
            this.cRight.TabStop = false;
            // 
            // cLeft
            // 
            this.cLeft.Location = new System.Drawing.Point(59, 110);
            this.cLeft.Name = "cLeft";
            this.cLeft.Size = new System.Drawing.Size(42, 20);
            this.cLeft.TabIndex = 176;
            this.cLeft.TabStop = false;
            // 
            // cTop
            // 
            this.cTop.Location = new System.Drawing.Point(16, 110);
            this.cTop.Name = "cTop";
            this.cTop.Size = new System.Drawing.Size(42, 20);
            this.cTop.TabIndex = 175;
            this.cTop.TabStop = false;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(156, 196);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(150, 13);
            this.label70.TabIndex = 174;
            this.label70.Text = "<-- Destination Smooth Radius";
            // 
            // dradiusRight
            // 
            this.dradiusRight.Enabled = false;
            this.dradiusRight.Location = new System.Drawing.Point(102, 194);
            this.dradiusRight.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.dradiusRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dradiusRight.Name = "dradiusRight";
            this.dradiusRight.Size = new System.Drawing.Size(42, 20);
            this.dradiusRight.TabIndex = 170;
            this.dradiusRight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dradiusTop
            // 
            this.dradiusTop.Enabled = false;
            this.dradiusTop.Location = new System.Drawing.Point(16, 194);
            this.dradiusTop.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.dradiusTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dradiusTop.Name = "dradiusTop";
            this.dradiusTop.Size = new System.Drawing.Size(42, 20);
            this.dradiusTop.TabIndex = 168;
            this.dradiusTop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dradiusLeft
            // 
            this.dradiusLeft.Enabled = false;
            this.dradiusLeft.Location = new System.Drawing.Point(59, 194);
            this.dradiusLeft.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.dradiusLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dradiusLeft.Name = "dradiusLeft";
            this.dradiusLeft.Size = new System.Drawing.Size(42, 20);
            this.dradiusLeft.TabIndex = 169;
            this.dradiusLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(156, 175);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(131, 13);
            this.label67.TabIndex = 167;
            this.label67.Text = "<-- Current Smooth Radius";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(156, 154);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(128, 13);
            this.label66.TabIndex = 166;
            this.label66.Text = "<-- Dynamic Control value";
            // 
            // dynamicValueRight
            // 
            this.dynamicValueRight.Enabled = false;
            this.dynamicValueRight.Location = new System.Drawing.Point(102, 152);
            this.dynamicValueRight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dynamicValueRight.Name = "dynamicValueRight";
            this.dynamicValueRight.Size = new System.Drawing.Size(42, 20);
            this.dynamicValueRight.TabIndex = 162;
            // 
            // dynamicValueTop
            // 
            this.dynamicValueTop.Enabled = false;
            this.dynamicValueTop.Location = new System.Drawing.Point(16, 152);
            this.dynamicValueTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dynamicValueTop.Name = "dynamicValueTop";
            this.dynamicValueTop.Size = new System.Drawing.Size(42, 20);
            this.dynamicValueTop.TabIndex = 160;
            // 
            // dynamicValueLeft
            // 
            this.dynamicValueLeft.Enabled = false;
            this.dynamicValueLeft.Location = new System.Drawing.Point(59, 152);
            this.dynamicValueLeft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dynamicValueLeft.Name = "dynamicValueLeft";
            this.dynamicValueLeft.Size = new System.Drawing.Size(42, 20);
            this.dynamicValueLeft.TabIndex = 161;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(107, 92);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(32, 13);
            this.label62.TabIndex = 159;
            this.label62.Text = "Right";
            // 
            // ShowFPS
            // 
            this.ShowFPS.AutoSize = true;
            this.ShowFPS.Location = new System.Drawing.Point(16, 19);
            this.ShowFPS.Name = "ShowFPS";
            this.ShowFPS.Size = new System.Drawing.Size(134, 17);
            this.ShowFPS.TabIndex = 141;
            this.ShowFPS.Text = "FPS: Received/Cycles";
            this.ShowFPS.UseVisualStyleBackColor = true;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(67, 92);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(25, 13);
            this.label61.TabIndex = 158;
            this.label61.Text = "Left";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(24, 92);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(26, 13);
            this.label60.TabIndex = 157;
            this.label60.Text = "Top";
            this.label60.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radiusRight
            // 
            this.radiusRight.Enabled = false;
            this.radiusRight.Location = new System.Drawing.Point(102, 173);
            this.radiusRight.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.radiusRight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusRight.Name = "radiusRight";
            this.radiusRight.Size = new System.Drawing.Size(42, 20);
            this.radiusRight.TabIndex = 156;
            this.radiusRight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radiusTop
            // 
            this.radiusTop.Enabled = false;
            this.radiusTop.Location = new System.Drawing.Point(16, 173);
            this.radiusTop.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.radiusTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusTop.Name = "radiusTop";
            this.radiusTop.Size = new System.Drawing.Size(42, 20);
            this.radiusTop.TabIndex = 154;
            this.radiusTop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radiusLeft
            // 
            this.radiusLeft.Enabled = false;
            this.radiusLeft.Location = new System.Drawing.Point(59, 173);
            this.radiusLeft.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.radiusLeft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusLeft.Name = "radiusLeft";
            this.radiusLeft.Size = new System.Drawing.Size(42, 20);
            this.radiusLeft.TabIndex = 155;
            this.radiusLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.DynamicControl);
            this.groupBox9.Controls.Add(this.label73);
            this.groupBox9.Controls.Add(this.MinSmoothRadiusUpDown);
            this.groupBox9.Controls.Add(this.label72);
            this.groupBox9.Controls.Add(this.MinSmoothRadius);
            this.groupBox9.Controls.Add(this.DynamicRadiusSlideDelayUpDown);
            this.groupBox9.Controls.Add(this.DynamicRadiusSlideDelay);
            this.groupBox9.Controls.Add(this.AggressiveIndicator);
            this.groupBox9.Controls.Add(this.Colorslider);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.MaxSmoothRadiusUpDown);
            this.groupBox9.Controls.Add(this.label59);
            this.groupBox9.Controls.Add(this.MaxSmoothRadius);
            this.groupBox9.Controls.Add(this.DynamicSmoothRadius);
            this.groupBox9.Controls.Add(this.AggressiveThresholdUpDown);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.AggressiveThreshold);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.ModeCombo2);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.IntelliInterval);
            this.groupBox9.Location = new System.Drawing.Point(215, 9);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(305, 330);
            this.groupBox9.TabIndex = 151;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Output";
            // 
            // DynamicControl
            // 
            this.DynamicControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DynamicControl.FormattingEnabled = true;
            this.DynamicControl.Items.AddRange(new object[] {
            "(HSL)HSB.Brightness",
            "HSV.Value",
            "Scene Difference"});
            this.DynamicControl.Location = new System.Drawing.Point(164, 235);
            this.DynamicControl.Name = "DynamicControl";
            this.DynamicControl.Size = new System.Drawing.Size(132, 21);
            this.DynamicControl.TabIndex = 158;
            this.DynamicControl.SelectedIndexChanged += new System.EventHandler(this.DynamicControl_SelectedIndexChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(161, 220);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(110, 13);
            this.label73.TabIndex = 157;
            this.label73.Text = "Dynamic Control input";
            // 
            // MinSmoothRadiusUpDown
            // 
            this.MinSmoothRadiusUpDown.Location = new System.Drawing.Point(108, 236);
            this.MinSmoothRadiusUpDown.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.MinSmoothRadiusUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinSmoothRadiusUpDown.Name = "MinSmoothRadiusUpDown";
            this.MinSmoothRadiusUpDown.Size = new System.Drawing.Size(43, 20);
            this.MinSmoothRadiusUpDown.TabIndex = 156;
            this.MinSmoothRadiusUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinSmoothRadiusUpDown.ValueChanged += new System.EventHandler(this.MinSmoothRadiusUpDown_ValueChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(16, 220);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(126, 13);
            this.label72.TabIndex = 155;
            this.label72.Text = "Minimum Smooth Radius:";
            // 
            // MinSmoothRadius
            // 
            this.MinSmoothRadius.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MinSmoothRadius.Location = new System.Drawing.Point(6, 236);
            this.MinSmoothRadius.Maximum = 140;
            this.MinSmoothRadius.Minimum = 1;
            this.MinSmoothRadius.Name = "MinSmoothRadius";
            this.MinSmoothRadius.Size = new System.Drawing.Size(103, 45);
            this.MinSmoothRadius.TabIndex = 154;
            this.MinSmoothRadius.Value = 1;
            this.MinSmoothRadius.ValueChanged += new System.EventHandler(this.MinSmoothRadius_ValueChanged);
            // 
            // DynamicRadiusSlideDelayUpDown
            // 
            this.DynamicRadiusSlideDelayUpDown.Location = new System.Drawing.Point(253, 179);
            this.DynamicRadiusSlideDelayUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.DynamicRadiusSlideDelayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DynamicRadiusSlideDelayUpDown.Name = "DynamicRadiusSlideDelayUpDown";
            this.DynamicRadiusSlideDelayUpDown.Size = new System.Drawing.Size(43, 20);
            this.DynamicRadiusSlideDelayUpDown.TabIndex = 153;
            this.DynamicRadiusSlideDelayUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DynamicRadiusSlideDelayUpDown.ValueChanged += new System.EventHandler(this.DynamicRadiusSlideDelayUpDown_ValueChanged);
            // 
            // DynamicRadiusSlideDelay
            // 
            this.DynamicRadiusSlideDelay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DynamicRadiusSlideDelay.Location = new System.Drawing.Point(156, 179);
            this.DynamicRadiusSlideDelay.Maximum = 64;
            this.DynamicRadiusSlideDelay.Minimum = 1;
            this.DynamicRadiusSlideDelay.Name = "DynamicRadiusSlideDelay";
            this.DynamicRadiusSlideDelay.Size = new System.Drawing.Size(100, 45);
            this.DynamicRadiusSlideDelay.TabIndex = 151;
            this.DynamicRadiusSlideDelay.Value = 1;
            this.DynamicRadiusSlideDelay.ValueChanged += new System.EventHandler(this.DynamicRadiusSlideDelay_ValueChanged);
            // 
            // AggressiveIndicator
            // 
            this.AggressiveIndicator.AutoSize = true;
            this.AggressiveIndicator.Location = new System.Drawing.Point(134, 94);
            this.AggressiveIndicator.Name = "AggressiveIndicator";
            this.AggressiveIndicator.Size = new System.Drawing.Size(13, 13);
            this.AggressiveIndicator.TabIndex = 150;
            this.AggressiveIndicator.Text = "?";
            // 
            // Colorslider
            // 
            this.Colorslider.Location = new System.Drawing.Point(253, 60);
            this.Colorslider.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Colorslider.Name = "Colorslider";
            this.Colorslider.Size = new System.Drawing.Size(43, 20);
            this.Colorslider.TabIndex = 123;
            this.Colorslider.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Colorslider.ValueChanged += new System.EventHandler(this.Colorslider_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(161, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 26);
            this.label21.TabIndex = 124;
            this.label21.Text = "Colour Increase:\r\n(10=actual color)";
            // 
            // MaxSmoothRadiusUpDown
            // 
            this.MaxSmoothRadiusUpDown.Location = new System.Drawing.Point(108, 179);
            this.MaxSmoothRadiusUpDown.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.MaxSmoothRadiusUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSmoothRadiusUpDown.Name = "MaxSmoothRadiusUpDown";
            this.MaxSmoothRadiusUpDown.Size = new System.Drawing.Size(43, 20);
            this.MaxSmoothRadiusUpDown.TabIndex = 149;
            this.MaxSmoothRadiusUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSmoothRadiusUpDown.ValueChanged += new System.EventHandler(this.MaxSmoothRadiusUpDown_ValueChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(16, 163);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(135, 13);
            this.label59.TabIndex = 148;
            this.label59.Text = "(Maximum) Smooth Radius:";
            // 
            // MaxSmoothRadius
            // 
            this.MaxSmoothRadius.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MaxSmoothRadius.Location = new System.Drawing.Point(6, 179);
            this.MaxSmoothRadius.Maximum = 140;
            this.MaxSmoothRadius.Minimum = 1;
            this.MaxSmoothRadius.Name = "MaxSmoothRadius";
            this.MaxSmoothRadius.Size = new System.Drawing.Size(103, 45);
            this.MaxSmoothRadius.TabIndex = 147;
            this.MaxSmoothRadius.Value = 1;
            this.MaxSmoothRadius.ValueChanged += new System.EventHandler(this.MaxSmoothRadius_ValueChanged);
            // 
            // DynamicSmoothRadius
            // 
            this.DynamicSmoothRadius.AutoSize = true;
            this.DynamicSmoothRadius.Location = new System.Drawing.Point(165, 151);
            this.DynamicSmoothRadius.Name = "DynamicSmoothRadius";
            this.DynamicSmoothRadius.Size = new System.Drawing.Size(103, 30);
            this.DynamicSmoothRadius.TabIndex = 145;
            this.DynamicSmoothRadius.Text = "Dynamic Radius\r\nSlide Delay:";
            this.DynamicSmoothRadius.UseVisualStyleBackColor = true;
            this.DynamicSmoothRadius.CheckedChanged += new System.EventHandler(this.DynamicSmoothRadius_CheckedChanged);
            // 
            // AggressiveThresholdUpDown
            // 
            this.AggressiveThresholdUpDown.Location = new System.Drawing.Point(253, 110);
            this.AggressiveThresholdUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AggressiveThresholdUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AggressiveThresholdUpDown.Name = "AggressiveThresholdUpDown";
            this.AggressiveThresholdUpDown.Size = new System.Drawing.Size(43, 20);
            this.AggressiveThresholdUpDown.TabIndex = 144;
            this.AggressiveThresholdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AggressiveThresholdUpDown.ValueChanged += new System.EventHandler(this.AggressiveThresholdUpDown_ValueChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 94);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(112, 13);
            this.label38.TabIndex = 143;
            this.label38.Text = "Aggressive Threshold:";
            // 
            // AggressiveThreshold
            // 
            this.AggressiveThreshold.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AggressiveThreshold.Location = new System.Drawing.Point(6, 110);
            this.AggressiveThreshold.Maximum = 255;
            this.AggressiveThreshold.Minimum = 1;
            this.AggressiveThreshold.Name = "AggressiveThreshold";
            this.AggressiveThreshold.Size = new System.Drawing.Size(250, 45);
            this.AggressiveThreshold.TabIndex = 142;
            this.AggressiveThreshold.Value = 1;
            this.AggressiveThreshold.ValueChanged += new System.EventHandler(this.AggressiveThreshold_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 21);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 13);
            this.label30.TabIndex = 128;
            this.label30.Text = "Light mode:";
            // 
            // ModeCombo2
            // 
            this.ModeCombo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeCombo2.FormattingEnabled = true;
            this.ModeCombo2.Items.AddRange(new object[] {
            "Gaming",
            "Movie",
            "10*Movie smooth",
            "True-Cinema +Expansion",
            "(temp1)",
            "(temp2)",
            "(temp3)"});
            this.ModeCombo2.Location = new System.Drawing.Point(84, 18);
            this.ModeCombo2.Name = "ModeCombo2";
            this.ModeCombo2.Size = new System.Drawing.Size(212, 21);
            this.ModeCombo2.TabIndex = 127;
            this.ModeCombo2.SelectedIndexChanged += new System.EventHandler(this.ModeCombo2_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 26);
            this.label22.TabIndex = 126;
            this.label22.Text = "IntelliInterval:\r\n(cycle=ms)";
            // 
            // IntelliInterval
            // 
            this.IntelliInterval.Location = new System.Drawing.Point(108, 60);
            this.IntelliInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntelliInterval.Name = "IntelliInterval";
            this.IntelliInterval.Size = new System.Drawing.Size(43, 20);
            this.IntelliInterval.TabIndex = 125;
            this.IntelliInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IntelliInterval.ValueChanged += new System.EventHandler(this.IntelliInterval_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DarknessLimitMethod);
            this.groupBox2.Controls.Add(this.DarknessLimitUpDown);
            this.groupBox2.Controls.Add(this.label74);
            this.groupBox2.Controls.Add(this.DarknessLimit);
            this.groupBox2.Controls.Add(this.DarknessThresholdUpDown);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.QuantizeLevel);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.DarknessThreshold);
            this.groupBox2.Controls.Add(this.ProgressiveThreshold);
            this.groupBox2.Location = new System.Drawing.Point(6, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 330);
            this.groupBox2.TabIndex = 150;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // DarknessLimitMethod
            // 
            this.DarknessLimitMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DarknessLimitMethod.FormattingEnabled = true;
            this.DarknessLimitMethod.Items.AddRange(new object[] {
            "HSB",
            "HSV"});
            this.DarknessLimitMethod.Location = new System.Drawing.Point(146, 214);
            this.DarknessLimitMethod.Name = "DarknessLimitMethod";
            this.DarknessLimitMethod.Size = new System.Drawing.Size(45, 21);
            this.DarknessLimitMethod.TabIndex = 159;
            this.DarknessLimitMethod.SelectedIndexChanged += new System.EventHandler(this.DarknessLimitMethod_SelectedIndexChanged);
            // 
            // DarknessLimitUpDown
            // 
            this.DarknessLimitUpDown.Location = new System.Drawing.Point(146, 235);
            this.DarknessLimitUpDown.Name = "DarknessLimitUpDown";
            this.DarknessLimitUpDown.Size = new System.Drawing.Size(45, 20);
            this.DarknessLimitUpDown.TabIndex = 140;
            this.DarknessLimitUpDown.ValueChanged += new System.EventHandler(this.DarknessLimitUpDown_ValueChanged);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(34, 220);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(76, 13);
            this.label74.TabIndex = 142;
            this.label74.Text = "Darkness Limit";
            // 
            // DarknessLimit
            // 
            this.DarknessLimit.AutoSize = false;
            this.DarknessLimit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DarknessLimit.Location = new System.Drawing.Point(29, 236);
            this.DarknessLimit.Maximum = 96;
            this.DarknessLimit.Name = "DarknessLimit";
            this.DarknessLimit.Size = new System.Drawing.Size(114, 23);
            this.DarknessLimit.TabIndex = 141;
            this.DarknessLimit.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DarknessLimit.ValueChanged += new System.EventHandler(this.DarknessLimit_ValueChanged);
            // 
            // DarknessThresholdUpDown
            // 
            this.DarknessThresholdUpDown.Location = new System.Drawing.Point(146, 178);
            this.DarknessThresholdUpDown.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.DarknessThresholdUpDown.Name = "DarknessThresholdUpDown";
            this.DarknessThresholdUpDown.Size = new System.Drawing.Size(45, 20);
            this.DarknessThresholdUpDown.TabIndex = 137;
            this.DarknessThresholdUpDown.ValueChanged += new System.EventHandler(this.DarknessThresholdUpDown_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(34, 163);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(102, 13);
            this.label31.TabIndex = 139;
            this.label31.Text = "Darkness Threshold";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(35, 112);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(85, 13);
            this.label37.TabIndex = 135;
            this.label37.Text = "Colour Quantize:";
            // 
            // QuantizeLevel
            // 
            this.QuantizeLevel.Location = new System.Drawing.Point(149, 110);
            this.QuantizeLevel.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.QuantizeLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantizeLevel.Name = "QuantizeLevel";
            this.QuantizeLevel.Size = new System.Drawing.Size(45, 20);
            this.QuantizeLevel.TabIndex = 134;
            this.QuantizeLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantizeLevel.ValueChanged += new System.EventHandler(this.QuantizeLevel_ValueChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 17);
            this.radioButton3.TabIndex = 133;
            this.radioButton3.Text = "Expand together";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 17);
            this.radioButton2.TabIndex = 132;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Expand individually";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 131;
            this.radioButton1.Text = "No expand";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(147, 31);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(44, 26);
            this.label58.TabIndex = 130;
            this.label58.Text = "Max.\r\nmultiply:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(149, 65);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown1.TabIndex = 129;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // DarknessThreshold
            // 
            this.DarknessThreshold.AutoSize = false;
            this.DarknessThreshold.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DarknessThreshold.Location = new System.Drawing.Point(29, 179);
            this.DarknessThreshold.Maximum = 96;
            this.DarknessThreshold.Name = "DarknessThreshold";
            this.DarknessThreshold.Size = new System.Drawing.Size(114, 23);
            this.DarknessThreshold.TabIndex = 138;
            this.DarknessThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DarknessThreshold.Scroll += new System.EventHandler(this.DarknessThreshold_Scroll);
            // 
            // ProgressiveThreshold
            // 
            this.ProgressiveThreshold.AutoSize = true;
            this.ProgressiveThreshold.Location = new System.Drawing.Point(17, 137);
            this.ProgressiveThreshold.Name = "ProgressiveThreshold";
            this.ProgressiveThreshold.Size = new System.Drawing.Size(131, 17);
            this.ProgressiveThreshold.TabIndex = 136;
            this.ProgressiveThreshold.Text = "Progressive Threshold\r\n";
            this.ProgressiveThreshold.UseVisualStyleBackColor = true;
            this.ProgressiveThreshold.CheckedChanged += new System.EventHandler(this.ProgressiveThreshold_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LightsSettings);
            this.tabControl1.Controls.Add(this.VoodooPage);
            this.tabControl1.Controls.Add(this.GammaPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 371);
            this.tabControl1.TabIndex = 95;
            // 
            // LightsSettings
            // 
            this.LightsSettings.Controls.Add(this.groupBox5);
            this.LightsSettings.Controls.Add(this.groupBox3);
            this.LightsSettings.Controls.Add(this.groupBox4);
            this.LightsSettings.Controls.Add(this.groupBox10);
            this.LightsSettings.Controls.Add(this.groupBox12);
            this.LightsSettings.Controls.Add(this.gpTopOnExit);
            this.LightsSettings.Controls.Add(this.groupBox11);
            this.LightsSettings.Controls.Add(this.groupBox7);
            this.LightsSettings.Controls.Add(this.groupBox8);
            this.LightsSettings.Location = new System.Drawing.Point(4, 22);
            this.LightsSettings.Name = "LightsSettings";
            this.LightsSettings.Size = new System.Drawing.Size(855, 345);
            this.LightsSettings.TabIndex = 4;
            this.LightsSettings.Text = "Lights Settings";
            this.LightsSettings.UseVisualStyleBackColor = true;
            // 
            // AmbiLEDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1147, 414);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gpComPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AmbiLEDForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AmbiLED.NET v3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ColorRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTop)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RedTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRight)).EndInit();
            this.gpComPort.ResumeLayout(false);
            this.gpComPort.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gpTopOnExit.ResumeLayout(false);
            this.gpTopOnExit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTopOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTopOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTopOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTopOnExit)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeftOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeftOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeftOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeftOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRightOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRightOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRightOnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRightOnExit)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeft)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueRightOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenRightOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedRightOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRightOnStart)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLeftOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLeftOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLeftOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLeftOnStart)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTopOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTopOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTopOnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorTopOnStart)).EndInit();
            this.GammaPage.ResumeLayout(false);
            this.GammaPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GammaValue)).EndInit();
            this.VoodooPage.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dradiusLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicValueLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusLeft)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSmoothRadiusUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSmoothRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicRadiusSlideDelayUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DynamicRadiusSlideDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Colorslider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSmoothRadiusUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSmoothRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggressiveThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AggressiveThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntelliInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessLimitUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantizeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarknessThreshold)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.LightsSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ColorRight;
        private System.Windows.Forms.PictureBox ColorTop;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtPortname;
        private System.Windows.Forms.Label ComPort;
        private System.Windows.Forms.ComboBox comboBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button EnableBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox ModeCombo;
        private System.Windows.Forms.NumericUpDown RedTop;
        private System.Windows.Forms.NumericUpDown GreenTop;
        private System.Windows.Forms.NumericUpDown BlueTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown BlueRight;
        private System.Windows.Forms.NumericUpDown GreenRight;
        private System.Windows.Forms.NumericUpDown RedRight;
        private System.Windows.Forms.GroupBox gpComPort;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gpTopOnExit;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown BlueTopOnExit;
        private System.Windows.Forms.NumericUpDown GreenTopOnExit;
        private System.Windows.Forms.NumericUpDown RedTopOnExit;
        private System.Windows.Forms.PictureBox ColorTopOnExit;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown BlueLeftOnExit;
        private System.Windows.Forms.NumericUpDown GreenLeftOnExit;
        private System.Windows.Forms.NumericUpDown RedLeftOnExit;
        private System.Windows.Forms.PictureBox ColorLeftOnExit;
        private System.Windows.Forms.PictureBox ColorRightOnExit;
        private System.Windows.Forms.NumericUpDown RedRightOnExit;
        private System.Windows.Forms.NumericUpDown GreenRightOnExit;
        private System.Windows.Forms.NumericUpDown BlueRightOnExit;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox ColorLeft;
        private System.Windows.Forms.NumericUpDown RedLeft;
        private System.Windows.Forms.NumericUpDown GreenLeft;
        private System.Windows.Forms.NumericUpDown BlueLeft;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown BlueRightOnStart;
        private System.Windows.Forms.NumericUpDown GreenRightOnStart;
        private System.Windows.Forms.NumericUpDown RedRightOnStart;
        private System.Windows.Forms.PictureBox ColorRightOnStart;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown BlueLeftOnStart;
        private System.Windows.Forms.NumericUpDown GreenLeftOnStart;
        private System.Windows.Forms.NumericUpDown RedLeftOnStart;
        private System.Windows.Forms.PictureBox ColorLeftOnStart;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown BlueTopOnStart;
        private System.Windows.Forms.NumericUpDown GreenTopOnStart;
        private System.Windows.Forms.NumericUpDown RedTopOnStart;
        private System.Windows.Forms.PictureBox ColorTopOnStart;
        private System.Windows.Forms.TextBox ProcessName;
        private System.Windows.Forms.CheckBox AutoEnable;
        private System.Windows.Forms.Timer AutoDetect;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox ShowOutput;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox Controller;
        private System.Windows.Forms.TabPage GammaPage;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox GammaEvent;
        private System.Windows.Forms.RichTextBox GammaTable;
        private System.Windows.Forms.TextBox GammaLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar GammaValue;
        private System.Windows.Forms.TabPage VoodooPage;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox ShowFPS;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown Colorslider;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown MaxSmoothRadiusUpDown;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TrackBar MaxSmoothRadius;
        private System.Windows.Forms.CheckBox DynamicSmoothRadius;
        private System.Windows.Forms.NumericUpDown AggressiveThresholdUpDown;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TrackBar AggressiveThreshold;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox ModeCombo2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown IntelliInterval;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown DarknessThresholdUpDown;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown QuantizeLevel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar DarknessThreshold;
        private System.Windows.Forms.CheckBox ProgressiveThreshold;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label AggressiveIndicator;
        private System.Windows.Forms.NumericUpDown DynamicRadiusSlideDelayUpDown;
        private System.Windows.Forms.TrackBar DynamicRadiusSlideDelay;
        private System.Windows.Forms.NumericUpDown radiusRight;
        private System.Windows.Forms.NumericUpDown radiusLeft;
        private System.Windows.Forms.NumericUpDown radiusTop;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.NumericUpDown dynamicValueRight;
        private System.Windows.Forms.NumericUpDown dynamicValueTop;
        private System.Windows.Forms.NumericUpDown dynamicValueLeft;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.NumericUpDown dradiusRight;
        private System.Windows.Forms.NumericUpDown dradiusTop;
        private System.Windows.Forms.NumericUpDown dradiusLeft;
        private System.Windows.Forms.PictureBox cRight;
        private System.Windows.Forms.PictureBox cLeft;
        private System.Windows.Forms.PictureBox cTop;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.CheckBox ShowDebugDiag;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.PictureBox voRight;
        private System.Windows.Forms.PictureBox voLeft;
        private System.Windows.Forms.PictureBox voTop;
        private System.Windows.Forms.PictureBox viRight;
        private System.Windows.Forms.PictureBox viLeft;
        private System.Windows.Forms.PictureBox viTop;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.NumericUpDown MinSmoothRadiusUpDown;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TrackBar MinSmoothRadius;
        private System.Windows.Forms.ComboBox DynamicControl;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox DarknessLimitMethod;
        private System.Windows.Forms.NumericUpDown DarknessLimitUpDown;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TrackBar DarknessLimit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage LightsSettings;
    }
}

