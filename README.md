# OCTSharp 
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
OCTSharp is a muti-threads C# Windows form application that provides hardware control, data acquisition, real-time data processing, and image visualization (Fig. 1). The frontend User Interface (UI) is developed with native .NET framework, and the backend is consisted of two fundamental layers: the hardware control layer developed with the C# SDK  from Teledyne SaperaLT and National Instrument, and the processing layer that is built with ManagedCuda (Fig. 2). ManagedCuda is an open-source C# Application Program Interface (API) that allow CUDA usage in C#. All CUDA kernels are pre-compiled and accessed in real-time during parallel CUDA processing pipeline.
  
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

# Get Started
1. Download Zip 
2. Extract all files
3. Open OCTSharp.exe

<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215039431-ff777656-cea9-44fc-9b4a-d6769c5cabdc.png">
<p align="center">Figure 3. OCTSharp GUI.<p align="center">
  
 # Configure .ccf Camera File
  1. Download SaperaLT SDK that includes the Camera File Configuration Tool: CamExpert (https://www.teledynedalsa.com/en/products/imaging/vision-software/sapera-lt/)
  2. Open CamExpert
  3. Create New .ccf File and set Camera settings
  
  ## Example Camera Settings: 250kHz Dalsa Teledyne OCTOPLUS (more avaliable in Camera files folder) 
  * Basic Timing
  <img src="https://user-images.githubusercontent.com/109831624/215043514-d42c3314-19a3-430b-bf7f-f1efdf808872.JPG" width="800" height="400">
  * Advance Control
   <img src="https://user-images.githubusercontent.com/109831624/215043817-a52b2ede-8e77-4346-8923-fb5855997ff5.JPG" width="800" height="400">
  * Externel Trigger
   <img src="" width="800" height="400">
  * Image Buffer and ROI
   <img src="" width="800" height="400">
  
  
