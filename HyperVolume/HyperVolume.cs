using System.Reflection;
using System.Runtime.CompilerServices;

namespace PST.HyperVolume {

	// REVIEW: This should have an XML Docs (/// <summary>...</summary>) comment explaining what it is.
	// REVIEW: I'd expect T to be the type of the elements in the volume, but instead it's being used for the type of the volume itself. This is confusing.
    // REVIEW: Suggest using a `record` or `readonly record struct` instead of `class` for this type, if it's supposed to be immutable.
	public abstract partial class HyperVolume<T> : IHyperVolume<T> {
		/******************************* PRIVATE MEMBERS *******************************/

		private object _disposeLock = new();

		private object _elements;
		private int[] _shape;
		private int[] _strides;
		private int _rank;
		private int _area;
		
		private Func<T, T, float, T>? _typeInterpolationMethod = null;

		/******************************* PUBLIC INDEXERS *******************************/

		public abstract T this[int index] { get; set; }

		public virtual T this[params int[] index] {
			get => this[Index(index)];
			set => this[Index(index)] = value;
		}

		public virtual T this[params float[] index] {
			get {
				if (index.Length != Rank)
					throw new ArgumentException("Indices must have the same length as the rank", nameof(index));

				int[] valueIndicies = new int[Rank];
				float[] weights = new float[Rank];

				for (int i = 0; i < Rank; i++) {
					valueIndicies[i] = (int)index[i];
					weights[i] = index[i] - valueIndicies[i];
				}

				int maxValues = 1 << Rank;

				T[] values = new T[maxValues];

				for (int i = 0; i < maxValues; i++) {
					for (int j = 0; j < Rank; j++) {
						if ((i & (1 << j)) != 0)
							valueIndicies[j] = FastCeil(index[j]);
						else
							valueIndicies[j] = FastFloor(index[j]);
					}

					values[i] = this[valueIndicies];
				}

				int numIterations = values.Length / 2;
				int weightsIndex = 0;

				while (numIterations >= 1) {
					for (int i = 0; i < numIterations; i++)
						values[i] = TypeInterpolationMethod(values[i * 2], values[(i * 2) + 1], weights[weightsIndex]);

					numIterations /= 2;
					weightsIndex++;
				}

				return values[0];
			}
		}

		// REVIEW: nit - Generally the ordering of type members is: fields, events, constructors, properties, methods.
		//               Within that order, it's static members first, then instance members.
		//               Within each of those groups, it's public members first, then protected members, then internal members, then private members.
		/******************************* PUBLIC PROPERTIES *******************************/

		public bool IsDisposed { get; set; } = false;

		public virtual object Elements => _elements;

		public int Rank => _rank;

		// REVIEW: What is Shape, and why is it an array of integers?
		public int[] Shape => _shape;

        // REVIEW: What is Strides, and why is it an array of integers?
        public int[] Strides => _strides;

		public int Area => _area;

		public Func<T, T, float, T> TypeInterpolationMethod {
			get => _typeInterpolationMethod ?? DefaultTypeInterpolationMethod;
			set => _typeInterpolationMethod = value ?? DefaultTypeInterpolationMethod;
		}

		/******************************* CONSTRUCTORS ******************************/

		public HyperVolume(int[] shape) : this(null, shape) { }

		public HyperVolume(object? data, int[] shape) {
			if (shape is null)
				throw new ArgumentNullException("shape");

			if (shape.Length == 0)
				throw new ArgumentException("shape must have at least one dimension");

			_rank = shape.Length;
			_shape = shape;

			_strides = new int[Rank];
			_strides[0] = 1;

			for (int i = 1; i < shape.Length; i++) {
				if (shape[i] < 1)
					throw new ArgumentException("shape must have all positive values");

				_strides[i] = _strides[i - 1] * shape[i - 1];
			}
			
			// REVIEW: this is a bit confusin. Why is the area the product of the last stride and the last shape? Couldn't the area change if the data of the class changes?
			_area = _strides[^1] * shape[^1];

			_elements = InstantiateData(shape, data);

			if (_elements is null)
				throw new InvalidOperationException("InstantiateData must return a non-null object");
		}

		~HyperVolume() {
			Dispose();
		}
	}
}
