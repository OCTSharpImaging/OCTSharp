using DALSA.SaperaLT.SapClassBasic;
using ManagedCuda.CudaBlas;
using NationalInstruments.DAQmx;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
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
            this.ScanBotton = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.cameraFilePathBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.counterBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SaveFilePathBox = new System.Windows.Forms.TextBox();
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
            this.label17 = new System.Windows.Forms.Label();
            this.AcqRateLabel = new System.Windows.Forms.Label();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CalBroBtn = new System.Windows.Forms.Button();
            this.CalibrationCurveTextBox = new System.Windows.Forms.TextBox();
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
            this.browseWriteButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MinBarText = new System.Windows.Forms.Label();
            this.MaxBarText = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.FPSBox = new System.Windows.Forms.CheckBox();
            this.FFTBox = new System.Windows.Forms.CheckBox();
            this.SpectrumBox = new System.Windows.Forms.CheckBox();
            this.enfaceBox = new System.Windows.Forms.CheckBox();
            this.SpecVarBox = new System.Windows.Forms.CheckBox();
            this.AvgNumBox = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.AvgBox = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.processRateLabel = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadProcessButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.BenchmarkLog = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.DisplayRateLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.BenchmarkLog.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(35, 246);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(492, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scanner Parameters";
            // 
            // physicalChannelComboBox2
            // 
            this.physicalChannelComboBox2.FormattingEnabled = true;
            this.physicalChannelComboBox2.Location = new System.Drawing.Point(216, 128);
            this.physicalChannelComboBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.physicalChannelComboBox2.Name = "physicalChannelComboBox2";
            this.physicalChannelComboBox2.Size = new System.Drawing.Size(239, 33);
            this.physicalChannelComboBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Scanner Arm 2";
            // 
            // maxVolBox
            // 
            this.maxVolBox.Location = new System.Drawing.Point(216, 279);
            this.maxVolBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.maxVolBox.Name = "maxVolBox";
            this.maxVolBox.Size = new System.Drawing.Size(239, 31);
            this.maxVolBox.TabIndex = 5;
            this.maxVolBox.Text = "1.5";
            // 
            // minVolBox
            // 
            this.minVolBox.Location = new System.Drawing.Point(216, 208);
            this.minVolBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.minVolBox.Name = "minVolBox";
            this.minVolBox.Size = new System.Drawing.Size(239, 31);
            this.minVolBox.TabIndex = 4;
            this.minVolBox.Text = "-1.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maximum Value(V)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum Value(V)";
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.amplitudeLabel.Location = new System.Drawing.Point(20, 332);
            this.amplitudeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(152, 39);
            this.amplitudeLabel.TabIndex = 6;
            this.amplitudeLabel.Text = "Amplitude (Volt)";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.FormattingEnabled = true;
            this.physicalChannelComboBox.Location = new System.Drawing.Point(216, 36);
            this.physicalChannelComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(239, 33);
            this.physicalChannelComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
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
            this.amplitudeNumeric.Location = new System.Drawing.Point(216, 329);
            this.amplitudeNumeric.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.amplitudeNumeric.Size = new System.Drawing.Size(243, 31);
            this.amplitudeNumeric.TabIndex = 7;
            this.amplitudeNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CameraLineRateBox
            // 
            this.CameraLineRateBox.Location = new System.Drawing.Point(216, 46);
            this.CameraLineRateBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CameraLineRateBox.Name = "CameraLineRateBox";
            this.CameraLineRateBox.Size = new System.Drawing.Size(239, 31);
            this.CameraLineRateBox.TabIndex = 6;
            this.CameraLineRateBox.Text = "147724";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Line Rate (Hz)";
            // 
            // ScanBotton
            // 
            this.ScanBotton.Location = new System.Drawing.Point(4204, 98);
            this.ScanBotton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ScanBotton.Name = "ScanBotton";
            this.ScanBotton.Size = new System.Drawing.Size(792, 65);
            this.ScanBotton.TabIndex = 2;
            this.ScanBotton.Text = "Scan";
            this.ScanBotton.UseVisualStyleBackColor = true;
            this.ScanBotton.Click += new System.EventHandler(this.PreviewBotton_Click);
            // 
            // Camera
            // 
            this.Camera.Controls.Add(this.label7);
            this.Camera.Controls.Add(this.BrowseButton);
            this.Camera.Controls.Add(this.cameraFilePathBox);
            this.Camera.Controls.Add(this.CameraLineRateBox);
            this.Camera.Controls.Add(this.label4);
            this.Camera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Camera.Location = new System.Drawing.Point(35, 4);
            this.Camera.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Camera.Name = "Camera";
            this.Camera.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Camera.Size = new System.Drawing.Size(492, 229);
            this.Camera.TabIndex = 5;
            this.Camera.TabStop = false;
            this.Camera.Text = "Camera";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Camera File";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(333, 140);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(148, 44);
            this.BrowseButton.TabIndex = 20;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // cameraFilePathBox
            // 
            this.cameraFilePathBox.Location = new System.Drawing.Point(12, 146);
            this.cameraFilePathBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cameraFilePathBox.Name = "cameraFilePathBox";
            this.cameraFilePathBox.Size = new System.Drawing.Size(313, 31);
            this.cameraFilePathBox.TabIndex = 19;
            this.cameraFilePathBox.Text = "D:\\Weihao Chen\\Camera File\\SUI_GL2048R_4X_1Y_test.ccf";
            this.cameraFilePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Acquisition Trigger ";
            // 
            // counterBox
            // 
            this.counterBox.Location = new System.Drawing.Point(216, 135);
            this.counterBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.counterBox.Name = "counterBox";
            this.counterBox.Size = new System.Drawing.Size(224, 31);
            this.counterBox.TabIndex = 13;
            this.counterBox.Text = "/Dev1/ctr0";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(4205, 248);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(792, 60);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(4204, 175);
            this.StopButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(792, 61);
            this.StopButton.TabIndex = 17;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // SaveFilePathBox
            // 
            this.SaveFilePathBox.Location = new System.Drawing.Point(131, 85);
            this.SaveFilePathBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SaveFilePathBox.Name = "SaveFilePathBox";
            this.SaveFilePathBox.Size = new System.Drawing.Size(263, 31);
            this.SaveFilePathBox.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Select Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SampleClockSrc);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.counterBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(35, 1022);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(492, 192);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trigger";
            // 
            // SampleClockSrc
            // 
            this.SampleClockSrc.Location = new System.Drawing.Point(212, 52);
            this.SampleClockSrc.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SampleClockSrc.Name = "SampleClockSrc";
            this.SampleClockSrc.Size = new System.Drawing.Size(224, 31);
            this.SampleClockSrc.TabIndex = 15;
            this.SampleClockSrc.Text = "/Dev1/PFI0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 25);
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
            this.groupBox3.Location = new System.Drawing.Point(35, 644);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Size = new System.Drawing.Size(492, 381);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OCT ";
            // 
            // rNumBox
            // 
            this.rNumBox.Location = new System.Drawing.Point(232, 331);
            this.rNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.rNumBox.Size = new System.Drawing.Size(227, 31);
            this.rNumBox.TabIndex = 27;
            this.rNumBox.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(28, 331);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(78, 25);
            this.label28.TabIndex = 26;
            this.label28.Text = "R-Num";
            // 
            // fNumBox
            // 
            this.fNumBox.Location = new System.Drawing.Point(232, 278);
            this.fNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.fNumBox.Size = new System.Drawing.Size(227, 31);
            this.fNumBox.TabIndex = 25;
            this.fNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 278);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 25);
            this.label21.TabIndex = 24;
            this.label21.Text = "F-Num";
            // 
            // pixelDepthBox
            // 
            this.pixelDepthBox.FormattingEnabled = true;
            this.pixelDepthBox.Location = new System.Drawing.Point(232, 36);
            this.pixelDepthBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pixelDepthBox.Name = "pixelDepthBox";
            this.pixelDepthBox.Size = new System.Drawing.Size(220, 33);
            this.pixelDepthBox.TabIndex = 23;
            this.pixelDepthBox.Text = "12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 36);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "Pixel Depth";
            // 
            // aNumBox
            // 
            this.aNumBox.Location = new System.Drawing.Point(232, 96);
            this.aNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.aNumBox.Size = new System.Drawing.Size(227, 31);
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
            this.label12.Location = new System.Drawing.Point(29, 96);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 25);
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
            this.bNumBox.Location = new System.Drawing.Point(229, 156);
            this.bNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bNumBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.bNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bNumBox.Name = "bNumBox";
            this.bNumBox.Size = new System.Drawing.Size(227, 31);
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
            this.cNumBox.Location = new System.Drawing.Point(229, 215);
            this.cNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cNumBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.cNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cNumBox.Name = "cNumBox";
            this.cNumBox.Size = new System.Drawing.Size(227, 31);
            this.cNumBox.TabIndex = 9;
            this.cNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 221);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "C-Num";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 160);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
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
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 56);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(287, 25);
            this.label17.TabIndex = 31;
            this.label17.Text = "Acquisition Frame Rate (Hz):";
            // 
            // AcqRateLabel
            // 
            this.AcqRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AcqRateLabel.AutoSize = true;
            this.AcqRateLabel.Location = new System.Drawing.Point(307, 56);
            this.AcqRateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AcqRateLabel.Name = "AcqRateLabel";
            this.AcqRateLabel.Size = new System.Drawing.Size(24, 25);
            this.AcqRateLabel.TabIndex = 32;
            this.AcqRateLabel.Text = "0";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chart.BorderlineColor = System.Drawing.SystemColors.AppWorkspace;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(2685, 39);
            this.chart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.Name = "spectrum";
            series1.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1464, 961);
            this.chart.TabIndex = 33;
            this.chart.Text = "chart";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(643, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(2685, 1011);
            this.chart1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsVisibleInLegend = false;
            series2.Name = "spectrum";
            series2.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1477, 1025);
            this.chart1.TabIndex = 35;
            this.chart1.Text = "chart1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(5091, -8);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 2036);
            this.vScrollBar1.TabIndex = 36;
            // 
            // MaxBar
            // 
            this.MaxBar.Location = new System.Drawing.Point(76, 35);
            this.MaxBar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaxBar.Maximum = 255;
            this.MaxBar.Minimum = 100;
            this.MaxBar.Name = "MaxBar";
            this.MaxBar.Size = new System.Drawing.Size(676, 90);
            this.MaxBar.TabIndex = 38;
            this.MaxBar.Value = 255;
            this.MaxBar.Scroll += new System.EventHandler(this.MaxBar_Scroll);
            // 
            // MinBar
            // 
            this.MinBar.Location = new System.Drawing.Point(72, 139);
            this.MinBar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MinBar.Maximum = 100;
            this.MinBar.Minimum = 1;
            this.MinBar.Name = "MinBar";
            this.MinBar.Size = new System.Drawing.Size(680, 90);
            this.MinBar.TabIndex = 39;
            this.MinBar.Value = 1;
            this.MinBar.Scroll += new System.EventHandler(this.MinBar_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 40);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 25);
            this.label19.TabIndex = 40;
            this.label19.Text = "Max";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 148);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 25);
            this.label20.TabIndex = 41;
            this.label20.Text = "Min";
            // 
            // MulBarText
            // 
            this.MulBarText.AutoSize = true;
            this.MulBarText.Location = new System.Drawing.Point(24, 292);
            this.MulBarText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MulBarText.Name = "MulBarText";
            this.MulBarText.Size = new System.Drawing.Size(60, 25);
            this.MulBarText.TabIndex = 259;
            this.MulBarText.Text = "1000";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(32, 268);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 25);
            this.label23.TabIndex = 258;
            this.label23.Text = "Mul";
            // 
            // MulBar
            // 
            this.MulBar.LargeChange = 100;
            this.MulBar.Location = new System.Drawing.Point(93, 264);
            this.MulBar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MulBar.Maximum = 2500;
            this.MulBar.Minimum = 1;
            this.MulBar.Name = "MulBar";
            this.MulBar.Size = new System.Drawing.Size(659, 90);
            this.MulBar.TabIndex = 257;
            this.MulBar.Value = 1000;
            this.MulBar.Scroll += new System.EventHandler(this.MulBar_Scroll);
            // 
            // AddBarText
            // 
            this.AddBarText.AutoSize = true;
            this.AddBarText.Location = new System.Drawing.Point(28, 406);
            this.AddBarText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AddBarText.Name = "AddBarText";
            this.AddBarText.Size = new System.Drawing.Size(42, 25);
            this.AddBarText.TabIndex = 262;
            this.AddBarText.Text = "0.0";
            this.AddBarText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(28, 381);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 25);
            this.label24.TabIndex = 261;
            this.label24.Text = "Add";
            // 
            // AddBar
            // 
            this.AddBar.Location = new System.Drawing.Point(93, 378);
            this.AddBar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AddBar.Maximum = 100;
            this.AddBar.Name = "AddBar";
            this.AddBar.Size = new System.Drawing.Size(659, 90);
            this.AddBar.TabIndex = 260;
            this.AddBar.Scroll += new System.EventHandler(this.AddBar_Scroll);
            // 
            // saveRawFileBox
            // 
            this.saveRawFileBox.AutoSize = true;
            this.saveRawFileBox.Location = new System.Drawing.Point(21, 36);
            this.saveRawFileBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.saveRawFileBox.Name = "saveRawFileBox";
            this.saveRawFileBox.Size = new System.Drawing.Size(188, 29);
            this.saveRawFileBox.TabIndex = 263;
            this.saveRawFileBox.Text = "Save .Raw File";
            this.saveRawFileBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CalBroBtn);
            this.groupBox4.Controls.Add(this.CalibrationCurveTextBox);
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
            this.groupBox4.Location = new System.Drawing.Point(35, 1408);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Size = new System.Drawing.Size(492, 422);
            this.groupBox4.TabIndex = 265;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3rd order Calibration";
            // 
            // CalBroBtn
            // 
            this.CalBroBtn.Location = new System.Drawing.Point(419, 29);
            this.CalBroBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CalBroBtn.Name = "CalBroBtn";
            this.CalBroBtn.Size = new System.Drawing.Size(61, 44);
            this.CalBroBtn.TabIndex = 264;
            this.CalBroBtn.Text = "...";
            this.CalBroBtn.UseVisualStyleBackColor = true;
            this.CalBroBtn.Click += new System.EventHandler(this.CalBroBtn_Click);
            // 
            // CalibrationCurveTextBox
            // 
            this.CalibrationCurveTextBox.Location = new System.Drawing.Point(131, 32);
            this.CalibrationCurveTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CalibrationCurveTextBox.Name = "CalibrationCurveTextBox";
            this.CalibrationCurveTextBox.Size = new System.Drawing.Size(311, 31);
            this.CalibrationCurveTextBox.TabIndex = 264;
            this.CalibrationCurveTextBox.Text = "@D:\\Weihao Chen\\OCTSharp\\OCTSharp_v1.4.8\\bin\\x64\\Debug\\CalibrationCurve.xlsx";
            // 
            // calibrationBox
            // 
            this.calibrationBox.AutoSize = true;
            this.calibrationBox.Location = new System.Drawing.Point(16, 39);
            this.calibrationBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.calibrationBox.Name = "calibrationBox";
            this.calibrationBox.Size = new System.Drawing.Size(111, 29);
            this.calibrationBox.TabIndex = 268;
            this.calibrationBox.Text = "Enable";
            this.calibrationBox.UseVisualStyleBackColor = true;
            // 
            // ModifyCalibCurveBtn
            // 
            this.ModifyCalibCurveBtn.Location = new System.Drawing.Point(277, 78);
            this.ModifyCalibCurveBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ModifyCalibCurveBtn.Name = "ModifyCalibCurveBtn";
            this.ModifyCalibCurveBtn.Size = new System.Drawing.Size(165, 42);
            this.ModifyCalibCurveBtn.TabIndex = 33;
            this.ModifyCalibCurveBtn.Text = "Modify";
            this.ModifyCalibCurveBtn.UseVisualStyleBackColor = true;
            this.ModifyCalibCurveBtn.Click += new System.EventHandler(this.ModifyCalibCurveBtn_Click);
            // 
            // Calib_dBox
            // 
            this.Calib_dBox.Location = new System.Drawing.Point(216, 368);
            this.Calib_dBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Calib_dBox.Name = "Calib_dBox";
            this.Calib_dBox.Size = new System.Drawing.Size(224, 31);
            this.Calib_dBox.TabIndex = 32;
            this.Calib_dBox.Text = "0.00";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 372);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 25);
            this.label22.TabIndex = 31;
            this.label22.Text = "d";
            // 
            // CalibCurveBox
            // 
            this.CalibCurveBox.Location = new System.Drawing.Point(92, 142);
            this.CalibCurveBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CalibCurveBox.Name = "CalibCurveBox";
            this.CalibCurveBox.Size = new System.Drawing.Size(345, 31);
            this.CalibCurveBox.TabIndex = 30;
            this.CalibCurveBox.Text = "K = d + c*X + b*X^2 + a*X^3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 142);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 25);
            this.label14.TabIndex = 29;
            this.label14.Text = "Cruve";
            // 
            // Calib_cBox
            // 
            this.Calib_cBox.Location = new System.Drawing.Point(216, 311);
            this.Calib_cBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Calib_cBox.Name = "Calib_cBox";
            this.Calib_cBox.Size = new System.Drawing.Size(224, 31);
            this.Calib_cBox.TabIndex = 28;
            this.Calib_cBox.Text = "1.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 318);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 25);
            this.label18.TabIndex = 27;
            this.label18.Text = "c";
            // 
            // Calib_bBox
            // 
            this.Calib_bBox.Location = new System.Drawing.Point(216, 250);
            this.Calib_bBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Calib_bBox.Name = "Calib_bBox";
            this.Calib_bBox.Size = new System.Drawing.Size(224, 31);
            this.Calib_bBox.TabIndex = 26;
            this.Calib_bBox.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 260);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 25);
            this.label16.TabIndex = 25;
            this.label16.Text = "b";
            // 
            // Calib_aBox
            // 
            this.Calib_aBox.Location = new System.Drawing.Point(216, 192);
            this.Calib_aBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Calib_aBox.Name = "Calib_aBox";
            this.Calib_aBox.Size = new System.Drawing.Size(224, 31);
            this.Calib_aBox.TabIndex = 13;
            this.Calib_aBox.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 198);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 25);
            this.label15.TabIndex = 11;
            this.label15.Text = "a";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.SaveFilePathBox);
            this.groupBox5.Controls.Add(this.saveRawFileBox);
            this.groupBox5.Controls.Add(this.browseWriteButton);
            this.groupBox5.Location = new System.Drawing.Point(35, 1228);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Size = new System.Drawing.Size(492, 152);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save";
            // 
            // browseWriteButton
            // 
            this.browseWriteButton.Location = new System.Drawing.Point(420, 79);
            this.browseWriteButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.browseWriteButton.Name = "browseWriteButton";
            this.browseWriteButton.Size = new System.Drawing.Size(61, 44);
            this.browseWriteButton.TabIndex = 19;
            this.browseWriteButton.Text = "...";
            this.browseWriteButton.UseVisualStyleBackColor = true;
            this.browseWriteButton.Click += new System.EventHandler(this.browseWriteButton_Click);
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
            this.groupBox6.Location = new System.Drawing.Point(4204, 372);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox6.Size = new System.Drawing.Size(792, 506);
            this.groupBox6.TabIndex = 266;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contrast";
            // 
            // MinBarText
            // 
            this.MinBarText.AutoSize = true;
            this.MinBarText.Location = new System.Drawing.Point(35, 179);
            this.MinBarText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MinBarText.Name = "MinBarText";
            this.MinBarText.Size = new System.Drawing.Size(24, 25);
            this.MinBarText.TabIndex = 264;
            this.MinBarText.Text = "1";
            // 
            // MaxBarText
            // 
            this.MaxBarText.AutoSize = true;
            this.MaxBarText.Location = new System.Drawing.Point(20, 71);
            this.MaxBarText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MaxBarText.Name = "MaxBarText";
            this.MaxBarText.Size = new System.Drawing.Size(48, 25);
            this.MaxBarText.TabIndex = 263;
            this.MaxBarText.Text = "255";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.FPSBox);
            this.groupBox7.Controls.Add(this.FFTBox);
            this.groupBox7.Controls.Add(this.SpectrumBox);
            this.groupBox7.Controls.Add(this.enfaceBox);
            this.groupBox7.Controls.Add(this.SpecVarBox);
            this.groupBox7.Controls.Add(this.AvgNumBox);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.AvgBox);
            this.groupBox7.Location = new System.Drawing.Point(35, 1848);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(492, 189);
            this.groupBox7.TabIndex = 267;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Display";
            // 
            // FPSBox
            // 
            this.FPSBox.AutoSize = true;
            this.FPSBox.Location = new System.Drawing.Point(212, 71);
            this.FPSBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.FPSBox.Name = "FPSBox";
            this.FPSBox.Size = new System.Drawing.Size(143, 29);
            this.FPSBox.TabIndex = 272;
            this.FPSBox.Text = "FPS Chart";
            this.FPSBox.UseVisualStyleBackColor = true;
            // 
            // FFTBox
            // 
            this.FFTBox.AutoSize = true;
            this.FFTBox.Location = new System.Drawing.Point(212, 35);
            this.FFTBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.FFTBox.Name = "FFTBox";
            this.FFTBox.Size = new System.Drawing.Size(141, 29);
            this.FFTBox.TabIndex = 271;
            this.FFTBox.Text = "FFT Chart";
            this.FFTBox.UseVisualStyleBackColor = true;
            // 
            // SpectrumBox
            // 
            this.SpectrumBox.AutoSize = true;
            this.SpectrumBox.Location = new System.Drawing.Point(12, 35);
            this.SpectrumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SpectrumBox.Name = "SpectrumBox";
            this.SpectrumBox.Size = new System.Drawing.Size(181, 29);
            this.SpectrumBox.TabIndex = 270;
            this.SpectrumBox.Text = "Spctrum Chart";
            this.SpectrumBox.UseVisualStyleBackColor = true;
            // 
            // enfaceBox
            // 
            this.enfaceBox.AutoSize = true;
            this.enfaceBox.Location = new System.Drawing.Point(13, 110);
            this.enfaceBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.enfaceBox.Name = "enfaceBox";
            this.enfaceBox.Size = new System.Drawing.Size(191, 29);
            this.enfaceBox.TabIndex = 269;
            this.enfaceBox.Text = "Enable En-face";
            this.enfaceBox.UseVisualStyleBackColor = true;
            // 
            // SpecVarBox
            // 
            this.SpecVarBox.AutoSize = true;
            this.SpecVarBox.Location = new System.Drawing.Point(13, 71);
            this.SpecVarBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SpecVarBox.Name = "SpecVarBox";
            this.SpecVarBox.Size = new System.Drawing.Size(195, 29);
            this.SpecVarBox.TabIndex = 268;
            this.SpecVarBox.Text = "Speckle Variant";
            this.SpecVarBox.UseVisualStyleBackColor = true;
            // 
            // AvgNumBox
            // 
            this.AvgNumBox.Location = new System.Drawing.Point(180, 140);
            this.AvgNumBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.AvgNumBox.Size = new System.Drawing.Size(84, 31);
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
            this.label25.Location = new System.Drawing.Point(264, 146);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(170, 25);
            this.label25.TabIndex = 266;
            this.label25.Text = "Frames Average";
            // 
            // AvgBox
            // 
            this.AvgBox.AutoSize = true;
            this.AvgBox.Location = new System.Drawing.Point(13, 144);
            this.AvgBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AvgBox.Name = "AvgBox";
            this.AvgBox.Size = new System.Drawing.Size(154, 29);
            this.AvgBox.TabIndex = 264;
            this.AvgBox.Text = "Enable Avg";
            this.AvgBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(643, 1044);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.label26.Location = new System.Drawing.Point(636, 4);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(164, 25);
            this.label26.TabIndex = 269;
            this.label26.Text = "B-Scan Window";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(636, 1002);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(175, 25);
            this.label27.TabIndex = 270;
            this.label27.Text = "En-Face Window";
            // 
            // processRateLabel
            // 
            this.processRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processRateLabel.AutoSize = true;
            this.processRateLabel.Location = new System.Drawing.Point(307, 102);
            this.processRateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.processRateLabel.Name = "processRateLabel";
            this.processRateLabel.Size = new System.Drawing.Size(24, 25);
            this.processRateLabel.TabIndex = 272;
            this.processRateLabel.Text = "0";
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(21, 102);
            this.label30.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(289, 25);
            this.label30.TabIndex = 271;
            this.label30.Text = "Processing Frame Rate (Hz):";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chart2.BorderlineColor = System.Drawing.SystemColors.AppWorkspace;
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            this.chart2.Location = new System.Drawing.Point(29, 189);
            this.chart2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.IsVisibleInLegend = false;
            series3.Name = "spectrum";
            series3.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(693, 648);
            this.chart2.TabIndex = 273;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // LoadProcessButton
            // 
            this.LoadProcessButton.Location = new System.Drawing.Point(197, 72);
            this.LoadProcessButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LoadProcessButton.Name = "LoadProcessButton";
            this.LoadProcessButton.Size = new System.Drawing.Size(416, 60);
            this.LoadProcessButton.TabIndex = 274;
            this.LoadProcessButton.Text = "Load && Process";
            this.LoadProcessButton.UseVisualStyleBackColor = true;
            this.LoadProcessButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.LoadProcessButton);
            this.groupBox8.Location = new System.Drawing.Point(4204, 1810);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox8.Size = new System.Drawing.Size(792, 181);
            this.groupBox8.TabIndex = 275;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Post-Processing";
            // 
            // BenchmarkLog
            // 
            this.BenchmarkLog.Controls.Add(this.label29);
            this.BenchmarkLog.Controls.Add(this.DisplayRateLabel);
            this.BenchmarkLog.Controls.Add(this.chart2);
            this.BenchmarkLog.Controls.Add(this.label30);
            this.BenchmarkLog.Controls.Add(this.label17);
            this.BenchmarkLog.Controls.Add(this.AcqRateLabel);
            this.BenchmarkLog.Controls.Add(this.processRateLabel);
            this.BenchmarkLog.Location = new System.Drawing.Point(4204, 889);
            this.BenchmarkLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BenchmarkLog.Name = "BenchmarkLog";
            this.BenchmarkLog.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BenchmarkLog.Size = new System.Drawing.Size(792, 869);
            this.BenchmarkLog.TabIndex = 276;
            this.BenchmarkLog.TabStop = false;
            this.BenchmarkLog.Text = "Benchmark";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(21, 158);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(268, 25);
            this.label29.TabIndex = 274;
            this.label29.Text = "Display Frame Rate (FPS):";
            // 
            // DisplayRateLabel
            // 
            this.DisplayRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayRateLabel.AutoSize = true;
            this.DisplayRateLabel.Location = new System.Drawing.Point(296, 158);
            this.DisplayRateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DisplayRateLabel.Name = "DisplayRateLabel";
            this.DisplayRateLabel.Size = new System.Drawing.Size(24, 25);
            this.DisplayRateLabel.TabIndex = 275;
            this.DisplayRateLabel.Text = "0";
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(2565, 1328);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.BenchmarkLog);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.Camera);
            this.Controls.Add(this.ScanBotton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainDlg";
            this.Text = "OCTSharp v1.4.8";
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
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.BenchmarkLog.ResumeLayout(false);
            this.BenchmarkLog.PerformLayout();
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
        private System.Windows.Forms.Button ScanBotton;
        private System.Windows.Forms.GroupBox Camera;
        internal System.Windows.Forms.Label amplitudeLabel;
        internal System.Windows.Forms.NumericUpDown amplitudeNumeric;
        private ComboBox physicalChannelComboBox2;
        private Label label5;
        private Label label8;
        private TextBox counterBox;
        private Button SaveButton;
        private Button StopButton;
        private TextBox SaveFilePathBox;
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
        private string openFileName;
        private SapAcquisition acq;
        private SapBuffer acqBuffer;
        private SapBuffer rawBuffer;
        private SapBuffer postBuffer;
        private SapBuffer disBuffer;
        private SapBuffer enFaceDispBuffer;
        private int pixelDepth;
        private SapTransfer transfer;
        private bool SaveCScanMode;
        private bool PreviewMode;
        private bool isScaning;
        private SapProcessing process;
        public int acqRate;
        public int FPS;
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
        private GroupBox groupBox2;      
        private Label label17;
        private Label AcqRateLabel;
        private Series spectrumSeries;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private PictureBox pictureBox1;
        private Series FFTSeries;
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
        private Label processRateLabel;
        private Label label30;
        private Series FPSSeries;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private CheckBox FPSBox;
        private CheckBox FFTBox;
        private CheckBox SpectrumBox;
        private Button LoadProcessButton;
        private GroupBox groupBox8;
        private GroupBox BenchmarkLog;
        private Label label29;
        private Label DisplayRateLabel;
        private StreamWriter fpsFile;
        private Button CalBroBtn;
        private TextBox CalibrationCurveTextBox;
        private Button browseWriteButton;
    }
}
