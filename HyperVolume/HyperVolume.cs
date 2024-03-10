namespace PST.HyperVolume {
    public abstract partial class HyperVolume<T> : IHyperVolume<T> {
		/******************************* PRIVATE MEMBERS *******************************/

		private readonly object disposeLock = new();

		private object elements;
		private int[] shape;
		private int[] strides;
		private int rank;
		private int area;

		private Func<T, T, float, T>? typeInterpolationMethod = null;

		/******************************* PUBLIC INDEXERS *******************************/

		public abstract T this[int index] { get; set; }

		public virtual T this[params int[] index] {
			get => this[Index(index)];
			set => this[Index(index)] = value;
		}

		public virtual T this[params float[] index] {
			get {
                if (index.Length != Rank)
                {
                    throw new ArgumentException("Indices must have the same length as the rank", nameof(index));
                }

				int[] valueIndicies = new int[Rank];
				float[] weights = new float[Rank];

				for (int i = 0; i < Rank; i++)
                {
					valueIndicies[i] = (int)index[i];
					weights[i] = index[i] - valueIndicies[i];
				}

				int maxValues = 1 << Rank;

				var values = new T[maxValues];

				for (int i = 0; i < maxValues; i++)
                {
					for (int j = 0; j < Rank; j++)
                    {
                        valueIndicies[j] = (i & (1 << j)) != 0 ? FastCeil(index[j]) : FastFloor(index[j]);
					}

					values[i] = this[valueIndicies];
				}

				int weightsIndex = 0;

                for (int numIterations = values.Length / 2; numIterations >= 1; numIterations /= 2, weightsIndex++)
                {
                    for (int i = 0; i < numIterations; i++)
                    {
                        values[i] = TypeInterpolationMethod(values[i * 2], values[(i * 2) + 1], weights[weightsIndex]);
                    }
                }

				return values[0];
			}
		}

		/******************************* PUBLIC PROPERTIES *******************************/

		public bool IsDisposed { get; set; } = false;

		public virtual object Elements => elements;

		public int Rank => rank;

		public int[] Shape => shape;
		public int[] Strides => strides;

		public int Area => area;

		public Func<T, T, float, T> TypeInterpolationMethod {
			get => typeInterpolationMethod ?? DefaultTypeInterpolationMethod;
			set => typeInterpolationMethod = value ?? DefaultTypeInterpolationMethod;
		}

		/******************************* CONSTRUCTORS ******************************/

		protected HyperVolume(int[] shape) : this(null, shape) { }

		protected HyperVolume(object? data, int[] shape) {
            if (shape is null || shape.Length == 0)
            {
                throw new ArgumentException("shape must not be null and have at least one dimension");
            }

			rank = shape.Length;
			this.shape = shape;

            strides = ComputeStrides(shape);

			area = Strides[^1] * shape[^1];

			elements = InstantiateData(shape, data);

            if (elements is null)
            {
                throw new InvalidOperationException("InstantiateData must return a non-null object");
            }
		}

		~HyperVolume() {
			Dispose();
		}
	}
}
