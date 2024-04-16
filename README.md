# OCTSharp <img src="https://user-images.githubusercontent.com/109831624/215054645-12b3c536-b8a4-467f-bf94-95eb6615d4ef.png" width="70" height="70">

With the advance of hardware technology, imaging speed of Optical Coherence Tomography
(OCT) has reached hundreds of kHz for spectral domain OCT (SD-OCT) and it even breaks into MHz territory for swept source OCT.
High-speed imaging demands massive computation power for high throughput data acquisition, processing, and
visualization. Commercial OCT software provided with the OCT devices is convenient, but users usually cannot access
the source code to tailor the software for specific applications nor modify the hardware. For independent research groups, a
significant amount of effort is often spent on developing OCT software for real-time imaging, especially for clinical
applications. On the other hand, developing software that accommodates different hardware is often challenging. Virtual
processing plugin in C++ (https://github.com/spectralcode/OCTproZ) and OCT software development library in C++ (https://www.vortex-oct.dev/) are being explored. However, developing or
maintaining C++ based OCT software is often challenging for non-professional software developers due to its complexity
of low-level memory management and the steep learning curve of C++ programming. In this project, OCTSharp is developed
as open-source software that aims to significantly lower the programming complexity and development cycle for an
interactive, intuitive, and high-performance OCT developmental solution.

# Software Architecture
Software architecture with multi-threading and GPU-based Compute Unified Device Architecture (CUDA) implementation is efficient for real-time OCT imaging in C++. OCTSharp shares a similar architecture but is implemented in C#. The hardware control is achieved using Software Development Kits (SDKs), including Sapera LT 8.6 from Teledyne DALSA and DAQmx 20.1 from National Instruments. To seamlessly interact with the CUDA library in C#, OCTSharp utilizes ManagedCuda, an open-source API that wraps the CUDA library in C#. ManagedCuda provides a type-safe and object-oriented way to access CUDA resources in a class-based reference to CUDA API, as opposed to the pointer-oriented manner in C++ or C. Notably, all CUDA kernels are written in CUDA C and pre-compiled into a dedicated PTX file using the NVIDIA CUDA Compiler (NVCC) and it is loaded prior to the runtime for real-time imaging processing.

Figure 1 provides a detailed description of the multi-threading logic with the relationship between the hardware and software. The FG has a default ring buffer (or cycling buffer) structure to store raw frames (spectral data) from the camera. A Direct Memory Access (DMA) controller handles data transfer from the FG to the frame buffer in the host memory. If the ring buffer becomes filled, it triggers a frame lost event, which is used as a monitor during imaging to alert potential raw data loss. During imaging acquisition, four dedicated threads are launched on the CPU by OCTSharp, including the Graphical User Interface (GUI) thread, the transfer thread, the process thread, and the display thread. The GUI thread primarily manages real-time events, such as user interactions, visualization of benchmark parameters, and charting updates. The transfer thread is initiated by a callback function triggered by the frame available signal whenever a frame is ready in the frame buffer. It then notifies the process thread to commence the OCT imaging processing pipeline. Additionally, the transfer thread handles the transfer of raw frames from the frame buffer to a preallocated volume buffer in the host memory when a user requests to save the raw data before imaging acquisition. After the imaging section, the raw frames in the volume buffer will be saved automatically to a local drive for post-processing.
  
<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/bd5b5bdb-04eb-405b-a84b-046cad995492" width="800" height="500">
<p align="center"><p align="center"> Figure 1. Software Architecture. OCTSharp Software Architecture. On-board Ring Buffer: Default FIFO memory on the FG; DMA: Direct Memory Access; Frame Lost Event: a software event when the on-board ring buffer overflows; Frame buffer: A buffer for saving a raw B-Scan; Volume Buffer: A pre-allocated buffer for saving raw C-Scan; H2D: data transfer from the host frame buffer to the device memory in a GPU; D2H: data transfer from the device memory to a host page-locked memory; The flash signs represent a software trigger callback event.

## Programming Dependencies
  * .NET Framework 4.6.2
  * NVIDIA CUDA 11.1
  * ManagedCUDA 11.1
# Hardware Configuration
Figure 2 and 3 shows the hardware connection and configuration details. The C# .NET layer was developed using the Software Development Kit (SDK) from Teledyne Dalsa and National Instrument. Therefore, any image acquisition card (IMAQ) from Teledyne Dalsa and data acquisition card (DAQ) from National Instrument are compatible with OCTSharp. In this project, we tested mutiple IMAQ cards, including Xtium-CL MX4 and Xcelera-CL LX1; DAQ cards including PCIe 6361and PCI 6221. Four linear cameras have been also tested independently, which works as expected, including Dalsa Octoplus, AVIIVA SM2 4010 CL, Basler spL 2048 70km, and Sensor Unlimited GL 2048R. User can use any linear camera in OCTSharp as long as the camera file is configured appropriately. Galvanometer scanner can be modified freely as well, where the scanning distance can be adjusted via voltage parameters setting on UI. DAQ is mainly responsible for hardware synchronization and scanner control. DAQs from other vendors can be used as long as C# SDK is provided and the corresponding analog and digital hardware functions are modified accordingly. The master clock of the system is supplied as a strobe signal by a user-specified internal frequency from the Teledyne Dalsa IMAQ card, in the vendor software: CamExpert. Using this master clock, OCTSharp synchronizes the camera with the galvanometer scanner. In addition, the camera runs on external trigger mode based on the acquisition clock, which is generated from master clock and it is adjustable by the user.
  
<p align="center">
<img src="https://user-images.githubusercontent.com/109831624/215050382-0af7a790-d49a-43b4-b245-b5b68f4e1d79.PNG" width="508" height="400">
<p align="center">Figure 2. OCTSharp hardware connection. AO0, AO1 are analog output channels on PCIe-6361; CTR0 and TRIG 1 are trigger channels on the PCIe-6361, which are acquisition trigger for camera and master clock respectively; J4 I/O is the general Input & Output ports on the Xtium CL MX4; Two medium CameraLink cables are used to achieve 250kHz image acquisition with Dalsa OCTOPLUS camera at 10-bit 8TAP mode and 85MHz pixel clock. MX-4 has a bandwidth of 1.4GB/s on PCIe Gen.2x4 connection <p align="center">
<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/193ca2ff-3602-4fa2-99af-5a15c21403c6">
<p align="center">Figure 3. OCTSharp hardware configuration. A) The hardware connection and triggering mechanism of the SD-OCT system. SLED: Super Luminescent LED; C: Collimator; PC: Polarization Controller; FL: Focusing Lens; M: Mirror; DG: Diffraction Grating; LC: Linear Camera; FG: Frame Grabber; DMA: Direct Memory Access; DAC: Digital Acquisition Card; CPU: Central Processing Unit; GPU: Graphical Processing Unit. B) The timing diagram of the master clock to synchronize the camera using frame sync, and the corresponding timing of the X-Y galvanometer scanner’s voltage position. <p align="center">

 # Environment Preparation
 ## Set Camera hardware parameters with manufacture's software
  * For example, Dalsa Teledyne OCTOPUS Camera is configured with CommCam.exe
  * Set camera parameters, such as: Line Acquisition Rate, Externel Trigger, CameraLink Tap Config, Image Bit Rate, etc..
  (These settings need to be consistent with the parameters in camera files, otherwise OCTSharp won't perform properly)
  <img src="https://user-images.githubusercontent.com/109831624/215045672-5208d85c-580b-47e0-9c49-ff2e0339ec74.JPG">
  
 ## Configure .ccf Camera File
  1. Download SaperaLT SDK that includes the Camera File Configuration Tool: CamExpert (https://www.teledynedalsa.com/en/products/imaging/vision-software/sapera-lt/)
  2. Open CamExpert
  3. Create New .ccf File and set Camera settings
  
  ## CamExpert Camera Settings example: 250kHz Dalsa Teledyne OCTOPUS  (more avaliable in Camera files folder) 
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
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/41e6d3ab-e314-497b-affa-214c44121452",width="712" height="712">
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
  8. Enable display features (Warning: Enable mutiple plotting charts may cause GUI freeze, see Garbage Collection benchmark below for detail)
  9. Click "Scan" button to perform Imaging
  10. Click "Stop" to exit imaging section
  11. Click "Save" button to perform one time scan and save raw data to the pre-defined directory (if Save is enabled with directory)
  
  # In vivo Imaging Demo
  Human fingernails and the Newt anterior chamber were utilized to showcase the in vivo imaging performance of OCTSharp in Fig. 5. Given the high scattering properties of human skin, in vivo imaging of the fingernail was conducted using PC2 at 1310 nm, and shown in Fig. 5(A). Here, the real-time B-Scan of the fingernail shows various tissue structures, including the nail bed, cuticle, nail fold, nail root, epidermis, and dermis. Subsequently, a C-scan comprising 512 B-scans was acquired and saved. Raw data are post-processed with MATLAB (R2023a) and the volumetric view is visualized with ImarisViewer (9.9.1, Oxford Instrument) as shown in Fig. 5(B).In our previous work, we demonstrated the unique capability of using OCT to in vivo monitor the lens regeneration process of Newts. Therefore, we continue using this animal model to validate the performance of OCTSharp. In particular, we want to test if the raw data captured by OCTSharp can be used for reconstructing the microvascular network in the iris. Since the anterior chamber is transparent, we take advantage of the wavelength of PC1 at 850 nm, which can capture images with lateral and axial resolution at ∼7 µm and the line rate at 250kHz. Five B-scans are captured at each location, resulting in a total of 5 × 512 B-scans, which are saved as raw data. Fig. 5(C) shows the 3D reconstructed anterior chamber of a newt’s eye, highlighting all morphological tissue structures. Fig. 7(D) shows the microvascular network of the iris, extracted using the speckle variance technique. These images confirm that OCTSharp can acquire high-quality B-scan images for reconstructing volumetric images of general tissue structure and the microvasculature of the iris.


<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/20aacbec-8336-4d04-bee7-7747f89fd99e",width="730" height="730">
<p align="center">Figure 5. In vivo images acquired with OCTSharp. A: B-Scan of the fingernail structure inside the red rectangle area captured with PC2; B: C-Scan perspective view of A; C: Cut-out-view of the Newt’s anterior chamber inside the red rectangle area captured with PC2; D: Optical Coherence Tomography Angiography of the Newt’s iris and the surrounding skin tissue, captured with PC1. Scale bar: 100 µm..<p align="center">
  
  # Software Performance
Various hardware configurations were tested to validate the software’s compatibility and performance (Table. 1). Three commonly used linear cameras with line rates at 36kHz, 147kHz, and 250kHz were included to show the compatibility of the software. Different DACs that were previously used in other OCT studies were also included to show the hardware expandability. Two computers configured with different hardware were built to benchmark the imaging performance.

<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/718385ab-b39f-452f-afd8-950a08b31a76">
<p align="center">Table 1. Configuration and performance of two different hardware platforms. 𝑻𝒔: B-Scan Acquisition Cycle Time. 𝑻𝒑: B-Scan Processing Time..<p align="center">
  

  
  ## Garbage Colletion
Different memory management mechanisms are adapted in C++ and C#. In C++ applications, memory safety issues, such as buffer overflows or null pointer dereferences, can lead to unpredictable crashes, or security vulnerabilities. Developers must be diligent in managing memory properly to avoid these issues. In contrast, C# provides automatic memory management known as auto GC. The .NET CLR constantly evaluates the life span of the managed objects and releases unused resources to free the memory when necessary. This automatic memory management mechanism releases the developer from the hassle of dynamic memory management. However, GC can stop the managed threads. This is often referred to as “stop the world” or “pause the world”. To minimize the impact of “stop the world”, the .NET categorizes GC events into 3 different levels, Gen 0, Gen 1, and Gen 2, where Gen 2 GC is known as a full GC that takes the longest time to collect all unused objects from all three depth, while the other two levels take a much shorter time, but they all suspend the managed threads once occur.

During high-speed image acquisition, the occurrence of GC events is inevitable and can pose potential risks of frame loss. Figure 6 illustrates the time diagram of B-scan acquisition and processing cycles with and without GC. To ensure real-time processing of every incoming B-scan, the B-scan processing time without accounting for GC, denoted as TP, must be shorter than the B-scan acquisition cycle time, TS, as depicted in the in Fig. 6. For example, for imaging acquisition with PC2 shown in Table. 1, the maximum B-scan processing time without accounting GC, TP (2.3 ms), is much less than TS (10ms as 𝑇𝑠1
). Therefore, all acquired images will be timely processed. However, when GC occurs during an acquisition cycle, managed threads like the transfer thread or the processing thread will experience interruptions. Consequently, the total B-scan processing time, TTP, including TP and the interruption time of GC, TGC, can be larger than TS, shown 𝑇𝑠2 in Fig. 6. The incoming frame in that cycle cannot be processed promptly, potentially leading to frame loss. Figure 7 plots the histogram of TTP distribution recorded continuously through three-hour live imaging with PC2 setup. The red vertical line shown in Fig. 7 represents the location of TS. Most TTP are between 1.19 ms to 2.19 ms, which is far less than TS. However, TTP can be significantly longer, up to around 12.3 ms due to GC events and the variation of data transfer and processing. In about 99.94% of all cycles, TTP is less than TS. On the other hand, in about 0.06% of cycles, TTP is longer than TS, the case depicted as 𝑇𝑠2 in Fig. 6. In these cycles, due to overtime B-scan processing time, incoming frames cannot be processed before the next frame is ready. The next frame may be lost.

<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/676140b1-cfcd-44b0-8f33-8d7c5beff132"width="530" height="330">
<p align="center">Figure 6. Illustration of the relationship between the acquisition cycle and the processing cycle of each B-Scan. 𝑇𝑝: B-scan processing time. 𝑇𝐺𝐶: Garbage Collection time. 𝑇𝑇𝑃: Total B-scan processing time when GC events occur. 𝑇𝑠1,𝑇𝑠2:B-Scan acquisition cycle time.

<p align="center">
<img src="https://github.com/OCTSharpImaging/OCTSharp/assets/109831624/33821b10-2cf9-46b5-a48e-c7b6268425da"width="730" height="430">
<p align="center">Figure 7. The histogram of the 𝑻𝒑for all acquired frames during a 3-hour imaging section with a B-Scan image size of 2048 × 1000 using PC2. 𝑇𝑠 is 10 ms as shown by the red-dotted line, which is equivalent to a B-Scan acquisition rate at 100 Hz.

In OCTSharp, the potential frame loss due to GC is accommodated from three aspects. First, we pre-allocate large data buffers, like the frame, volume, and display buffer, as unmanaged resources to avoid GC2 events; Second, we avoid creating unnecessary objects by reusing them to reduce the frequency of GC events. As a result, the total time fraction of GC during imaging acquisition is controlled at less than 0.1% of the total acquisition time. Third, we adopted an FG (Xtium-XL MX4) with a ring buffer mechanism to queue frames if they cannot be processed on time. In our case, the FG has an on-board memory space of 512 MB. For a B-Scan with a size of 2048 × 1000, 131 ring buffers are allocated on the FG. When OCTSharp cannot process the current frame in the frame buffer on time due to GC, the following frames from the camera will be stored in the ring buffer. Once GC events are completed, all the frames queued in the ring buffer will be processed based on the FIFO manner. Note the FIFO mechanism can work effectively only if the time fraction attributed to overtime B-scan processing is very small. If the time fraction of overtime B-scan processing time is significant, even a sufficiently large ring buffer that can store all queued images, the images will be displayed with a noticeable time delay caused by the cumulative overtime events. In our case, the fraction of overtime B-scan processing time is only 0.06% (Fig. 7). Thus, no frame lost or delayed display occurred during the entire 3-hour live imaging section.
  
  # Compile/Debug with Visual Studio
  * Visual Studio 2017/2019 Community
  
  # Compile your own CUDA processing file  
  OCTProz is an Open-source OCT project in C++ (https://github.com/spectralcode/OCTproZ) that provides a set of OCT processing functions in CUDA C. Therefore their CUDA file provides a great reference for OCTSharp CUDA processing pipeline. v1.4.8 version currently provides basic OCT processing functions, including DC removal, 3rd calibration, FFT and modulus calculation (see display feature for other processing options). More processing functions will be added in the future.  User can also refer to OCTProz's repository and compile your own CUDA file.
  * CUDA Compile steps  
  1.TBA
  
  
  # Version History
  * v1.4.8: First release version
  
  # Road Map
 ⬜ Alternative Processing buffers to optimize GPU performance  
 ⬜ OpenTK Integration for real-time 3D C-Scan display    
 ⬜ Bidirectional scanner pattern to optimize acquisition speed  
 ⬜ Flat GUI update  
    
  # Known Bugs
   
  
  # License  
  This project is licensed under the Attribution-NonCommercial-ShareAlike 4.0 International. Check LICENSE.md file for details
 https://creativecommons.org/licenses/by-nc-sa/4.0/





  
