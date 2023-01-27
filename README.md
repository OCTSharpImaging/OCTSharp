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

<img src="https://user-images.githubusercontent.com/109831624/215009909-802d63ec-3259-4e65-abfa-3c3b90066c56.png" width="200" height="230" caption="Figure 1. Programming Structure. ManagedCuda is open-source and avaliable at https://github.com/kunzmi/managedCuda">

