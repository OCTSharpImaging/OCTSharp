using DALSA.SaperaLT.SapClassBasic;
using ManagedCuda.CudaBlas;
using NationalInstruments.DAQmx;
using System;
using System.Windows.Forms;


namespace OCTSharp
{
    partial class MainDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.physicalChannelComboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxVolBox = new System.Windows.Forms.TextBox();
            this.minVolBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.amplitudeNumeric = new System.Windows.Forms.NumericUpDown();
            this.CameraLineRateBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PreviewBotton = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.cameraFilePathBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.counterBox = new System.Windows.Forms.TextBox();
            this.ScanSaveButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.SaveFilePathBox = new System.Windows.Forms.TextBox();
            this.browseWriteButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SampleClockSrc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rNumBox = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.fNumBox = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.pixelDepthBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.aNumBox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.bNumBox = new System.Windows.Forms.NumericUpDown();
            this.cNumBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CalibrationButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.ProcessBufferTimeLabel = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.MaxBar = new System.Windows.Forms.TrackBar();
            this.MinBar = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.MulBarText = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.MulBar = new System.Windows.Forms.TrackBar();
            this.AddBarText = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.AddBar = new System.Windows.Forms.TrackBar();
            this.saveRawFileBox = new System.Windows.Forms.CheckBox();
            this.SavePostFileBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.calibrationBox = new System.Windows.Forms.CheckBox();
            this.ModifyCalibCurveBtn = new System.Windows.Forms.Button();
            this.Calib_dBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.CalibCurveBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Calib_cBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Calib_bBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Calib_aBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MinBarText = new System.Windows.Forms.Label();
            this.MaxBarText = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.enfaceBox = new System.Windows.Forms.CheckBox();
            this.SpecVarBox = new System.Windows.Forms.CheckBox();
            this.AvgNumBox = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.AvgBox = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeNumeric)).BeginInit();
            this.Camera.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MulBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvgNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.physicalChannelComboBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.maxVolBox);
            this.groupBox1.Controls.Add(this.minVolBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.amplitudeLabel);
            this.groupBox1.Controls.Add(this.physicalChannelComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.amplitudeNumeric);
            this.groupBox1.Location = new System.Drawing.Point(26, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(369, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scanner Parameters";
            // 
            // physicalChannelComboBox2
            // 
            this.physicalChannelComboBox2.FormattingEnabled = true;
            this.physicalChannelComboBox2.Location = new System.Drawing.Point(162, 102);
            this.physicalChannelComboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.physicalChannelComboBox2.Name = "physicalChannelComboBox2";
            this.physicalChannelComboBox2.Size = new System.Drawing.Size(180, 28);
            this.physicalChannelComboBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Scanner Arm 2";
            // 
            // maxVolBox
            // 
            this.maxVolBox.Location = new System.Drawing.Point(162, 223);
            this.maxVolBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxVolBox.Name = "maxVolBox";
            this.maxVolBox.Size = new System.Drawing.Size(180, 26);
            this.maxVolBox.TabIndex = 5;
            this.maxVolBox.Text = "2";
            // 
            // minVolBox
            // 
            this.minVolBox.Location = new System.Drawing.Point(162, 166);
            this.minVolBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minVolBox.Name = "minVolBox";
            this.minVolBox.Size = new System.Drawing.Size(180, 26);
            this.minVolBox.TabIndex = 4;
            this.minVolBox.Text = "-2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maximum Value(V)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum Value(V)";
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.amplitudeLabel.Location = new System.Drawing.Point(15, 266);
            this.amplitudeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(114, 31);
            this.amplitudeLabel.TabIndex = 6;
            this.amplitudeLabel.Text = "Amplitude (Volt)";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.FormattingEnabled = true;
            this.physicalChannelComboBox.Location = new System.Drawing.Point(162, 29);
            this.physicalChannelComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(180, 28);
            this.physicalChannelComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scanner Arm 1";
            // 
            // amplitudeNumeric
            // 
            this.amplitudeNumeric.DecimalPlaces = 2;
            this.amplitudeNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.amplitudeNumeric.Location = new System.Drawing.Point(162, 263);
            this.amplitudeNumeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.amplitudeNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.amplitudeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.amplitudeNumeric.Name = "amplitudeNumeric";
            this.amplitudeNumeric.Size = new System.Drawing.Size(182, 26);
            this.amplitudeNumeric.TabIndex = 7;
            this.amplitudeNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // CameraLineRateBox
            // 
            this.CameraLineRateBox.Location = new System.Drawing.Point(162, 37);
            this.CameraLineRateBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CameraLineRateBox.Name = "CameraLineRateBox";
            this.CameraLineRateBox.Size = new System.Drawing.Size(180, 26);
            this.CameraLineRateBox.TabIndex = 6;
            this.CameraLineRateBox.Text = "147724";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Line Rate (Hz)";
            // 
            // PreviewBotton
            // 
            this.PreviewBotton.Location = new System.Drawing.Point(45, 1628);
            this.PreviewBotton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PreviewBotton.Name = "PreviewBotton";
            this.PreviewBotton.Size = new System.Drawing.Size(312, 52);
            this.PreviewBotton.TabIndex = 2;
            this.PreviewBotton.Text = "LIVE";
            this.PreviewBotton.UseVisualStyleBackColor = true;
            this.PreviewBotton.Click += new System.EventHandler(this.PreviewBotton_Click);
            // 
            // Camera
            // 
            this.Camera.Controls.Add(this.label7);
            this.Camera.Controls.Add(this.BrowseButton);
            this.Camera.Controls.Add(this.cameraFilePathBox);
            this.Camera.Controls.Add(this.CameraLineRateBox);
            this.Camera.Controls.Add(this.label4);
            this.Camera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Camera.Location = new System.Drawing.Point(26, 357);
            this.Camera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Camera.Name = "Camera";
            this.Camera.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Camera.Size = new System.Drawing.Size(369, 158);
            this.Camera.TabIndex = 5;
            this.Camera.TabStop = false;
            this.Camera.Text = "Camera";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Camera File";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(250, 112);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(111, 35);
            this.BrowseButton.TabIndex = 20;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // cameraFilePathBox
            // 
            this.cameraFilePathBox.Location = new System.Drawing.Point(9, 117);
            this.cameraFilePathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cameraFilePathBox.Name = "cameraFilePathBox";
            this.cameraFilePathBox.Size = new System.Drawing.Size(236, 26);
            this.cameraFilePathBox.TabIndex = 19;
            this.cameraFilePathBox.Text = "D:\\Weihao Chen\\Camera File\\SUI_GL2048R_4X_1Y_test.ccf";
            this.cameraFilePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Acquisition Trigger ";
            // 
            // counterBox
            // 
            this.counterBox.Location = new System.Drawing.Point(162, 108);
            this.counterBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.counterBox.Name = "counterBox";
            this.counterBox.Size = new System.Drawing.Size(169, 26);
            this.counterBox.TabIndex = 13;
            this.counterBox.Text = "/Dev1/ctr0";
            // 
            // ScanSaveButton
            // 
            this.ScanSaveButton.Location = new System.Drawing.Point(46, 1748);
            this.ScanSaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScanSaveButton.Name = "ScanSaveButton";
            this.ScanSaveButton.Size = new System.Drawing.Size(312, 48);
            this.ScanSaveButton.TabIndex = 16;
            this.ScanSaveButton.Text = "SAVE";
            this.ScanSaveButton.UseVisualStyleBackColor = true;
            this.ScanSaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(45, 1689);
            this.EndButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(312, 49);
            this.EndButton.TabIndex = 17;
            this.EndButton.Text = "STOP";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // SaveFilePathBox
            // 
            this.SaveFilePathBox.Location = new System.Drawing.Point(98, 68);
            this.SaveFilePathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveFilePathBox.Name = "SaveFilePathBox";
            this.SaveFilePathBox.Size = new System.Drawing.Size(198, 26);
            this.SaveFilePathBox.TabIndex = 18;
            this.SaveFilePathBox.Text = "C:\\Desktop";
            // 
            // browseWriteButton
            // 
            this.browseWriteButton.Location = new System.Drawing.Point(315, 63);
            this.browseWriteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseWriteButton.Name = "browseWriteButton";
            this.browseWriteButton.Size = new System.Drawing.Size(46, 35);
            this.browseWriteButton.TabIndex = 19;
            this.browseWriteButton.Text = "...";
            this.browseWriteButton.UseVisualStyleBackColor = true;
            this.browseWriteButton.Click += new System.EventHandler(this.browseWriteButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Select Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SampleClockSrc);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.counterBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(26, 818);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(369, 154);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trigger";
            // 
            // SampleClockSrc
            // 
            this.SampleClockSrc.Location = new System.Drawing.Point(159, 42);
            this.SampleClockSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SampleClockSrc.Name = "SampleClockSrc";
            this.SampleClockSrc.Size = new System.Drawing.Size(169, 26);
            this.SampleClockSrc.TabIndex = 15;
            this.SampleClockSrc.Text = "/Dev1/PFI0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Line Rate Source";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rNumBox);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.fNumBox);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.pixelDepthBox);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.aNumBox);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.bNumBox);
            this.groupBox3.Controls.Add(this.cNumBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(26, 515);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(369, 305);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OCT ";
            // 
            // rNumBox
            // 
            this.rNumBox.Location = new System.Drawing.Point(174, 265);
            this.rNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rNumBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.rNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rNumBox.Name = "rNumBox";
            this.rNumBox.Size = new System.Drawing.Size(170, 26);
            this.rNumBox.TabIndex = 27;
            this.rNumBox.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(21, 265);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 20);
            this.label28.TabIndex = 26;
            this.label28.Text = "R-Num";
            // 
            // fNumBox
            // 
            this.fNumBox.Location = new System.Drawing.Point(174, 222);
            this.fNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fNumBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fNumBox.Name = "fNumBox";
            this.fNumBox.Size = new System.Drawing.Size(170, 26);
            this.fNumBox.TabIndex = 25;
            this.fNumBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(21, 222);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 20);
            this.label21.TabIndex = 24;
            this.label21.Text = "F-Num";
            // 
            // pixelDepthBox
            // 
            this.pixelDepthBox.FormattingEnabled = true;
            this.pixelDepthBox.Location = new System.Drawing.Point(174, 29);
            this.pixelDepthBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pixelDepthBox.Name = "pixelDepthBox";
            this.pixelDepthBox.Size = new System.Drawing.Size(166, 28);
            this.pixelDepthBox.TabIndex = 23;
            this.pixelDepthBox.Text = "12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Pixel Depth";
            // 
            // aNumBox
            // 
            this.aNumBox.Location = new System.Drawing.Point(174, 77);
            this.aNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aNumBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.aNumBox.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.aNumBox.Name = "aNumBox";
            this.aNumBox.Size = new System.Drawing.Size(170, 26);
            this.aNumBox.TabIndex = 15;
            this.aNumBox.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 77);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "A-Num";
            // 
            // bNumBox
            // 
            this.bNumBox.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.bNumBox.Location = new System.Drawing.Point(172, 125);
            this.bNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bNumBox.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.bNumBox.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.bNumBox.Name = "bNumBox";
            this.bNumBox.Size = new System.Drawing.Size(170, 26);
            this.bNumBox.TabIndex = 13;
            this.bNumBox.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.bNumBox.ValueChanged += new System.EventHandler(this.bNumBox_ValueChanged);
            // 
            // cNumBox
            // 
            this.cNumBox.Location = new System.Drawing.Point(172, 172);
            this.cNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cNumBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.cNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cNumBox.Name = "cNumBox";
            this.cNumBox.Size = new System.Drawing.Size(170, 26);
            this.cNumBox.TabIndex = 9;
            this.cNumBox.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "C-Num";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 128);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "B-Num";
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "FileDialog";
            // 
            // folderDialog
            // 
            this.folderDialog.SelectedPath = "C:\\";
            // 
            // CalibrationButton
            // 
            this.CalibrationButton.Location = new System.Drawing.Point(8, 62);
            this.CalibrationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CalibrationButton.Name = "CalibrationButton";
            this.CalibrationButton.Size = new System.Drawing.Size(130, 34);
            this.CalibrationButton.TabIndex = 24;
            this.CalibrationButton.Text = "Import Calibration Curve";
            this.CalibrationButton.UseVisualStyleBackColor = true;
            this.CalibrationButton.Click += new System.EventHandler(this.CalibrationButton_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1924, 802);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 20);
            this.label17.TabIndex = 31;
            this.label17.Text = "FPS:";
            // 
            // ProcessBufferTimeLabel
            // 
            this.ProcessBufferTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessBufferTimeLabel.AutoSize = true;
            this.ProcessBufferTimeLabel.Location = new System.Drawing.Point(1962, 802);
            this.ProcessBufferTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProcessBufferTimeLabel.Name = "ProcessBufferTimeLabel";
            this.ProcessBufferTimeLabel.Size = new System.Drawing.Size(18, 20);
            this.ProcessBufferTimeLabel.TabIndex = 32;
            this.ProcessBufferTimeLabel.Text = "0";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chart.BorderlineColor = System.Drawing.SystemColors.AppWorkspace;
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Location = new System.Drawing.Point(2014, 31);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.IsVisibleInLegend = false;
            series3.Name = "spectrum";
            series3.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1098, 769);
            this.chart.TabIndex = 33;
            this.chart.Text = "chart";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(482, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.AppWorkspace;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(2014, 809);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.IsVisibleInLegend = false;
            series4.Name = "spectrum";
            series4.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1108, 820);
            this.chart1.TabIndex = 35;
            this.chart1.Text = "chart1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(3818, -6);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 1629);
            this.vScrollBar1.TabIndex = 36;
            // 
            // MaxBar
            // 
            this.MaxBar.Location = new System.Drawing.Point(57, 28);
            this.MaxBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaxBar.Maximum = 255;
            this.MaxBar.Minimum = 100;
            this.MaxBar.Name = "MaxBar";
            this.MaxBar.Size = new System.Drawing.Size(304, 69);
            this.MaxBar.TabIndex = 38;
            this.MaxBar.Value = 255;
            this.MaxBar.Scroll += new System.EventHandler(this.MaxBar_Scroll);
            // 
            // MinBar
            // 
            this.MinBar.Location = new System.Drawing.Point(424, 28);
            this.MinBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinBar.Maximum = 100;
            this.MinBar.Minimum = 1;
            this.MinBar.Name = "MinBar";
            this.MinBar.Size = new System.Drawing.Size(308, 69);
            this.MinBar.TabIndex = 39;
            this.MinBar.Value = 1;
            this.MinBar.Scroll += new System.EventHandler(this.MinBar_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 20);
            this.label19.TabIndex = 40;
            this.label19.Text = "Max";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(388, 35);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "Min";
            // 
            // MulBarText
            // 
            this.MulBarText.AutoSize = true;
            this.MulBarText.Location = new System.Drawing.Point(776, 51);
            this.MulBarText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MulBarText.Name = "MulBarText";
            this.MulBarText.Size = new System.Drawing.Size(45, 20);
            this.MulBarText.TabIndex = 259;
            this.MulBarText.Text = "1000";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(782, 31);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 20);
            this.label23.TabIndex = 258;
            this.label23.Text = "Mul";
            // 
            // MulBar
            // 
            this.MulBar.LargeChange = 100;
            this.MulBar.Location = new System.Drawing.Point(828, 28);
            this.MulBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MulBar.Maximum = 2500;
            this.MulBar.Minimum = 1;
            this.MulBar.Name = "MulBar";
            this.MulBar.Size = new System.Drawing.Size(291, 69);
            this.MulBar.TabIndex = 257;
            this.MulBar.Value = 1000;
            this.MulBar.Scroll += new System.EventHandler(this.MulBar_Scroll);
            // 
            // AddBarText
            // 
            this.AddBarText.AutoSize = true;
            this.AddBarText.Location = new System.Drawing.Point(1176, 51);
            this.AddBarText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddBarText.Name = "AddBarText";
            this.AddBarText.Size = new System.Drawing.Size(31, 20);
            this.AddBarText.TabIndex = 262;
            this.AddBarText.Text = "0.0";
            this.AddBarText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1176, 31);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 20);
            this.label24.TabIndex = 261;
            this.label24.Text = "Add";
            // 
            // AddBar
            // 
            this.AddBar.Location = new System.Drawing.Point(1226, 28);
            this.AddBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddBar.Maximum = 100;
            this.AddBar.Name = "AddBar";
            this.AddBar.Size = new System.Drawing.Size(249, 69);
            this.AddBar.TabIndex = 260;
            this.AddBar.Scroll += new System.EventHandler(this.AddBar_Scroll);
            // 
            // saveRawFileBox
            // 
            this.saveRawFileBox.AutoSize = true;
            this.saveRawFileBox.Location = new System.Drawing.Point(112, 29);
            this.saveRawFileBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveRawFileBox.Name = "saveRawFileBox";
            this.saveRawFileBox.Size = new System.Drawing.Size(67, 24);
            this.saveRawFileBox.TabIndex = 263;
            this.saveRawFileBox.Text = "Raw";
            this.saveRawFileBox.UseVisualStyleBackColor = true;
            // 
            // SavePostFileBox
            // 
            this.SavePostFileBox.AutoSize = true;
            this.SavePostFileBox.Location = new System.Drawing.Point(228, 29);
            this.SavePostFileBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SavePostFileBox.Name = "SavePostFileBox";
            this.SavePostFileBox.Size = new System.Drawing.Size(67, 24);
            this.SavePostFileBox.TabIndex = 264;
            this.SavePostFileBox.Text = "Post";
            this.SavePostFileBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.calibrationBox);
            this.groupBox4.Controls.Add(this.ModifyCalibCurveBtn);
            this.groupBox4.Controls.Add(this.Calib_dBox);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.CalibCurveBox);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.Calib_cBox);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.Calib_bBox);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.Calib_aBox);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.CalibrationButton);
            this.groupBox4.Location = new System.Drawing.Point(26, 1126);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(369, 338);
            this.groupBox4.TabIndex = 265;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3rd order Calibration";
            // 
            // calibrationBox
            // 
            this.calibrationBox.AutoSize = true;
            this.calibrationBox.Location = new System.Drawing.Point(8, 28);
            this.calibrationBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calibrationBox.Name = "calibrationBox";
            this.calibrationBox.Size = new System.Drawing.Size(85, 24);
            this.calibrationBox.TabIndex = 268;
            this.calibrationBox.Text = "Enable";
            this.calibrationBox.UseVisualStyleBackColor = true;
            // 
            // ModifyCalibCurveBtn
            // 
            this.ModifyCalibCurveBtn.Location = new System.Drawing.Point(162, 62);
            this.ModifyCalibCurveBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ModifyCalibCurveBtn.Name = "ModifyCalibCurveBtn";
            this.ModifyCalibCurveBtn.Size = new System.Drawing.Size(148, 34);
            this.ModifyCalibCurveBtn.TabIndex = 33;
            this.ModifyCalibCurveBtn.Text = "Modify";
            this.ModifyCalibCurveBtn.UseVisualStyleBackColor = true;
            this.ModifyCalibCurveBtn.Click += new System.EventHandler(this.ModifyCalibCurveBtn_Click);
            // 
            // Calib_dBox
            // 
            this.Calib_dBox.Location = new System.Drawing.Point(162, 294);
            this.Calib_dBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Calib_dBox.Name = "Calib_dBox";
            this.Calib_dBox.Size = new System.Drawing.Size(169, 26);
            this.Calib_dBox.TabIndex = 32;
            this.Calib_dBox.Text = "0.00";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 298);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(18, 20);
            this.label22.TabIndex = 31;
            this.label22.Text = "d";
            // 
            // CalibCurveBox
            // 
            this.CalibCurveBox.Location = new System.Drawing.Point(69, 114);
            this.CalibCurveBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CalibCurveBox.Name = "CalibCurveBox";
            this.CalibCurveBox.Size = new System.Drawing.Size(260, 26);
            this.CalibCurveBox.TabIndex = 30;
            this.CalibCurveBox.Text = "K = d + c*X + b*X^2 + a*X^3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 114);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Cruve";
            // 
            // Calib_cBox
            // 
            this.Calib_cBox.Location = new System.Drawing.Point(162, 249);
            this.Calib_cBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Calib_cBox.Name = "Calib_cBox";
            this.Calib_cBox.Size = new System.Drawing.Size(169, 26);
            this.Calib_cBox.TabIndex = 28;
            this.Calib_cBox.Text = "1.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 254);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 20);
            this.label18.TabIndex = 27;
            this.label18.Text = "c";
            // 
            // Calib_bBox
            // 
            this.Calib_bBox.Location = new System.Drawing.Point(162, 200);
            this.Calib_bBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Calib_bBox.Name = "Calib_bBox";
            this.Calib_bBox.Size = new System.Drawing.Size(169, 26);
            this.Calib_bBox.TabIndex = 26;
            this.Calib_bBox.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 208);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 20);
            this.label16.TabIndex = 25;
            this.label16.Text = "b";
            // 
            // Calib_aBox
            // 
            this.Calib_aBox.Location = new System.Drawing.Point(162, 154);
            this.Calib_aBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Calib_aBox.Name = "Calib_aBox";
            this.Calib_aBox.Size = new System.Drawing.Size(169, 26);
            this.Calib_aBox.TabIndex = 13;
            this.Calib_aBox.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 158);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "a";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.SaveFilePathBox);
            this.groupBox5.Controls.Add(this.SavePostFileBox);
            this.groupBox5.Controls.Add(this.saveRawFileBox);
            this.groupBox5.Controls.Add(this.browseWriteButton);
            this.groupBox5.Location = new System.Drawing.Point(26, 982);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(369, 122);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.MinBarText);
            this.groupBox6.Controls.Add(this.MaxBarText);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.MaxBar);
            this.groupBox6.Controls.Add(this.MinBar);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.MulBar);
            this.groupBox6.Controls.Add(this.AddBarText);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.MulBarText);
            this.groupBox6.Controls.Add(this.AddBar);
            this.groupBox6.Location = new System.Drawing.Point(482, 1660);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(1500, 112);
            this.groupBox6.TabIndex = 266;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contrast";
            // 
            // MinBarText
            // 
            this.MinBarText.AutoSize = true;
            this.MinBarText.Location = new System.Drawing.Point(396, 60);
            this.MinBarText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinBarText.Name = "MinBarText";
            this.MinBarText.Size = new System.Drawing.Size(18, 20);
            this.MinBarText.TabIndex = 264;
            this.MinBarText.Text = "1";
            // 
            // MaxBarText
            // 
            this.MaxBarText.AutoSize = true;
            this.MaxBarText.Location = new System.Drawing.Point(15, 57);
            this.MaxBarText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxBarText.Name = "MaxBarText";
            this.MaxBarText.Size = new System.Drawing.Size(36, 20);
            this.MaxBarText.TabIndex = 263;
            this.MaxBarText.Text = "255";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.enfaceBox);
            this.groupBox7.Controls.Add(this.SpecVarBox);
            this.groupBox7.Controls.Add(this.AvgNumBox);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.AvgBox);
            this.groupBox7.Location = new System.Drawing.Point(26, 1478);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(369, 126);
            this.groupBox7.TabIndex = 267;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Display";
            // 
            // enfaceBox
            // 
            this.enfaceBox.AutoSize = true;
            this.enfaceBox.Checked = true;
            this.enfaceBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enfaceBox.Location = new System.Drawing.Point(10, 88);
            this.enfaceBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enfaceBox.Name = "enfaceBox";
            this.enfaceBox.Size = new System.Drawing.Size(145, 24);
            this.enfaceBox.TabIndex = 269;
            this.enfaceBox.Text = "Enable En-face";
            this.enfaceBox.UseVisualStyleBackColor = true;
            // 
            // SpecVarBox
            // 
            this.SpecVarBox.AutoSize = true;
            this.SpecVarBox.Checked = true;
            this.SpecVarBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpecVarBox.Location = new System.Drawing.Point(10, 57);
            this.SpecVarBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpecVarBox.Name = "SpecVarBox";
            this.SpecVarBox.Size = new System.Drawing.Size(140, 24);
            this.SpecVarBox.TabIndex = 268;
            this.SpecVarBox.Text = "Enable Variant";
            this.SpecVarBox.UseVisualStyleBackColor = true;
            // 
            // AvgNumBox
            // 
            this.AvgNumBox.Location = new System.Drawing.Point(164, 28);
            this.AvgNumBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvgNumBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.AvgNumBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AvgNumBox.Name = "AvgNumBox";
            this.AvgNumBox.Size = new System.Drawing.Size(63, 26);
            this.AvgNumBox.TabIndex = 267;
            this.AvgNumBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(236, 31);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(126, 20);
            this.label25.TabIndex = 266;
            this.label25.Text = "Frames Average";
            // 
            // AvgBox
            // 
            this.AvgBox.AutoSize = true;
            this.AvgBox.Location = new System.Drawing.Point(10, 28);
            this.AvgBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvgBox.Name = "AvgBox";
            this.AvgBox.Size = new System.Drawing.Size(116, 24);
            this.AvgBox.TabIndex = 264;
            this.AvgBox.Text = "Enable Avg";
            this.AvgBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(482, 835);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1000, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 268;
            this.pictureBox2.TabStop = false;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(477, 3);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(122, 20);
            this.label26.TabIndex = 269;
            this.label26.Text = "B-Scan Window";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(477, 802);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(130, 20);
            this.label27.TabIndex = 270;
            this.label27.Text = "En-Face Window";
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(3269, 1818);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.ProcessBufferTimeLabel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ScanSaveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.Camera);
            this.Controls.Add(this.PreviewBotton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainDlg";
            this.Text = "OCTSharp v1.4.6";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeNumeric)).EndInit();
            this.Camera.ResumeLayout(false);
            this.Camera.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MulBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvgNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox maxVolBox;
        private System.Windows.Forms.TextBox minVolBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CameraLineRateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PreviewBotton;
        private System.Windows.Forms.GroupBox Camera;
        internal System.Windows.Forms.Label amplitudeLabel;
        internal System.Windows.Forms.NumericUpDown amplitudeNumeric;
        private ComboBox physicalChannelComboBox2;
        private Label label5;
        private Label label8;
        private TextBox counterBox;
        private Button ScanSaveButton;
        private Button EndButton;
        private TextBox SaveFilePathBox;
        private Button browseWriteButton;
        private Label label10;

        //DEBUG
        float[] dfs = new float[2048];

        //File IO
        private double[] phaseAry;
        private double[] evenPhaseAry;
        private float[] fpixel;
        private int avgNum;
        private float grayMax;
        private float grayMin;
        private float grayMul;
        private float grayAdd;
        private ushort[] SpectrumArray;
        public IntPtr acqbufferPtr;
        public string Calib_a;
        public string Calib_b;
        public string Calib_c;
        public string Calib_d;

        //DAQmx
        private Task AOTask;
        public AnalogMultiChannelWriter AOWriter;
        private Task COTask;
        private double maxXVolt;
        private double minXVolt;
        private int SampleClockRate;
        private int aNum;
        private int bNum;
        private int cNum;
        private int rNum;
        private double stepY;
        private double[,] ScanArray;
        private double FbaseX;
        private double BbaseX;
        private double baseY;
        private double amp;
        private int stepNum;
        private string counterTer;
        private int fNum;
        private int tNum;
        private int currRawNum;
        private int postBufferidx;
        private int enFaceLineIndex;

        //MX4
        private string cameraFilePath;
        private string saveFilePath;
        private SapAcquisition acq;
        private SapBuffer acqBuffer;
        private SapBuffer rawBuffer;
        private SapBuffer postBuffer;
        private SapBuffer disBuffer;
        private SapBuffer enFaceBuffer;
        private int pixelDepth;
        private SapTransfer transfer;
        private bool SaveCScanMode;
        private bool PreviewMode;
        private bool isScaning;
        private SapProcessing process;
        private SapView BScanView;
        private SapView EnFaceView;
        private ProcessClass disprocess;
        private CudaBlas cudablas_handle = new CudaBlas();
        private int AvgNum;
        private bool isCalib = false;
        private bool isAvg = false;
        private bool isSpecVar = false;
        private bool isEnface = false;
        private bool abort = false;
        //UI
        private Label label7;
        private Button BrowseButton;
        private TextBox cameraFilePathBox;
        private TextBox SampleClockSrc;
        private Label label6;
        private GroupBox groupBox3;
        private NumericUpDown bNumBox;
        private NumericUpDown cNumBox;
        private Label label9;
        private Label label11;
        private OpenFileDialog FileDialog;
        private FolderBrowserDialog folderDialog;
        private Label label13;
        private NumericUpDown aNumBox;
        private Label label12;
        private ComboBox pixelDepthBox;
        private Button CalibrationButton;
        private GroupBox groupBox2;      
        private Label label17;
        private Label ProcessBufferTimeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private VScrollBar vScrollBar1;
        private TrackBar MaxBar;
        private TrackBar MinBar;
        private Label label19;
        private Label label20;
        private NumericUpDown fNumBox;
        private Label label21;
        private Label MulBarText;
        private Label label23;
        private TrackBar MulBar;
        private Label AddBarText;
        private Label label24;
        private TrackBar AddBar;
        private CheckBox saveRawFileBox;
        private CheckBox SavePostFileBox;
        private string RawFilePath;
        private int RawFilePathNum = 1;
        private string PostFilePath;
        private int PostFilePathNum = 1;
        private GroupBox groupBox4;
        private Label label15;
        private TextBox CalibCurveBox;
        private Label label14;
        private TextBox Calib_cBox;
        private Label label18;
        private TextBox Calib_bBox;
        private Label label16;
        private TextBox Calib_aBox;
        private TextBox Calib_dBox;
        private Label label22;
        private Button ModifyCalibCurveBtn;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label MinBarText;
        private Label MaxBarText;
        private GroupBox groupBox7;
        private NumericUpDown AvgNumBox;
        private Label label25;
        private CheckBox AvgBox;
        private CheckBox calibrationBox;
        private CheckBox SpecVarBox;
        private PictureBox pictureBox2;
        private Label label26;
        private Label label27;
        private CheckBox enfaceBox;
        private NumericUpDown rNumBox;
        private Label label28;
    }
}
