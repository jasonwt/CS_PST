namespace PST.HyperVolume {
    using System.Runtime.CompilerServices;

    public abstract partial class HyperVolume<T> {
		/******************************* PROTECTED METHODS *******************************/

        protected int[] ComputeStrides(int[] shape)
        {
            if (shape is null || shape.Length < 1)
            {
                throw new ArgumentException("shape must have at least one value");
            }

            int[] strides = new int[shape.Length];
            strides[0] = 1;

            for (int i = 1; i < shape.Length; i++)
            {
                if (shape[i] < 1)
                {
                    throw new ArgumentException("shape must have all positive values");
                }

                strides[i] = strides[i-1] * shape[i-1];
            }

            return strides;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected int FastFloor(float value) {
			return (int)value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected int FastCeil(float value) {
			int valueInt = (int)value;

			return valueInt + (valueInt < value ? 1 : 0);
		}

		/************************** ABSTRACT PROTECTED METHODS ***************************/

		protected abstract object InstantiateData(int[] shape, object? data = null);

		/******************************** PUBLIC METHODS *********************************/

		public T DefaultTypeInterpolationMethod(T a, T b, float w) {
			return w < 0.5f ? a : b;
		}

		public int Index(params int[] indices) {
			string debugInfo = $"indices: {string.Join(", ", indices)}\nShape: {string.Join(", ", Shape)}\nStrides: {string.Join(", ", Strides)}\nRank: {Rank}\nArea: {Area}";

            int index = 0;

			if (Rank < 5)
            {
                if (indices[0] < 0 || indices[0] >= Shape[0])
                {
                    throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range\n" + debugInfo);
                }

                index = indices[0];

                if (Rank > 1)
                {
                    if (indices[1] < 0 || indices[1] >= Shape[1])
                    {
                        throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");
                    }

                    index += (Strides[1] * indices[1]);

                    if (Rank > 2)
                    {
                        if (indices[2] < 0 || indices[2] >= Shape[2])
                        {
                            throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");
                        }

                        index += (Strides[2] * indices[2]);

                        if (Rank > 3)
                        {
                            if (indices[3] < 0 || indices[3] >= Shape[3])
                            {
                                throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");
                            }

                            index += (Strides[3] * indices[3]);
                        }
                    }
                }
			}
            else
            {
				for (int i = 0; i < indices.Length; i++)
                {
                    if (indices[i] < 0 || indices[i] >= Shape[i])
                    {
                        throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");
                    }

					index += indices[i] * Strides[i];
				}
			}

            return index;
        }

		public int[] Indices(int index) {
			int[] indices;

            if (index < 0 || index >= Area)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index value out of range");
            }

			indices = new int[Rank];

			for (int i = Rank - 1; i >= 0; i--)
            {
				indices[i] = index / Strides[i];
				index -= indices[i] * Strides[i];
			}

			return indices;
		}

		public override string ToString() {
			string output = $"HyperVolume of rank {Rank} with Shape {string.Join(", ", Shape)}";

			if (Rank == 2)
            {
				for (int i = 0; i < Shape[0]; i++)
                {
					output += "\n";
					for (int j = 0; j < Shape[1]; j++)
                    {
						output += string.Format("{0:0.00} ", this[j, i]);
					}
				}
			}
            else if (Rank == 3)
            {
				for (int a = 0; a < Shape[0]; a++)
                {
					output += "\n";
					for (int b = 0; b < Shape[1]; b++)
                    {
						output += "\n";
						for (int c = 0; c < Shape[2]; c++)
                        {
							output += string.Format("{0:0.00} ", this[c, b, a]);
						}
					}
				}
			}
            else
            {
				for (int i = 0; i < Area; i++)
                {
					int[] currentIndex = Indices(i);
					output += $"\n[{i}][{string.Join(", ", currentIndex)}]: {this[currentIndex]}";
				}
			}

			return output + "\n";
		}

		public virtual void Dispose() {
            if (IsDisposed)
            {
                return;
            }

			lock (disposeLock)
            {
                if (IsDisposed)
                {
                    return;
                }

                if (elements is IDisposable disposableData)
                {
                    disposableData.Dispose();
                }
			}

			IsDisposed = true;

			GC.SuppressFinalize(this);
		}
	}
}
