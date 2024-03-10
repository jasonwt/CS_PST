namespace PST.HyperVolume {
	public interface IHyperVolume<T> : IDisposable {
		bool IsDisposed { get; }
		object Elements { get; }
		int Rank { get; }
		int[] Shape { get; }
		int[] Strides { get; }
		int Area { get; }

		T this[int index] { get; set; }
		T this[params int[] index] { get; set; }
		T this[params float[] index] { get; }

		Func<T, T, float, T> TypeInterpolationMethod { get; set; }

		T DefaultTypeInterpolationMethod(T a, T b, float t);

		int Index(params int[] indices);
		int[] Indices(int index);
		float[] VirtualInicies(int[] virtualShape, float[] virtualIndicies);

		//int BlockCopy(object a, object b);
		void Reshape(int[] newShape);
	}
}
