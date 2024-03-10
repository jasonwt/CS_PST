// <copyright file="ConvolutionExtension.cs">Copyright (c) Jason Thompson. All rights reserved.</copyright>

namespace PST.HyperVolume.Extensions {
    using PST.HyperVolume.Selection;

    static public class ConvolutionExtension {
		static public void Convolve<T>(this IHyperVolume<T> volume, IHyperVolume<T> kernel, ISelection<T>? selection = null, ThreadingOptions threadingOptions = default) {
			if (kernel is null) {
				throw new ArgumentNullException(nameof(kernel));
			}
			if (kernel.Rank != volume.Rank) {
				throw new ArgumentException("Kernel must have the same rank as the volume", nameof(kernel));
			}

			bool useIndexScales = false;
			float[] kernelIndexScales = new float[volume.Rank];
			int[] kernelOffsets = new int[kernel.Rank];

			for (int i = 0; i < kernel.Rank; i++)
			{
				kernelOffsets[i] = (int)(kernel.Shape[i] / 2);

				kernelIndexScales[i] = kernel.Shape[i] % 2 != 0 ? 1.0f : 
					(float)(kernel.Shape[i] - 1) / (float)kernel.Shape[i];

				useIndexScales = useIndexScales || kernelIndexScales[i] != 1.0f;
			}

			T[] tmpArray = volume.ToArray();

			volume.Foreach((IHyperVolume<T> volume, int index) => {
				// TODO: I should create an array of indices so the iteration will be more efficient and not
				// have to call	
			}, selection, threadingOptions);

			


			
		}
	}

}