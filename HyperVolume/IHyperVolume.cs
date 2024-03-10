using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST.HyperVolume {
    // REVIEW: What is T supposed to be? I would have expected it to be the type of the elements in the volume, but it seems to be something else.
	public interface IHyperVolume<T> : IDisposable {
        // REVIEW: why is this part of the interface?
		bool IsDisposed { get; }
        // REVIEW: why is this an object, and not another generic type? That is, why is the interface not `IHyperVolume<T, TElement>`?
        object Elements { get; }
		int Rank { get; }
		int[] Shape { get; }
		int[] Strides { get; }
		int Area { get; }

		T this[int index] { get; set; }
		T this[params int[] index] { get; set; }
		T this[params float[] index] { get; }

        // REVIEW: what do you mean by "type interpolation"? I know what each of those words means, but I don't know what they mean together.
        Func<T, T, float, T> TypeInterpolationMethod { get; set; }

		T DefaultTypeInterpolationMethod(T a, T b, float t);

		int Index(params int[] indices);

        // REVIEW: Should not return bare arrays, as they can be modified by the caller. Instead, return a copy of the array or use IReadOnlyList<int> or similar.
        int[] Indices(int index);

		//int BlockCopy(object a, object b);

        // REVIEW: What is the purpose of this method? Are you mutating the instance?
		void Reshape(int[] newShape);
	}
}
