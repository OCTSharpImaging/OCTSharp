/**
 * Copyright (c) [2021] [Weihao Chen, chenw11@miamioh.edu]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (OCTSharp), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 * */

using NationalInstruments.DAQmx;
using System;
using static System.Math;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DALSA.SaperaLT.SapClassBasic;
using System.Linq;
using MathNet.Numerics;
using System.Threading;
using System.Windows.Controls;

namespace OCTSharp
{

    public partial class MainDlg : Form
    {

        private delegate void DisplayFrameAcquired(int number, bool trash);//delegate for cross thread communication

        //*****************************************************************************************
        //
        //					Constructor
        //
        //*****************************************************************************************
        public MainDlg()
        {
            InitializeComponent();

            //field setting
            maxXVolt = double.Parse(maxVolBox.Text);
            minXVolt = double.Parse(minVolBox.Text); ;
            SampleClockRate = int.Parse(CameraLineRateBox.Text);
            aNum = int.Parse(aNumBox.Text);
            bNum = int.Parse(bNumBox.Text);
            fNum = int.Parse(fNumBox.Text);
            cNum = int.Parse(cNumBox.Text);
            rNum = 150;//fixed size backward path
            tNum = fNum * cNum;//total b-scan number
            currRawNum = 0;
            postBufferidx = 0;
            //enFaceLineIndex = 0;
            stepY = 2 * amp / (cNum - 1);
            ScanArray = new double[2, tNum * (bNum + rNum)];
            FbaseX = minXVolt;
            BbaseX = maxXVolt;
            amp = (double)amplitudeNumeric.Value;
            baseY = -amp;
            stepNum = 0;
            counterTer = counterBox.Text;
            pixelDepth = int.Parse(pixelDepthBox.Text);
            acq = null;
            acqBuffer = null;
            transfer = null;


            //GUI Setting
            //ChannaleComboBox
            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));
            physicalChannelComboBox2.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));

            if (physicalChannelComboBox.Items.Count > 0)
            {
                physicalChannelComboBox.SelectedIndex = 0;
                physicalChannelComboBox2.SelectedIndex = 1;
            }
            //PixelComboBox TODO: The storage array for theses images will be different
            pixelDepthBox.Items.Add("12");
            //pixelDepthBox.Items.Add("8");

        }

        //*****************************************************************************************
        //
        //					Create or Destroy Objects
        //
        //*****************************************************************************************
        private bool CreateObjects()
        {
            fpsFile = new StreamWriter(@"C:\Users\lamata\Desktop\FPS_Stats.txt");
            //update boolean variables
            bool success;
            if (enfaceBox.Checked)
                isEnface = true;
            else
                isEnface = false;

            if (calibrationBox.Checked)
                isCalib = true;
            else isCalib = false;

            if (AvgBox.Checked)
                isAvg = true;
            else if (AvgBox.Checked && fNum != 1)
            {
                AvgNum = fNum;
                AvgNumBox.Value = AvgNum;
            }
            else isAvg = false;

            if (SpecVarBox.Checked)
            {
                isSpecVar = true;
            }
            else isSpecVar = false;
            //UI parameters update
            maxXVolt = double.Parse(maxVolBox.Text);
            minXVolt = double.Parse(minVolBox.Text); ;
            SampleClockRate = int.Parse(CameraLineRateBox.Text);
            aNum = int.Parse(aNumBox.Text);
            bNum = (int)Pow(2, Ceiling(Log(int.Parse(bNumBox.Text)) / Log(2)));
            fNum = int.Parse(fNumBox.Text);
            cNum = int.Parse(cNumBox.Text);
            rNum = int.Parse(rNumBox.Text);
            tNum = fNum * cNum;
            AvgNum = int.Parse(AvgNumBox.Text);
            currRawNum = 0;
            postBufferidx = 0;            
            stepY = 2 * amp / (cNum - 1);
            ScanArray = new double[2, tNum * (bNum + rNum)];           
            FbaseX = minXVolt;
            BbaseX = maxXVolt;
            amp = (double)amplitudeNumeric.Value;
            baseY = -amp;
            stepNum = 0;
            counterTer = counterBox.Text;
            pixelDepth = int.Parse(pixelDepthBox.Text);
            grayMax = (float)MaxBar.Value;
            grayMin = (float)MinBar.Value;
            grayMul = (float)MulBar.Value;
            grayAdd = (float)AddBar.Value;
            cameraFilePath = cameraFilePathBox.Text;
            saveFilePath = SaveFilePathBox.Text;           
            
            //shortCut
            //configFilePath = "D:\\CamFiles\\A_AVIIVA_M2-4010CL_12-bits.ccf";//E2V Camera
            //configFilePath = "D:\\CamFiles\\Octoplus_external_trigger_test.ccf";//Dalsa Camera
            //cameraFilePath = "D:\\Weihao Chen\\Camera File\\SUI_GL2048R_4X_1Y.ccf"; //SUI Camera

            #region IMAQ Class
            //Camera Object 
            acq = new SapAcquisition(new SapLocation("Xtium-CL_MX4_1", 0), cameraFilePath);
            success = acq.Create();
            success = acq.SetParameter(SapAcquisition.Prm.STROBE_ENABLE, 0, true);//prevent triggering scanner before imaging
            success = acq.SetParameter(SapAcquisition.Prm.CROP_WIDTH, aNum, true);
            success = acq.SetParameter(SapAcquisition.Prm.CROP_HEIGHT, bNum, true);
            success = acq.SetParameter(SapAcquisition.Prm.INT_LINE_TRIGGER_FREQ, SampleClockRate, true);

            acqBuffer = new SapBuffer(1, aNum, bNum, SapFormat.Mono16, SapBuffer.MemoryType.ScatterGather);//default max pixel depth is 16bit
            success = acqBuffer.Create();
            acqBuffer.GetAddress(out acqbufferPtr);

            disBuffer = new SapBuffer(1, bNum, aNum/2, SapFormat.Mono8, SapBuffer.MemoryType.ScatterGather);
            disBuffer.PixelDepth = 8;
            success = disBuffer.Create();

            if (isEnface)
            {
                enFaceLineIndex = 0;
                enFaceDispBuffer = new SapBuffer(1, bNum, cNum, SapFormat.Mono8, SapBuffer.MemoryType.ScatterGather);
                enFaceDispBuffer.PixelDepth = 8;
                success = enFaceDispBuffer.Create();
                enfaceBox.Checked = true;
                EnFaceView = new SapView(enFaceDispBuffer, pictureBox2);
                success = EnFaceView.Create();

                float enFaceZoomHorz = (float)pictureBox2.Width / bNum;
                float enFaceZoomVert = (float)pictureBox1.Height / cNum;
                EnFaceView.SetScalingMode(enFaceZoomHorz, enFaceZoomVert);
                //EnFaceView.SetScalingMode(true);
            }
     

            BScanView = new SapView(disBuffer, pictureBox1);
            success = BScanView.Create();
            float BScanZoomHorz = (float)pictureBox1.Width / bNum;
            float BScanHalfaNum = aNum / 2;
            float BScanZoomVert = (float)2 * pictureBox1.Height / BScanHalfaNum;//TODO: multiply factor is a magnification factor, make it adjustable
            BScanView.SetScalingMode(BScanZoomHorz, BScanZoomVert);
            //BScanView.SetScalingMode(true);

            //process constructor
            process = new ProcessClass(isCalib,
                                        isAvg,
                                        isSpecVar,
                                        isEnface,
                                        acqBuffer,
                                        fpixel,
                                        acqbufferPtr,
                                        grayMax,
                                        grayMin,
                                        grayMul,
                                        grayAdd,
                                        tNum,
                                        AvgNum,
                                        new SapProcessingDoneHandler(processingCallback),
                                        this);
            success = process.Create();

            transfer = new SapAcqToBuf(acq, acqBuffer);
            transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;//trrigger envent whenever one frame is avaliable            
            transfer.XferNotify += new SapXferNotifyHandler(SapTransfer_Xfernotify);//callback function for trigger event
            transfer.XferNotifyContext = this;
            success = transfer.Create();

            if (saveRawFileBox.Checked)
            {
                //save ushort raw data in .RAW file
                rawBuffer = new SapBuffer(tNum, aNum, bNum, SapFormat.Mono16, SapBuffer.MemoryType.ScatterGather);
                rawBuffer.PixelDepth = 12; //TODA: find its affect place
                success = rawBuffer.Create();
            }          
            #endregion                  

            #region UI setting
            //UI
            //spectrum Chart initialization
            chart.Series.Clear();
            spectrumSeries = chart.Series.Add("AScan");           
            chart.ChartAreas[0].AxisX.Title = "Pixel Location";
            chart.ChartAreas[0].AxisY.Title = "Signal Intensity";
            chart.ChartAreas[0].AxisX.Minimum = 0;//pixel min location
            chart.ChartAreas[0].AxisX.Maximum = 2048;//pixel max location,buffer.Width or fftNum
            chart.ChartAreas[0].AxisY.Minimum = 0;//Pixel intensity min value;
            chart.ChartAreas[0].AxisY.Maximum = 4096;//Pixel intensity max value;
            chart.Series["AScan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            //fft Chart initialization
            chart1.Series.Clear();
            FFTSeries = chart1.Series.Add("FFT");
            chart1.ChartAreas[0].AxisX.Title = "FFT Points";
            chart1.ChartAreas[0].AxisY.Title = "FFT Intensity";
            chart1.ChartAreas[0].AxisX.Minimum = 0;//pixel min location
            chart1.ChartAreas[0].AxisX.Maximum = 1024;//pixel max location,buffer.Width or fftNum
            chart1.ChartAreas[0].AxisY.Minimum = 0;//Pixel intensity min value;
            chart1.ChartAreas[0].AxisY.Maximum = 7;//Pixel intensity max value;
            chart1.Series["FFT"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            //fps Chart initialization
            chart2.Series.Clear();
            FPSSeries = chart2.Series.Add("FPS");
            //chart2.ChartAreas[0].AxisY.Maximum = 200;
            chart2.ChartAreas[0].AxisX.Title = "Elaspe Time";
            chart2.ChartAreas[0].AxisY.Title = "FPS";
            chart2.ChartAreas[0].AxisY.Interval = 25;
            chart2.Series["FPS"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            #endregion
            return true;
        }

        private void DestroyObjects()
        {
            ScanBotton.Enabled = true;           
            try
            {
                if (transfer != null && transfer.Initialized)
                    transfer.Destroy();
                if (acq != null && acq.Initialized)
                    acq.Destroy();
                if (process != null && process.Initialized)
                    process.Destroy();              
                if (BScanView != null && BScanView.Initialized)
                    BScanView.Destroy();
                if (acqBuffer != null && acqBuffer.Initialized)
                    acqBuffer.Destroy();               
                if (rawBuffer != null && rawBuffer.Initialized)
                    rawBuffer.Destroy();
                if (postBuffer != null && postBuffer.Initialized)
                    postBuffer.Destroy();
                if (disBuffer != null && acqBuffer.Initialized)
                    acqBuffer.Destroy();
                
                                   
                //Dispose
                if (transfer != null) { transfer.Dispose(); transfer = null; };
                if (BScanView != null) { BScanView.Dispose(); BScanView = null; }
                if (acqBuffer != null) { acqBuffer.Dispose(); acqBuffer = null; }
                if (rawBuffer != null) { rawBuffer.Dispose(); rawBuffer = null; }
                if (postBuffer != null) { postBuffer.Dispose(); postBuffer = null; }
                if (disBuffer != null) { disBuffer.Dispose(); disBuffer = null; }
                if (acq != null) { acq.Dispose(); acq = null; }
                if (process != null) { process.Dispose(); process = null; }
                if (AOTask != null) { AOTask.Dispose(); AOTask = null; }
                if (COTask != null) { COTask.Stop(); COTask.Dispose(); COTask = null; }
                ScanArray = null;
            }

            catch (Exception x)//MX4 Exception error
            {
                MessageBox.Show(x.Message, "Error occur while closing resources, exiting...");
                Application.Exit();
            }
        }

        //*****************************************************************************************
        //
        //					ACquisition Control
        //
        //*****************************************************************************************
        //IMAQ callback event
        public void SapTransfer_Xfernotify(object sender, SapXferNotifyEventArgs args)
        {
            MainDlg main = args.Context as MainDlg;       
            
            if (process != null && process.Initialized)
            {
                //if (isEnface || isSpecVar)
                    //main.process.ExecuteNext();//process buffer sequentially                                  
                //else
                    main.process.Execute(); //process latest buffer  
            }           

            if (saveRawFileBox.Checked)
            {
                if (currRawNum < tNum)
                {
                    //copy current buffer to storage buffer
                    rawBuffer.Copy(acqBuffer, 0, currRawNum);
                    currRawNum++;
                }
                else
                    currRawNum = 1;
            }

            //Acquisition Rate Undate
            //acqwatch.Stop();         
            //if (acqwatch.Elapsed.Milliseconds != 0)
            //   acqRate = 1000 / acqwatch.Elapsed.Milliseconds;                           
            //acqwatch.Restart();

            
        }

        public void processingCallback(object sender, SapProcessingDoneEventArgs pInfo)
        {
            //GC.Collect(); //GC test
            ProcessClass currProcess = sender as ProcessClass;

            //Access Pointer for Display Buffer 
            unsafe
            {
                //Copy processed B-Scan to display buffer
                IntPtr b = currProcess.h_byteBuffer.PinnedHostPointer;
                disBuffer.Write(0, currProcess.h_byteBuffer.Size, b);
                BScanView.Show();//update BScan on Display           

                //Copy processed Enface Line to display buffer
                if (isEnface && fNum == 1)//TODO:special case when fNum!=1
                {
                    IntPtr e = currProcess.h_enFaceBuffer.PinnedHostPointer;
                    enFaceDispBuffer.Write(enFaceLineIndex * bNum, currProcess.h_enFaceBuffer.Size, e);
                    EnFaceView.Show();
                    enFaceLineIndex++;
                    if (enFaceLineIndex == cNum)
                        enFaceLineIndex = 0;

                }
                //Angiography enface view
                if (isEnface && fNum == 2)
                {
                    if (enFaceLineIndex % 2 == 0)//copy to display buffer when it is odd frame
                    {
                        IntPtr e = currProcess.h_enFaceBuffer.PinnedHostPointer;
                        enFaceDispBuffer.Write(enFaceLineIndex / 2 * bNum, currProcess.h_enFaceBuffer.Size, e);
                        EnFaceView.Show();
                    }
                    enFaceLineIndex++;
                    if (enFaceLineIndex == tNum)
                        enFaceLineIndex = 0;
                }
            }

            try
            {
                //update UI Asynchronously (on the main thread)
                if (this.InvokeRequired && isScaning)
                {//access main(UI) thread
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        if (SpectrumBox.Checked)
                        {
                            //Ascan spectrum plot                       
                            ushort[] spectrum = currProcess.h_ushortBuffer;
                            for (int i = 0; i < 2048; i++)
                            {
                                chart.Series["AScan"].Points.AddY(spectrum[i]);//ascan spectrum (first pixel) TODO: fix runtime error when clcik END                      
                            }
                        }

                        if (FFTBox.Checked)
                        {
                            //FFT spectrum plot
                            float[] modulus = currProcess.h_modulusBuffer;//32-bit fft spectrum
                            for (int i = 0; i < 1024; i++)
                            {
                                chart1.Series["FFT"].Points.AddY(Math.Log10(modulus[i]));//fft spectrum (first pixel)                 
                            }

                            ////dfs plot
                            //dfs = currProcess.h_floatDfs;
                            //for (int i = 0; i < dfs.Length; i++)
                            //{
                            //    if (dfs[i] > chart1.ChartAreas[0].AxisY.Minimum)
                            //        chart1.Series["FFT"].Points.AddY(dfs[i]);
                            //}
                        }

                        //Acquisition Rate 
                        if (transfer != null)
                            AcqRateLabel.Text = transfer.FrameRateStatistics.LiveFrameRate.ToString();
                        //Process Rate
                        if (process != null)
                        {
                            float processRate = 1000 / currProcess.Time;
                            fpsFile.WriteLine(processRate.ToString());
                            //float processRate = currProcess.Time;
                            processRateLabel.Text = processRate.ToString();
                            if (FPSBox.Checked)
                                chart2.Series["FPS"].Points.AddY(processRate);
                        }

                        //Display Rate
                        if (BScanView != null)
                            DisplayRateLabel.Text = BScanView.Display.RefreshRate.ToString();


                        //grayscale adjustment
                        currProcess.setMax((float)MaxBar.Value);
                        currProcess.setMin((float)MinBar.Value);
                        currProcess.setMul((float)MulBar.Value);
                        currProcess.setAdd((float)AddBar.Value);
                    });
                }
            }
            catch (Exception x)//MX4 Exception error
            {
                MessageBox.Show(x.Message, "Error occur due to aync aceess on UI thread, exiting Application");
                Application.Exit();
            }

        }

        private void EndImgeAcq(object sender, EveryNSamplesWrittenEventArgs e)
        {
            transfer.Wait(3000);
            transfer.Freeze();
            SaveImage();
            StopButton.PerformClick();
        }

        #region Control Button
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FileDialog.InitialDirectory = "c:\\";
            FileDialog.Filter = "Camera File (*.ccf)|*.ccf|All files (*.*)|*.*";
            FileDialog.FilterIndex = 2;
            FileDialog.RestoreDirectory = true;

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                cameraFilePath = FileDialog.FileName;
                cameraFilePathBox.Text = cameraFilePath;
            }
        }

        private void browseWriteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderDialog.ShowDialog();

            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                saveFilePath = folderDialog.SelectedPath;
                SaveFilePathBox.Text = saveFilePath;
            }
        }


        private void PreviewBotton_Click(object sender, EventArgs e)
        {

            if (!CreateObjects())
                this.Close();
            PreviewMode = true;
            isScaning = true;
            SetupScanner();//Scan Table initialization     
            AOTask = new Task();
            //X arm channel
            AOTask.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text,
                "XArm",
                -5,
                5,
                AOVoltageUnits.Volts);
            //Y arm channel
            AOTask.AOChannels.CreateVoltageChannel(physicalChannelComboBox2.Text,
                "YArm",
                -5,
                5,
                AOVoltageUnits.Volts);
            //configure sample clock with the calculated rate
            AOTask.Timing.ConfigureSampleClock(SampleClockSrc.Text,
                SampleClockRate,
                SampleClockActiveEdge.Rising,
                SampleQuantityMode.ContinuousSamples,
                tNum * (bNum + rNum));


            //Digital Output Task
            COTask = new Task();
            COTask.COChannels.CreatePulseChannelTicks(counterTer,
                                                          "GateCounter", "/Dev1/ao/SampleClock",
                                                          COPulseIdleState.Low,
                                                          30,
                                                          rNum,
                                                          bNum);
            COTask.Timing.ConfigureImplicit(SampleQuantityMode.ContinuousSamples, tNum * (bNum + rNum));
            //verify the tasks before doing waveform calculations
            AOTask.Control(TaskAction.Verify);
            COTask.Control(TaskAction.Verify);

            //Create Channel writer
            AnalogMultiChannelWriter AOWriter = new AnalogMultiChannelWriter(AOTask.Stream);
            AOWriter.WriteMultiSample(false, ScanArray);//Feed the updated scanArray
            AOTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(SampleClockSrc.Text, DigitalEdgeStartTriggerEdge.Rising);
            COTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(SampleClockSrc.Text, DigitalEdgeStartTriggerEdge.Rising);
            AOTask.Start();//wait for trigger
            COTask.Start();//wait for trigger
            AcquireImages();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!CreateObjects())
                this.Close();
            SaveCScanMode = true;
            isScaning = true;
            SetupScanner();//Scan Table initialization     
            AOTask = new Task();
            //X arm channel
            AOTask.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text,
                "XArm",
                -5,
                5,
                AOVoltageUnits.Volts);
            //Y arm channel
            AOTask.AOChannels.CreateVoltageChannel(physicalChannelComboBox2.Text,
                "YArm",
                -5,
                5,
                AOVoltageUnits.Volts);
            //configure sample clock with the calculated rate
            AOTask.Timing.ConfigureSampleClock(SampleClockSrc.Text,
                SampleClockRate,
                SampleClockActiveEdge.Rising,
                SampleQuantityMode.FiniteSamples,
                tNum * (bNum + rNum));

            //Callback Function
            AOTask.EveryNSamplesWrittenEventInterval = tNum * (bNum + rNum);
            //Create a EveryNSamplesWritten Event Handeler list, and link to Event handle method
            AOTask.EveryNSamplesWritten += new EveryNSamplesWrittenEventHandler(EndImgeAcq);

            //Digital Output Task
            COTask = new Task();
            COTask.COChannels.CreatePulseChannelTicks(counterTer,
                                                          "GateCounter", "/Dev1/ao/SampleClock",
                                                          COPulseIdleState.Low,
                                                          0,
                                                          rNum,
                                                          bNum);
            COTask.Timing.ConfigureImplicit(SampleQuantityMode.FiniteSamples, tNum * (bNum + rNum));
            //verify the tasks before doing waveform calculations
            AOTask.Control(TaskAction.Verify);
            COTask.Control(TaskAction.Verify);
            //Create Channel writer
            AnalogMultiChannelWriter AOWriter = new AnalogMultiChannelWriter(AOTask.Stream);
            AOWriter.WriteMultiSample(false, ScanArray);//Feed the updated scanArray
            AOTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(SampleClockSrc.Text, DigitalEdgeStartTriggerEdge.Rising);
            COTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(SampleClockSrc.Text, DigitalEdgeStartTriggerEdge.Rising);
            AOTask.Start();//wait for trigger
            COTask.Start();//wait for trigger
            AcquireImages();
        }


        private void EndButton_Click(object sender, EventArgs e)
        {
            if (transfer != null)
                transfer.Freeze();
            if (isScaning == true)
                DestroyObjects();
            isScaning = false;
            SaveButton.Enabled = true;
            PreviewMode = false;
            SaveCScanMode = false;
            //pictureBox1.Refresh();
            //pictureBox2.Refresh();
        }

        private void MaxBar_Scroll(object sender, System.EventArgs e)
        {
            MaxBarText.Text = MaxBar.Value.ToString();
        }

        private void MinBar_Scroll(object sender, System.EventArgs e)
        {
            MinBarText.Text = MinBar.Value.ToString();
        }

        private void MulBar_Scroll(object sender, System.EventArgs e)
        {
            MulBarText.Text = MulBar.Value.ToString();
        }

        private void AddBar_Scroll(object sender, System.EventArgs e)
        {
            float addValue = (float)AddBar.Value / 100;
            AddBarText.Text = addValue.ToString();
        }
        #endregion

        private void CalibrationButton_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;
            string CalibrationFilePath;
            //Get the path of calibration excel file (in row)
            //CalibrationFilePath = openFileDialog1.FileName;
            //string calibPath = Application.StartupPath + "\\CalibrationCurve.xlsx";//debug default path
            string calibPath = @"D:\Weihao Chen\OCTSharp\OCTSharp_v1.4.8\bin\x64\Debug\CalibrationCurve.xlsx";
            Excel.Application xls = new Excel.Application();
            Excel.Workbook workbook = xls.Workbooks.Open(calibPath);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange.Rows[1];
            System.Array calibrationValue = (System.Array)range.Cells.Value;
            phaseAry = calibrationValue.OfType<Object>().Select(o => (double)o).ToArray();
            //genearte evenly spaced phase
            evenPhaseAry = new double[aNum];
            double[] pixelAry = new double[aNum];
            double length = aNum - 1;
            double phaseMax = phaseAry[aNum - 1];
            double phaseMin = phaseAry[0];

            if (phaseAry.Length == evenPhaseAry.Length)
            {
                for (int i = 0; i < aNum; i++)
                {
                    evenPhaseAry[i] = (i * (phaseMax - phaseMin) / length) + phaseMin;
                }
                for (int i = 0; i < aNum; i++)
                {
                    pixelAry[i] = i + 1;
                }

                //fit a new curve where x is phase and y is pixel number
                fpixel = new float[aNum];
                double[] polycof = new double[4];
                polycof = Fit.Polynomial(phaseAry, pixelAry, 3,
                    MathNet.Numerics.LinearRegression.DirectRegressionMethod.NormalEquations);
                Polynomial poly = new Polynomial(polycof);

                //evaluate frational pixel
                for (int i = 0; i < evenPhaseAry.Length; i++)
                {
                    fpixel[i] = (float)poly.Evaluate(evenPhaseAry[i]);
                }
                workbook.Close();

                Calib_a = polycof[3].ToString("0.#############");
                Calib_b = polycof[2].ToString("0.##########");
                Calib_c = polycof[1].ToString("0.######");
                Calib_d = polycof[0].ToString("0.######");

                Calib_aBox.Text = Calib_a;
                Calib_bBox.Text = Calib_b;
                Calib_cBox.Text = Calib_c;
                Calib_dBox.Text = Calib_d;
            }
            else
            {
                MessageBox.Show("Calibration fucntion disabled. " +
                    "Pixels number of the imported calibration cruve and Pixels number setting need to be same.");
                calibrationBox.Checked = false;
            }
        }
        private void ModifyCalibCurveBtn_Click(object sender, EventArgs e)
        {
            evenPhaseAry = new double[aNum];
            double phaseMax = phaseAry[aNum - 1];
            double phaseMin = phaseAry[0];
            double length = aNum - 1;
            double[] polycof = new double[4];

            polycof[3] = double.Parse(Calib_aBox.Text);
            polycof[2] = double.Parse(Calib_bBox.Text);
            polycof[1] = double.Parse(Calib_cBox.Text);
            polycof[0] = double.Parse(Calib_dBox.Text);

            for (int i = 0; i < aNum; i++)
            {
                evenPhaseAry[i] = (i * (phaseMax - phaseMin) / length) + phaseMin;
            }

            Polynomial poly = new Polynomial(polycof);
            for (int i = 0; i < evenPhaseAry.Length; i++)
            {
                fpixel[i] = (float)poly.Evaluate(evenPhaseAry[i]);
            }
        }
        #region Window Handler
        //*****************************************************************************************
        //
        //					Windows Handlder
        //
        //*****************************************************************************************
        protected override void OnResize(EventArgs e)
        {
            if (BScanView != null)
                BScanView.OnSize();
            base.OnResize(e);
        }
        protected override void OnMove(EventArgs e)
        {
            if (BScanView != null)
                BScanView.OnMove();
            base.OnMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (BScanView != null)
                BScanView.OnPaint();
            base.OnPaint(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
        }
        #endregion

        private void AcquireImages()
        {
            //button
            ScanBotton.Enabled = false;
            SaveButton.Enabled = false;
            StopButton.Enabled = true;
            try
            {
                bool success;
                success = transfer.Grab();
                acq.SetParameter(SapAcquisition.Prm.STROBE_ENABLE, 1, true);//Hsync trigger for AOTask and COTask             
            }

            catch (DaqException err)
            {
                MessageBox.Show(err.Message);
                DestroyObjects();
            }
        }

        private void SetupScanner()
        {
            //#region ScanArray Table Init
            //double stepX = maxXVolt - minXVolt / (bNum + rNum);
            //double delta_trg = 0.01;
            //double delta_sqr = 0.05;
            //double baseX = 0;
            ////generate x for sawtooth function
            //double[] swt_x = new double[bNum + rNum];
            //for (int i = 0; i < bNum + rNum; i++)
            //{
            //    swt_x[i] = (2 * baseX - 1) / 4;
            //    baseX = baseX + stepX;
            //}

            ////generate the differntiable triangle function
            //double[] trg = new double[bNum + rNum];
            //for (int i = 0; i < bNum + rNum; i++)
            //{
            //    trg[i] = 1 - 2 * Math.Acos((1 - delta_trg) * Math.Sin(2 * Math.PI * swt_x[i])) / Math.PI;
            //}

            ////generate the differntiable square function
            //double[] sqa = new double[bNum + rNum];
            //baseX = 0;
            //for (int i = 0; i < bNum + rNum; i++)
            //{
            //    sqa[i] = 2 * Math.Atan(Math.Sin(2 * Math.PI * baseX) / delta_sqr) / Math.PI;
            //    baseX = baseX + stepX / 2.0f;
            //}

            ////generate the differntiable sawtooth function
            //double[] swt = new double[bNum + rNum];
            //for (int i = 0; i < bNum + rNum; i++)
            //{
            //    swt[i] = 2.0f * (trg[i] * sqa[i]);
            //}


            //if (cNum == 1)
            //{
            //    for (int m = 0; m < tNum; m++)
            //    {
            //        //X Voltage Array
            //        for (int i = 0; i < bNum + rNum; i++)
            //        {//loop of X forward scan
            //            ScanArray[0, i + m * (bNum + rNum)] = swt[i];
            //        }
            //    }
            //}
            //else
            //{//when cNum !=1
            //    //X Voltage Array
            //    for (int m = 0; m < tNum; m++)
            //    {
            //        //X Voltage Array
            //        for (int i = 0; i < bNum + rNum; i++)
            //        {//loop of X forward scan
            //            ScanArray[0, i + m * (bNum + rNum)] = swt[i];
            //        }
            //    }
            //    for (int n = 0; n < cNum; n++)
            //    {
            //        //Y Voltage Array (option1)
            //        for (int i = 0; i < fNum * (bNum + rNum); i++)
            //        {
            //            ScanArray[1, i + n * fNum * (bNum + rNum)] = baseY + n * stepY;
            //        }
            //    }
            //}
            //#endregion         

            //sawtooth scan
            double FstepX = (maxXVolt - minXVolt) / bNum;
            double BstepX = (maxXVolt - minXVolt) / rNum;

            if (cNum != 1)
            {
                for (int t = 0; t < tNum; t++)
                {
                    FbaseX = minXVolt;
                    BbaseX = maxXVolt;

                    //X Voltage Array
                    for (int i = 0; i < bNum; i++)
                    {//loop of X forward scan
                        ScanArray[0, i + t * (bNum + rNum)] = FbaseX;
                        FbaseX = FbaseX + FstepX;
                    }

                    for (int i = bNum; i < bNum + rNum; i++)
                    {//loop of X backward scan
                        ScanArray[0, i + t * (bNum + rNum)] = BbaseX;
                        BbaseX = BbaseX - BstepX;
                    }
                }
                //Y Voltage Array (option1)
                for (int c = 0; c < cNum; c++)
                {
                    for (int i = 0; i < fNum * (bNum + rNum); i++)
                    {
                        ScanArray[1, i + c * fNum * (bNum + rNum)] = baseY + c * stepY;
                    }
                }
            }
            else
            {//Y is default at 0 when cNum==1
                for (int t = 0; t < tNum; t++)
                {
                    FbaseX = minXVolt;
                    BbaseX = maxXVolt;
                    //X Voltage Array
                    for (int i = 0; i < bNum; i++)
                    {//loop of X forward scan
                        ScanArray[0, i + t * (bNum + rNum)] = FbaseX;
                        FbaseX = FbaseX + FstepX;
                    }

                    for (int i = bNum; i < (bNum + rNum); i++)
                    {//loop of X backward scan
                        ScanArray[0, i + t * (bNum + rNum)] = BbaseX;
                        BbaseX = BbaseX - BstepX;
                    }
                }
            }
        }
        //*****************************************************************************************
        //
        //					Save Operation
        //
        //*****************************************************************************************

        private void SaveImage()
        {
            if (saveRawFileBox.Checked)
            {
                //save 16-bit ushort data in .RAW file
                unsafe
                {
                    long length = rawBuffer.Height * rawBuffer.Width * rawBuffer.BytesPerPixel;//one frame length
                    System.IntPtr address;
                    rawBuffer.GetAddress(0, out address);
                    UnmanagedMemoryStream stream = new UnmanagedMemoryStream((byte*)address, length);
                    RawFilePath = saveFilePath + "\\RawBuffer" + RawFilePathNum + ".raw";
                    FileStream file = new FileStream(RawFilePath, FileMode.Append, FileAccess.Write);

                    //loop through buffer and save all b-Scan
                    for (int i = 0; i < rawBuffer.Count; i++)
                    {
                        rawBuffer.GetAddress(i, out address);
                        stream = new UnmanagedMemoryStream((byte*)address, length);
                        stream.CopyTo(file);
                    }
                    stream.Close();
                    file.Close();
                    RawFilePathNum++;
                }                  
            }
            DestroyObjects();
        }


        private void bNumBox_ValueChanged(object sender, EventArgs e)
        {
            //round to nearest power of two (fft is more efficient)
            //bNum = (int)Pow(2, Ceiling(Log(int.Parse(bNumBox.Text)) / Log(2)));
            //bNumBox.Text = bNum.ToString();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            FPSSeries.Points.Clear();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
           OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Raw Files|(*.raw)|All files (*.*)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                openFileName = openFileDialog.FileName;

            SapBuffer loadBuffer = new SapBuffer(openFileName, SapBuffer.MemoryType.ScatterGather);
        }
    }
}
