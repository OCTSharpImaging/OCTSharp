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

using DALSA.SaperaLT.SapClassBasic;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using ManagedCuda.CudaBlas;
using ManagedCuda.CudaFFT;
using ManagedCuda.VectorTypes;
using System;
using System.IO;
using System.Windows.Forms;

namespace OCTSharp
{
    public class ProcessClass : SapProcessing
    {

        //MySapProcessing Field
        bool isCalib;
        bool isAvg;
        bool isSpecVar;
        bool isEnface;
        public SapBuffer buffer;
        public float Max;
        public float Min;
        public float Mul;
        public float Add;
        int tNum;
        int samplePerBScan;
        int bytesPerBscan;
        int VolumeSize;
        int fftNum;
        IntPtr h_bufferPtr;
        float[] fpixel;


        //CUDA property
        int deviceID;
        private CudaContext ctx;
        private CudaDeviceProperties p = new CudaDeviceProperties();
        CUmodule module;
        int BlockDim;
        int GridDim;
        int width;
        int height;
        int bscanWidth;
        int bscanHeight;
        int AvgNum;
        int currAvgNum = 0;
        const int SpecVarNum = 2;
        int currSpecVarNum = 0;
        //CUDA parameters
        CudaKernel inputCastKernel;
        CudaKernel meanALineSubstractionKernel;
        CudaKernel CubicInterpretationKernal;
        CudaKernel modulusKernel;
        CudaKernel resetKernel;
        CudaKernel SumKernel;
        CudaKernel AvgKernel;
        CudaKernel VariantKernel;
        CudaKernel BScanOutputCastKernel;
        CudaKernel copyKernel;
        CudaKernel AssignComplexOneKernel;
        CudaKernel dfsModulusKernel;
        CudaKernel EnfaceOutputCastKernel;
        CUstream memcpyStream;
        CUstream kernelStream;
        CudaDeviceVariable<byte> d_byteBuffer;
        CudaDeviceVariable<ushort> d_ushortBuffer;
        CudaDeviceVariable<cuFloatComplex> d_fftBuffer;
        CudaDeviceVariable<cuFloatComplex> d_resampleBuffer;
        CudaDeviceVariable<float> d_resampleCurve;
        CudaDeviceVariable<cuFloatComplex> d_meanALine;
        CudaDeviceVariable<float> d_modulusBuffer;
        CudaDeviceVariable<float> d_avgBuffer;
        CudaDeviceVariable<float> d_sumBuffer;
        CudaDeviceVariable<float> d_tempBuffer1;
        CudaDeviceVariable<float> d_tempBuffer2;
        CudaDeviceVariable<float> d_varBuffer;
        CudaDeviceVariable<float> d_flipBuffer;
        CudaDeviceVariable<float> d_tempBuffer;
        CudaDeviceVariable<float> d_floatEnFaceBuffer;
        CudaDeviceVariable<byte> d_byteEnFaceBuffer;
        public CudaFFTPlan1D fft_plan;
        public CudaPageLockedHostMemory_ushort h_lockbuffer;
        public CudaPageLockedHostMemory_byte h_byteBuffer;
        public CudaPageLockedHostMemory_byte h_enFaceBuffer;
        //public float[] h_enFaceBuffer;
        public CudaBlas cublas_handle;

        float floatAlpha;
        float floatBeta;
        public int minIdx = 0;
        public int maxIdx = 0;
        public float minMag;
        public float maxMag;


        //Debug
        //public byte[] h_byteBuffer;
        public ushort[] h_ushortBuffer;
        public float2[] h_fftBuffer;
        public float2[] h_resampleBuffer;
        public uint[] h_uintBuffer;
        public ushort[] h_ushortbuffer;
        public float[] h_modulusBuffer; //DEDUG Use
        public float2[] h_meanAline;
        public float[] h_avgBuffer;
        public float[] h_tempBuffer1;
        public float[] h_tempBuffer2;
        public float[] h_varBuffer;
        
        cuFloatComplex complexAlpha;
        cuFloatComplex complexBeta;
        CudaDeviceVariable<cuFloatComplex> d_complexdfs;
        CudaDeviceVariable<cuFloatComplex> d_complexSumLine;
        CudaDeviceVariable<cuFloatComplex> d_oneComplexArray;
        CudaDeviceVariable<float> d_oneFloatArray;
        CudaDeviceVariable<float> d_floatDfs;
        public float[] h_floatDfs;
        CudaDeviceVariable<float> d_Dfs;
        public float[] h_Dfs;
        public byte[] h_byteEnFaceBuffer;

        //Constructor
        public ProcessClass() { }
        public ProcessClass(
            bool isCalib,
            bool isAvg,
            bool isSpecVar,
            bool isEnface,
            SapBuffer buffer,
            float[] fpixel,
            IntPtr bufferPtr,
            float grayMax,
            float grayMin,
            float grayMul,
            float grayAdd,
            int tNum,
            int AvgNum,
            SapProcessingDoneHandler callback, Object contest)
        : base(buffer)
        {
            //constrctor property setting  
            this.isCalib = isCalib;
            this.isAvg = isAvg;
            this.isSpecVar = isSpecVar;
            this.isEnface = isEnface;
            this.buffer = buffer;
            this.fpixel = fpixel;
            this.h_bufferPtr = bufferPtr;
            this.Max = grayMax;
            this.Min = grayMin;
            this.Mul = grayMul;
            this.Add = grayAdd;
            this.tNum = tNum;
            this.AvgNum = AvgNum;
            base.ProcessingDone += callback;
            base.ProcessingDoneContext = contest;//passing this contest to the mainDlg whenever processing finish
            base.ProcessingDoneEnable = true; //enable prosssing done event

            //other property setting
            this.width = buffer.Width;
            this.height = buffer.Height;
            this.bscanWidth = buffer.Width;
            this.bscanHeight = height / 2;
            this.samplePerBScan = buffer.Width * buffer.Height;//aNum*bNum
            this.bytesPerBscan = samplePerBScan * buffer.BytesPerPixel;
            this.VolumeSize = buffer.Width * buffer.Height * buffer.Count;//aNum*bNum*cNum   

            //host memory initialization
            initHost();
            //GPU device memory initialization
            initDevice();
        }

        public override bool Run()
        {//real-time image processing
            if (ctx!=null && buffer != null)
            {
                //==================cuda pipeline========================
                ctx.SetCurrent();//set to current thread  
                buffer.GetAddress(out h_bufferPtr);
                h_lockbuffer.SynchronCopyToDevice(d_ushortBuffer.DevicePointer);
                //d_ushortBuffer.CopyToHost(h_ushortBuffer);//16bit ascan spectrum

                //Input Cast
                inputCastKernel.Run(d_fftBuffer.DevicePointer, d_ushortBuffer.DevicePointer, Buffer.PixelDepth, samplePerBScan);
                //d_fftBuffer.CopyToHost(h_fftBuffer);

                //Sum DC with cublas
                cublas_handle.Gemv(Operation.NonTranspose,
                                   buffer.Width,//m
                                   buffer.Height,//n
                                   complexAlpha,//alpha
                                   d_fftBuffer,//A
                                   buffer.Width,//lda
                                   d_oneComplexArray,//x
                                   1,//incx
                                   complexBeta,//beta
                                   d_meanALine,//y
                                   1//incy
                                   );
                DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);
                //d_meanALine.CopyToHost(h_meanAline);

                //Remove DC-cublas
                meanALineSubstractionKernel.Run(d_fftBuffer.DevicePointer, d_meanALine.DevicePointer, width, height);

                ////DFS flip
                //cublas_handle.Geam(Operation.Transpose,
                //                    Operation.NonTranspose,
                //                    buffer.Height,
                //                    buffer.Width,
                //                    complexAlpha,
                //                    d_fftBuffer,
                //                    buffer.Height,
                //                    d_fftBuffer,
                //                    buffer.Width,
                //                    complexBeta,
                //                    d_complexdfs,
                //                    buffer.Height);  //ldc 
                //DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);

                ////DFS fft
                //fft_plan.Exec(d_complexdfs.DevicePointer, d_complexdfs.DevicePointer, TransformDirection.Inverse);
                //DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);
                ////d_complexBuffer.CopyToHost(h_fftBuffer);

                ////DFS modulus
                //dfsModulusKernel.Run(d_floatDfs.DevicePointer, d_complexdfs.DevicePointer);
                ////d_floatDfs.CopyToHost(h_Dfs);

                ////Sum DFS with cublas
                //cublas_handle.Gemv(Operation.NonTranspose,
                //                   buffer.Width,
                //                   buffer.Height,
                //                   floatAlpha,
                //                   d_floatDfs,
                //                   buffer.Width,
                //                   d_oneFloatArray,
                //                   1,
                //                   floatBeta,
                //                   d_Dfs,
                //                   1);
                //DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);//wait for DC sum to completene,                               
                //d_Dfs.CopyToHost(h_floatDfs);

                if (isCalib == true)
                    //interpretation(allow different mode - TODO: mode pass from ui)                    
                    CubicInterpretationKernal.Run(d_fftBuffer.DevicePointer, d_fftBuffer.DevicePointer, d_resampleCurve.DevicePointer, width);

                //FFT 
                fft_plan.Exec(d_fftBuffer.DevicePointer, d_fftBuffer.DevicePointer, TransformDirection.Forward); //in-place fft     
                DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);//wait for fft to complete
                //d_fftBuffer.CopyToHost(h_fftBuffer);

                //Calculate Modulus        
                modulusKernel.Run(d_modulusBuffer.DevicePointer, d_fftBuffer.DevicePointer, width/2, samplePerBScan, Max, Min, Mul, Add);
                //d_modulusBuffer.CopyToHost(h_modulusBuffer);//Check 32bit float fft magnitude

                //flip all Bscan
                cublas_handle.Geam(Operation.Transpose,
                                    Operation.NonTranspose,
                                    buffer.Height,   //m
                                    buffer.Width / 2,  //n
                                    floatAlpha,        //alpha
                                    d_modulusBuffer,//A Size
                                    buffer.Width /2,   //lda                                 
                                    d_modulusBuffer,//B Size
                                    buffer.Height,   //ldb
                                    floatBeta,         // beta
                                    d_flipBuffer,  //C Size
                                    buffer.Height);  //ldc 
                DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);//wait for transpose to complete

                if (isEnface)
                {
                    ////Sum B-Scan with cublas
                    //cublas_handle.Gemv(Operation.NonTranspose,
                    //                  buffer.Height,//m
                    //                  buffer.Width / 2,//n
                    //                  floatAlpha,//alpha
                    //                  d_flipBuffer,//A
                    //                  buffer.Height,//lda
                    //                  d_oneFloatArray,//x
                    //                  1,//incx
                    //                  floatBeta,//beta
                    //                  d_floatEnFaceBuffer,//y
                    //                  1//incy
                    //                  );
                    //DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);

                    ////Output Cast                  
                    //EnfaceOutputCastKernel.Run(d_byteEnFaceBuffer.DevicePointer, d_floatEnFaceBuffer.DevicePointer, Max, Min, Mul);
                    //h_enFaceBuffer.SynchronCopyToHost(d_byteEnFaceBuffer.DevicePointer);

                    ////Output Cast                  
                    //BScanOutputCastKernel.Run(d_byteBuffer.DevicePointer, d_flipBuffer.DevicePointer, Max, Min, Mul);
                    ////Copy to Host               
                    //h_byteBuffer.SynchronCopyToHost(d_byteBuffer.DevicePointer);
                }

                //Avg Frames 
                 if (isAvg)
                {
                    if (currAvgNum < AvgNum - 1)
                    {
                        //Sum AvgNum of BScans
                        SumKernel.Run(d_sumBuffer.DevicePointer, d_flipBuffer.DevicePointer);
                        currAvgNum++;
                    }

                    else
                    {
                        //Calculate Avg of Average Buffer
                        AvgKernel.Run(d_avgBuffer.DevicePointer, d_sumBuffer.DevicePointer, AvgNum);
                        //Output Cast                       
                        BScanOutputCastKernel.Run(d_byteBuffer.DevicePointer, d_avgBuffer.DevicePointer, Max, Min, Mul);
                        //Copy to Host
                        h_byteBuffer.SynchronCopyToHost(d_byteBuffer.DevicePointer);
                        //reset Sum buffer and index                         
                        resetKernel.Run(d_sumBuffer.DevicePointer);
                        currAvgNum = 0;
                    }
                }

                //Speckle Variant
                if (isSpecVar)
                {
                    if (currSpecVarNum < SpecVarNum - 1)
                    {
                        copyKernel.Run(d_tempBuffer1.DevicePointer, d_flipBuffer.DevicePointer);
                        currSpecVarNum++;
                    }

                    else
                    {
                        //Save second frame
                        copyKernel.Run(d_tempBuffer2.DevicePointer, d_flipBuffer.DevicePointer);
                        //Calculate Var
                        VariantKernel.Run(d_varBuffer.DevicePointer, d_tempBuffer1.DevicePointer, d_tempBuffer2.DevicePointer, d_sumBuffer.DevicePointer, SpecVarNum);
                        //d_varBuffer.CopyToHost(h_varBuffer);
                        //Output Cast                       
                        BScanOutputCastKernel.Run(d_byteBuffer.DevicePointer, d_varBuffer.DevicePointer, Max, Min, Mul);

                        //Sum B-Scan with cublas
                        cublas_handle.Gemv(Operation.NonTranspose,
                                          buffer.Height,//m
                                          buffer.Width / 2,//n
                                          floatAlpha,//alpha
                                          d_varBuffer,//A
                                          buffer.Height,//lda
                                          d_oneFloatArray,//x
                                          1,//incx
                                          floatBeta,//beta
                                          d_floatEnFaceBuffer,//y
                                          1//incy
                                          );
                        DriverAPINativeMethods.Streams.cuStreamSynchronize(kernelStream);

                        //Output Cast                  
                        EnfaceOutputCastKernel.Run(d_byteEnFaceBuffer.DevicePointer, d_floatEnFaceBuffer.DevicePointer, Max, Min, Mul);
                        h_enFaceBuffer.SynchronCopyToHost(d_byteEnFaceBuffer.DevicePointer);
                        d_byteEnFaceBuffer.CopyToHost(h_byteEnFaceBuffer);

                        //reset buffer and index 
                        resetKernel.Run(d_varBuffer.DevicePointer);
                        //reset index
                        currSpecVarNum = 0;

                        //Copy to Host
                        h_byteBuffer.SynchronCopyToHost(d_byteBuffer.DevicePointer);
                    }
                }

                else
                {
                    //Output Cast                  
                    BScanOutputCastKernel.Run(d_byteBuffer.DevicePointer, d_flipBuffer.DevicePointer, Max, Min, Mul);
                    //Copy to Host               
                    h_byteBuffer.SynchronCopyToHost(d_byteBuffer.DevicePointer);
                    buffer.ReleaseAddress(h_bufferPtr);
                }
            }
            return true;
        }
        private void initHost()
        {
            //h_byteBuffer = new byte[samplesPerBscan];
            h_ushortBuffer = new ushort[samplePerBScan];
            h_fftBuffer = new float2[samplePerBScan];
            h_resampleBuffer = new float2[samplePerBScan];
            h_uintBuffer = new uint[samplePerBScan / 2];
            h_ushortbuffer = new ushort[samplePerBScan / 2];
            h_modulusBuffer = new float[samplePerBScan / 2];
            h_tempBuffer1 = new float[samplePerBScan / 2];
            h_tempBuffer2 = new float[samplePerBScan / 2];
            h_meanAline = new float2[width];
            h_lockbuffer = new CudaPageLockedHostMemory_ushort(h_bufferPtr, samplePerBScan);
            h_byteBuffer = new CudaPageLockedHostMemory_byte(samplePerBScan /2);
            h_enFaceBuffer = new CudaPageLockedHostMemory_byte(height);
            //h_enFaceBuffer = new float[height];
            h_avgBuffer = new float[samplePerBScan / 2];
            h_varBuffer = new float[samplePerBScan / 2];
            h_floatDfs = new float[height];
            h_Dfs = new float[samplePerBScan];
            h_byteEnFaceBuffer = new byte[height];
        }

        private void initDevice()
        {
            //CUDA structure setting
            ctx = new CudaContext();
            deviceID = 0;
            //BlockDim = ctx.GetDeviceInfo().MaxBlocksPerMultiProcessor;//16 for RTX3080
            BlockDim = 64;//TODO: Profile test to see the optimal CUDA occupancy
            GridDim = samplePerBScan / BlockDim;

            //Get Pre-compiled CUDA ptx file path
            string PTXpath = Application.StartupPath + "\\kernel.ptx";

            //CUDA info
            string console = string.Format("CUDA device [{0}] has {1} Multi-Processors", ctx.GetDeviceName(), ctx.GetDeviceInfo().MultiProcessorCount);
            Console.WriteLine(console);
            module = ctx.LoadModulePTX(PTXpath);//Load compiled .cu execution file-1300nm sysetm
            //module = ctx.LoadModulePTX(@"L:\Weihao Chen\OCTSharp\MX4_OCTSharp\kernel.ptx");//Load compiled .cu execution file-850nm system
        
            //Cuda parameters setting            
            d_ushortBuffer = new CudaDeviceVariable<ushort>(samplePerBScan);
            d_fftBuffer = new CudaDeviceVariable<cuFloatComplex>(samplePerBScan);
            d_modulusBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_flipBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_byteBuffer = new CudaDeviceVariable<byte>(samplePerBScan / 2);
            d_floatEnFaceBuffer = new CudaDeviceVariable<float>(height);
            d_byteEnFaceBuffer = new CudaDeviceVariable<byte>(height);
            d_resampleBuffer = new CudaDeviceVariable<cuFloatComplex>(samplePerBScan);
            d_meanALine = new CudaDeviceVariable<cuFloatComplex>(width);
            d_avgBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_sumBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_varBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_tempBuffer = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_tempBuffer1 = new CudaDeviceVariable<float>(samplePerBScan / 2);
            d_tempBuffer2 = new CudaDeviceVariable<float>(samplePerBScan / 2);

            d_oneComplexArray = new CudaDeviceVariable<cuFloatComplex>(width);            
            d_complexSumLine = new CudaDeviceVariable<cuFloatComplex>(width);
            d_oneFloatArray = new CudaDeviceVariable<float>(height);
            for (int i = 0; i < d_oneFloatArray.Size; i++)
                d_oneFloatArray[i] = 1.0f;
            d_floatDfs = new CudaDeviceVariable<float>(samplePerBScan);
            d_Dfs = new CudaDeviceVariable<float>(height);
            d_complexdfs = new CudaDeviceVariable<cuFloatComplex>(samplePerBScan);
            if (isCalib)
            {
                d_resampleCurve = new CudaDeviceVariable<float>(fpixel.Length);
                d_resampleCurve.CopyToDevice(fpixel);
            }
            //Cuda Stream setting
            ManagedCuda.DriverAPINativeMethods.Streams.cuStreamCreate(ref memcpyStream, CUStreamFlags.NonBlocking);
            ManagedCuda.DriverAPINativeMethods.Streams.cuStreamCreate(ref kernelStream, CUStreamFlags.NonBlocking);

            fft_plan = new CudaFFTPlan1D(buffer.Width, cufftType.C2C, buffer.Height, kernelStream);

            //Cuda cublas setting
            cublas_handle = new CudaBlas(kernelStream);
            floatAlpha = 1.0f;
            floatBeta = 0.0f;
            complexAlpha.real = 1.0f;
            complexAlpha.imag = 0.0f;
            complexBeta.real = 0.0f;
            complexBeta.imag = 0.0f;

            //Kernel Initialization
            inputCastKernel = new CudaKernel("inputCastKernel", module, ctx);
            inputCastKernel.BlockDimensions = BlockDim;
            inputCastKernel.GridDimensions = GridDim;

            CudaKernel AverageFrameKernal = new CudaKernel("AverageFrameKernal", module, ctx);
            AverageFrameKernal.BlockDimensions = BlockDim;
            AverageFrameKernal.GridDimensions = width / BlockDim;
          

            meanALineSubstractionKernel = new CudaKernel("meanALineSubstractionKernel", module, ctx);
            meanALineSubstractionKernel.BlockDimensions = BlockDim;
            meanALineSubstractionKernel.GridDimensions = GridDim;

            CubicInterpretationKernal = new CudaKernel("CubicInterpretationKernal", module, ctx);
            CubicInterpretationKernal.BlockDimensions = BlockDim;
            CubicInterpretationKernal.GridDimensions = GridDim;
            
            modulusKernel = new CudaKernel("modulusKernel", module, ctx);
            modulusKernel.BlockDimensions = BlockDim;
            modulusKernel.GridDimensions = GridDim/2;

            BScanOutputCastKernel = new CudaKernel("BScanOutputCastKernel", module, ctx);
            BScanOutputCastKernel.BlockDimensions = BlockDim;
            BScanOutputCastKernel.GridDimensions = GridDim/2;

            EnfaceOutputCastKernel = new CudaKernel("EnfaceOutputCastKernel", module, ctx);
            EnfaceOutputCastKernel.BlockDimensions = BlockDim;
            EnfaceOutputCastKernel.GridDimensions = (height + BlockDim -1) / BlockDim;

            dfsModulusKernel = new CudaKernel("dfsModulusKernel", module, ctx);
            dfsModulusKernel.BlockDimensions = BlockDim;
            dfsModulusKernel.GridDimensions = GridDim / 2;

            SumKernel = new CudaKernel("SumKernel", module, ctx);
            SumKernel.BlockDimensions = BlockDim;
            SumKernel.GridDimensions = GridDim / 2;

            AvgKernel = new CudaKernel("AvgKernel", module, ctx);
            AvgKernel.BlockDimensions = BlockDim;
            AvgKernel.GridDimensions = GridDim / 2;

            VariantKernel = new CudaKernel("VariantKernel", module, ctx);
            VariantKernel.BlockDimensions = BlockDim;
            VariantKernel.GridDimensions = GridDim / 2;            

            resetKernel = new CudaKernel("resetKernel", module, ctx);
            resetKernel.BlockDimensions = BlockDim;
            resetKernel.GridDimensions = GridDim / 2;

            copyKernel = new CudaKernel("copyKernel", module, ctx);
            copyKernel.BlockDimensions = BlockDim;
            copyKernel.GridDimensions = GridDim / 2;

            AssignComplexOneKernel = new CudaKernel("AssignComplexOneKernel", module, ctx);
            AssignComplexOneKernel.BlockDimensions = BlockDim;
            AssignComplexOneKernel.GridDimensions = ((int)d_oneComplexArray.Size+BlockDim - 1 )/ BlockDim;
            AssignComplexOneKernel.Run(d_oneComplexArray.DevicePointer);
        }

        public void destroyCuda()
        {
            if (ctx != null)
            {
                ctx.SetCurrent();
                ctx.UnloadModule(module);
                fft_plan.Dispose();
                cublas_handle.Dispose();
                ctx.Dispose();
                ctx = null;
            }           
        }
        public void setMax(float newMax)
        {
            Max = newMax;
        }

        public void setMin(float newMin)
        {
            Min = newMin;
        }

        public void setMul(float newMul)
        {
            Mul = newMul;
        }

        public void setAdd(float newAdd)
        {
            //UI number is int, need to convert to float here
            Add = newAdd / 100.0f;
        }
    }
}
