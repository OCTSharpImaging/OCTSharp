#define _SIZE_T_DEFOMED
#ifndef __CUDACC__
#define __CUDACC__
#endif
#ifndef __cplusplus
#define __cplusplus
#endif
#define CUDA_CODE_CU

//#include <stdlib.h>
#include <stdio.h>
#include <cuda.h>
#include <cuda_runtime.h>
#include <device_launch_parameters.h>
#include <texture_fetch_functions.h>
#include <builtin_types.h>
#include <vector_functions.h>
#include "float.h"
#include <cufft.h>
#include <cuda_fp16.h>

extern "C" 
{
	__global__ void inputCastKernel(cufftComplex* output, const void* input, const int inputBitdepth, int samplePerBuffer)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
			if (inputBitdepth <= 8) {
				unsigned char* in = (unsigned char*)input;
				output[idx].x = __uint2float_rd(in[idx]);
			}
			else if (inputBitdepth > 8 && inputBitdepth <= 16) {
				unsigned short* in = (unsigned short*)input;
				output[idx].x = __uint2float_rd(in[idx]);
			}
			else {
				unsigned int* in = (unsigned int*)input;
				output[idx].x = __uint2float_rd(in[idx]);
			}	
		output[idx].y = 0;
	}
}	

extern "C"
{
	__global__ void plotSpectrumKernel(unsigned char* output, unsigned short* in, int width, int height)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = 0;

		int pixelIdx = idx % width;
		int pixelOffset = in[pixelIdx];	
		
		int spectrumIndex = idx % height;
		output[spectrumIndex * height + pixelOffset] = 255;
	}
}

extern "C"
{
	__global__ void spectrumByte2FloatKernel(float* output, unsigned char* input)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = __uint2float_rd(input[idx]);
	}
}

extern "C"
{
	__global__ void spectrumFloat2ByteKernel(unsigned char* output, float* input)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = __float2uint_rd(input[idx]);
	}
}

// remove DC by kernel
//extern "C" 
//{
//	__global__ void meanALineSubstractionKernel(cufftComplex *out, float *in, int width, int samples) {
//		int idx = threadIdx.x + blockIdx.x * blockDim.x;
//		out[idx].x = out[idx].x - in[idx % width];
//	}
//}

// remove DC by cublast
extern "C" {
	__global__ void meanALineSubstractionKernel(cufftComplex *out, cufftComplex *in, int width, int height) {
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		out[idx].x = out[idx].x - in[idx % width].x/width;
	}
}

extern "C" 
{
	__global__ void CubicInterpretationKernal(cufftComplex* out, cufftComplex* in, const float*resampleCurve, const int width) {
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		int j = idx % width;
		int offset = idx - j;

		float x = resampleCurve[j];
		int x0 = (int)x;
		int x1 = x0 + 1;
		int x2 = x0 + 2;
		int x3 = x0 + 3;

		float f_x0 = in[offset + x0].x;
		float f_x1 = in[offset + x1].x;
		float f_x2 = in[offset + x2].x;
		float f_x3 = in[offset + x2].x;
		float b0 = f_x0;
		float b1 = f_x1 - f_x0;
		float b2 = ((f_x2 - f_x1) - b1) / (x2 - x0);
		float b3 = ((f_x3 - f_x2) - b2) / (x3 - x0);

		out[idx].x = b0 + b1 * (x - x0) + b2 * (x - x0)*(x - x1) + b3 * (x - x0)*(x - x1)*(x - x2);
		out[idx].y = 0;
	}
}

extern "C" {
	__global__ void modulusKernel(float *output, const cufftComplex *input, const int nx, const int samples, const float max, const float min, const float coeff, const float addend) {
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		if (idx < samples / 2) {
			int lineIndex = idx / nx;
			int inputArrayIndex = lineIndex * nx + idx;	
			output[idx] = (sqrt((input[inputArrayIndex].x * input[inputArrayIndex].x) + (input[inputArrayIndex].y * input[inputArrayIndex].y)));
		}
	}
}

extern "C" 
{
	__global__ void dfsModulusKernel(float *output, cufftComplex *input) 
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;	
		output[idx] = 10.0f *log10f(sqrt((input[idx].x * input[idx].x) + (input[idx].y * input[idx].y)));
		//output[idx] = sqrt((input[idx].x * input[idx].x) + (input[idx].y * input[idx].y));
	}
}

extern "C" 
{
	__global__ void SumKernel(float *output, float *input)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = output[idx] + input[idx];
	}
}

extern "C"
{
	__global__ void AvgKernel(float *output, float *input, const int AvgNum)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = input[idx]/AvgNum;
	}
}

extern "C"
{
	__global__ void VariantKernel(float *output, float *frame1, float *frame2, float *sumframe, const int AvgNum)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		//output[idx] = (frame1[idx] - sumframe[idx]) * (frame1[idx] - sumframe[idx]) + (frame2[idx] - sumframe[idx]) * (frame2[idx] - sumframe[idx]);
		//output[idx] = (frame1[idx] - frame2[idx]) * (frame1[idx] - frame2[idx]);
		//output[idx] = output[idx]/AvgNum;

		//float avg = (frame1[idx] + frame2[idx]) / 2;
		//output[idx] = (frame1[idx] - avg) * (frame1[idx] - avg) + (frame2[idx] - avg) * (frame2[idx] - avg);
		
		output[idx] = abs(frame1[idx] - frame2[idx]);
	}
}

extern "C"
{
	__global__ void BScanOutputCastKernel(unsigned char* output, float* input, const float max, const float min, const float coeff)
	{
		int index = threadIdx.x + blockIdx.x * blockDim.x;
		float* in = input;

		output[index] = 10.0f * log10f(in[index]);
		if ((output[index] - min) / (max - min) >= 0.255) {
			output[index] = 255;//highest 8bit grayscale 			
		}
		else if ((output[index] - min) / (max - min) < 0) {
			output[index] = 0;//lowest 8bit grayscale
		}
		else {
			output[index] = coeff * (output[index] - min) / (max - min);
		}
	}
}

extern "C"
{
	__global__ void EnfaceOutputCastKernel(unsigned char *output, float *input, float max, float min, const float coeff)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		float* in = input;
		max = 150;
		min = 50;
		//output[idx] = input[idx];
		output[idx] = 10.0f * log10f(in[idx]);
		if ((output[idx] - min) / (max - min) >= 0.255) {
			output[idx] = 255;//highest 8bit grayscale 			
		}
		else if ((output[idx] - min) / (max - min) < 0) {
			output[idx] = 0;//lowest 8bit grayscale
		}
		else {
			output[idx] = coeff *(output[idx] - min) / (max - min);
		}
	}
}

extern "C"
{
	__global__ void resetKernel(float *output)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = 0;
	}
}

extern "C"
{
	__global__ void copyKernel(float *output, float *input)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		output[idx] = input[idx];
	}
}

extern "C"
{
	__global__ void AssignComplexOneKernel(cufftComplex *out)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		out[idx].x = 1.0f;
		out[idx].y = 0.0f;
	}
}

//dipreciated functions
extern "C"
{
	__global__ void AverageFrameKernal(float *out, cufftComplex *in, int width, int height, int samples)
	{
		int idx = threadIdx.x + blockIdx.x * blockDim.x;
		for (int i = 0; i < height; i++) {
			out[idx] += in[idx + i * width].x;
		}
		out[idx] /= height;
	}
}