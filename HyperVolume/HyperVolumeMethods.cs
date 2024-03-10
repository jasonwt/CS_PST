using PST.Types;
using System.Runtime.CompilerServices;

namespace PST.HyperVolume {
	public abstract partial class HyperVolume<T> {
		/******************************* PROTECTED METHODS *******************************/
		
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
			string debugInfo = $"indices: {string.Join(", ", indices)}\n_shape: {string.Join(", ", _shape)}\n_strides: {string.Join(", ", _strides)}\n_rank: {_rank}\n_area: {_area}";
			if (Rank < 5) {
				if (indices[0] < 0 || indices[0] >= _shape[0])
					throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range\n" + debugInfo);

				int index = indices[0];

				if (Rank == 1)
					return index;

				if (indices[1] < 0 || indices[1] >= _shape[1])
					throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");

				index += (_strides[1] * indices[1]);

				if (Rank == 2)
					return index;

				if (indices[2] < 0 || indices[2] >= _shape[2])
					throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");

				index += (_strides[2] * indices[2]);

				if (Rank == 3)
					return index;

				if (indices[3] < 0 || indices[3] >= _shape[3])
					throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");

				return index + (_strides[3] * indices[3]);
			} else {
				int index = 0;

				for (int i = 0; i < indices.Length; i++) {
					if (indices[i] < 0 || indices[i] >= _shape[i])
						throw new ArgumentOutOfRangeException(nameof(indices), "Index value out of range");

					index += indices[i] * _strides[i];
				}

				return index;
			}
		}

		public int[] Indices(int index) {
			int[] indices;

			if (index < 0 || index >= Area)
				throw new ArgumentOutOfRangeException(nameof(index), "Index value out of range");

			indices = new int[Rank];

			for (int i = Rank - 1; i >= 0; i--) {
				indices[i] = index / _strides[i];
				index -= indices[i] * _strides[i];
			}

			return indices;
		}

		public void Reshape(params int[] newShape) {
			if (newShape is null)
				throw new ArgumentNullException(nameof(newShape));

			if (newShape.Length == 0)
				throw new ArgumentException("New shape must have at least one dimension", nameof(newShape));

			var assignmentMethod = Assignment.AssignToMethod(typeof(float), typeof(T));

			if (assignmentMethod is null)
				throw new InvalidOperationException("No assignment method found for type T");
			
			Type thisType = this.GetType();
			int thisRank = this.Rank;
			int thisArea = this.Area;
			int[] thisShape = this.Shape;
			
			int newRank = newShape.Length;
			float thisRankScale = (float)thisRank / (float)newRank;

			if (newRank > thisRank)
				throw new ArgumentException("New rank must be less than or equal to current rank", nameof(newShape));

			float[] newIndexScale = new float[Math.Max(newRank, this.Rank)];

			for (int i = 0; i < newIndexScale.Length; i++) {
				if (i < newRank) {
					if (newShape[i] < 1)
						throw new ArgumentException("New shape must have all positive values", nameof(newShape));

					if (i < thisRank) {
						//if (newShape[1] > 1)
						if (newShape[i] > 1)	
							newIndexScale[i] = (float)(thisShape[i] - 1.0f) / (float)(newShape[i] - 1.0f);
					}
				}
			}

			IHyperVolume<T>? newVolume = (IHyperVolume<T>?)Activator.CreateInstance(thisType, newShape) ??
				throw new InvalidOperationException("Failed to create new instance of IHyperVolume");

			newVolume.TypeInterpolationMethod = this.TypeInterpolationMethod;

			int newArea = newVolume.Area;

			for (int i = 0; i < newArea; i++) {
				int[] newIndices = newVolume.Indices(i);

				float[] thisIndicies = new float[thisRank];

				for (int j = 0; j < thisRank; j++) {
					if (j >= newRank)
						thisIndicies[j] = (float)(thisShape[j] - 1) * 0.5f;
					else if (newShape[j] == 1)
						thisIndicies[j] = (float)(thisShape[j] - 1) * 0.5f;
					else
						thisIndicies[j] = (float)newIndices[j] * newIndexScale[j];// * thisRankScale;
				}
				
				newVolume[newIndices] = this[thisIndicies];
			}

			this._shape = newShape;
			this._rank = newRank;
			this._area = newArea;
			this._strides = newVolume.Strides;

			if (_elements is IDisposable disposable)
				disposable.Dispose();

			_elements = InstantiateData(newShape);

			for (int i = 0; i < newArea; i++)
				this[i] = newVolume[i];

			newVolume.Dispose();
		}

		public override string ToString() {
			string output = $"HyperVolume of rank {Rank} with Shape {string.Join(", ", Shape)}";

			if (Rank == 2) {
				for (int i = 0; i < Shape[0]; i++) {
					output += "\n";
					for (int j = 0; j < Shape[1]; j++) {
						var thisValue = this[j,i];
						output += string.Format("{0:0.00} ", thisValue);
					}
				}
			} else if (Rank == 3) {
				for (int a = 0; a < Shape[0]; a++) {
					output += "\n";
					for (int b = 0; b < Shape[1]; b++) {
						output += "\n";
						for (int c = 0; c < Shape[2]; c++) {
							var thisValue = this[c, b, a];
							output += string.Format("{0:0.00} ", thisValue);
						}

					}
				}
			} else {
				for (int i = 0; i < Area; i++) {
					int[] currentIndex = Indices(i);
					output += $"\n[{i}][{string.Join(", ", currentIndex)}]: {this[currentIndex]}";
				}
			}

			return output + "\n";
		}

		public virtual void Dispose() {
			if (IsDisposed)
				return;

			lock (_disposeLock) {
				if (IsDisposed)
					return;

				if (_elements is IDisposable disposableData)
					disposableData.Dispose();
			}

			IsDisposed = true;

			GC.SuppressFinalize(this);
		}
	}
}
