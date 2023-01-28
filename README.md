# OCTSharp <img src="https://user-images.githubusercontent.com/109831624/215054645-12b3c536-b8a4-467f-bf94-95eb6615d4ef.png" width="70" height="70">

With the advance of hardware technology, imaging speed of Optical Coherence Tomography
(OCT) has reached hundreds of kHz for spectral domain OCT (SD-OCT) and it even breaks into MHz territory for swept source OCT.
High-speed imaging demands massive computation power for high throughput data acquisition, processing, and
visualization. Commercial OCT software provided with the OCT devices is convenient, but users usually cannot access
the source code to tailor the software for specific applications nor modify the hardware. For independent research groups, a
significant amount of effort is often spent on developing OCT software for real-time imaging, especially for clinical
applications. On the other hand, developing software that accommodates different hardware is often challenging. Virtual
processing plugin and OCT software development library in C++ have been explored. However, developing or
maintaining C++ based OCT software is often challenging for non-professional software developers due to its complexity
of low-level memory management and the steep learning curve of C++ programming. In this project, OCTSharp is developed
as open-source software that aims to significantly lower the programming complexity and development cycle for an
interactive, intuitive, and high-performance OCT developmental solution.

# Programming Structure
OCTSharp is a muti-threads C# Windows form application that provides hardware control, data acquisition, real-time data processing, and image visualization. The frontend User Interface (UI) is developed with native .NET framework, and the backend is consisted of two fundamental layers: the hardware control layer developed with the C# SDK  from Teledyne SaperaLT and National Instrument, and the processing layer that is built with ManagedCuda (Fig. 1). ManagedCuda is an open-source C# Application Program Interface (API) that allow CUDA usage in C#. All CUDA kernels are pre-compiled and accessed in real-time during parallel CUDA processing pipeline.
  
<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215009909-802d63ec-3259-4e65-abfa-3c3b90066c56.png" width="200" height="230">
<p align="center">Figure 1. Programming Structure. ManagedCuda is open-source and avaliable at https://github.com/kunzmi/managedCuda<p align="center">

<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215012313-6a08d241-f1a4-4a75-a764-2bb36fdb2e72.png" width="408" height="300">
<p align="center">Figure 2. Software Architecture.<p align="center">
  
## Programming Dependencies
  * .NET Framework 4.6.2
  * NVIDIA CUDA 11.1
  * ManagedCUDA 11.1
# Hardware Configuration
Figure 3 shows the current hardware configuration. The C# .NET layer was developed using the Software Development Kit (SDK) from Teledyne Dalsa and National Instrument. Therefore, any image acquisition card (IMAQ) from Teledyne Dalsa and data acquisition card (DAQ) from National Instrument are compatible with OCTSharp. In this project, we tested mutiple IMAQ cards, including Xtium-CL MX4 and Xcelera-CL LX1; DAQ cards including PCIe 6361and PCI 6221. Four linear cameras have been also tested independently, which works as expected, including Dalsa Octoplus, AVIIVA SM2 4010 CL, Basler spL 2048 70km, and Sensor Unlimited GL 2048R. User can use any linear camera in OCTSharp as long as the camera file is configured appropriately. Galvanometer scanner can be modified freely as well, where the scanning distance can be adjusted via voltage parameters setting on UI. DAQ is mainly responsible for hardware synchronization and scanner control. DAQs from other vendors can be used as long as C# SDK is provided and the corresponding analog and digital hardware functions are modified accordingly. The master clock of the system is supplied as a strobe signal by a user-specified internal frequency from the Teledyne Dalsa IMAQ card, in the vendor software: CamExpert. Using this master clock, OCTSharp synchronizes the camera with the galvanometer scanner. In addition, the camera runs on external trigger mode based on the acquisition clock, which is generated from master clock and it is adjustable by the user.
  
  <p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215050382-0af7a790-d49a-43b4-b245-b5b68f4e1d79.PNG">
<p align="center">Figure 3. OCTSharp hardware configuration. AO0, AO1 are analog output channels on PCIe-6361; CTR0 and TRIG 1 are trigger channels on the PCIe-6361, which are acquisition trigger for camera and master clock respectively; J4 I/O is the general Input & Output ports on the Xtium CL MX4; Two medium CameraLink cables are used to achieve 250kHz image acquisition with Dalsa OCTOPLUS camera at 10-bit 8TAP mode and 85MHz pixel clock. MX-4 has a bandwidth of 1.4GB/s on PCIe Gen.2x4 connection <p align="center">
  
 # Environment Preparation
 ## Set Camera hareware parameters with manufacture's software
  * For Example, Dalsa Teledyne OCTOPLUS Camera is configured with CommCam.exe
  * Set Camera parameters, such as: Line Acquisition Rate, Externel Trigger, CameraLink Tap Config, Image Bit Rate, etc..
  <img src="https://user-images.githubusercontent.com/109831624/215045672-5208d85c-580b-47e0-9c49-ff2e0339ec74.JPG">
  
 ## Configure .ccf Camera File
  1. Download SaperaLT SDK that includes the Camera File Configuration Tool: CamExpert (https://www.teledynedalsa.com/en/products/imaging/vision-software/sapera-lt/)
  2. Open CamExpert
  3. Create New .ccf File and set Camera settings
  
  ## CamExpert Camera Settings example: 250kHz Dalsa Teledyne OCTOPLUS  (more avaliable in Camera files folder) 
  * Basic Timing
  <img src="https://user-images.githubusercontent.com/109831624/215043514-d42c3314-19a3-430b-bf7f-f1efdf808872.JPG">
  * Advance Control
  <img src="https://user-images.githubusercontent.com/109831624/215043817-a52b2ede-8e77-4346-8923-fb5855997ff5.JPG">
  * Externel Trigger
  <img src="https://user-images.githubusercontent.com/109831624/215044067-5db7f993-97a7-42ae-93d3-9ce68c16b471.JPG">
  * Image Buffer and ROI
  <img src="https://user-images.githubusercontent.com/109831624/215044140-f078f96c-de80-412c-ab2e-02719931c003.JPG"> 

  # Get Started to image with OCTSharp
  1. Download Zip 
  2. Extract all files
  3. Open OCTSharp.exe (at \bin\x64\Release)

<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215039431-ff777656-cea9-44fc-9b4a-d6769c5cabdc.png">
<p align="center">Figure 4. OCTSharp GUI.<p align="center">
  
  4. Adjust Scanner Voltage (sacaning distance)
  5. Load the corresponding .ccf file
  6. Load 3rd Calibration Curve as excel file if needed 
  7. Set OCT parameters as needed
  * ANum: number of Linear Camera's pixels 
  * BNum: number of A-Scans
  * CNum: number of B-Scans
  * FNum: number of frames for each B-Scans
  * RNum: number of A-Scans for scanner return
  8. Enable display features (Warning: Enable mutiple plotting charts may cause GUI freeze)
  9. Click "Scan" button to perform Imaging
  10. Click "Stop" to exit imaging section
  11. Click "Save" button to perform one time scan and save raw data to the pre-defined directory (if Save is enabled with directory)
  
  # OCT Display options 
  <p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215049174-a5bf054d-1aa4-49ba-8e75-5c50a74122a3.png">
<p align="center">Figure 5. Different visualization features in OCTSharp showing the newt anterior chamber of eye. (A) B-Scan (2048x2048) of a Newt eye; (B) An average B-Scan consists of 10 B-Scans at the same scanning position as A’s (B); (C) A Speckle Variant map that shows the blood vessels location in A; (D) An enface image of a newt’s eye; (E) An Volumetric C-Scan generated from data collected in OCTSharp; (F) The angiography display function of OCTSharp that shows the enface blood vessels of (D)..<p align="center">
  
  # Software Performance
Two different PC configurations were tested (Tab 1). The highest A-Scan acquisition rate is 250kHz, and A-Scan processing speed can reach up to 350 kHz. The limitation for current processing speed is the data I/O between CPU memory and GPU memory, as it takes up about 50% of the CPU resource. 
<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215051432-abee4bf4-b314-4061-a471-5854dd146251.png">
<p align="center">Table 1. Software Performance w/ different PC Configurations.<p align="center">
  
  # Compile/Debug with Visual Studio
  * Visual Studio 2017/2019 Community
  
  # Version History
  * v1.4.8: First release version
  
  # Road Map
 ⬜ Alternative Processing buffers to optimize GPU performance  
 ⬜ OpenTK Integration for real-time 3D C-Scan display    
 ⬜ Bidirectional scanner pattern to optimize acquisition speed  
 ⬜ Flat GUI update  
    
  # License  
  This project is licensed under the Attribution-NonCommercial-ShareAlike 4.0 International. Check LICENSE.md file for details
 https://creativecommons.org/licenses/by-nc-sa/4.0/





  
