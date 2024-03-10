
using PST.HyperVolume.Extensions;
using PST.Types;

namespace PST.HyperVolume
{
    public abstract partial class HyperVolume<T> {
		/***************************** PUBLIC RESHAPE METHOD ***************************/
		
		public void Reshape(int[] newShape, ReshapeOptions reshapeOptions) {
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

			newVolume.Foreach((volume, index) => {
				int[] newIndices = volume.Indices(index);

				float[] thisIndicies = new float[thisRank];

				for (int j = 0; j < thisRank; j++) {
					if (j >= newRank)
						thisIndicies[j] = (float)(thisShape[j] - 1) * 0.5f;
					else if (newShape[j] == 1)
						thisIndicies[j] = (float)(thisShape[j] - 1) * 0.5f;
					else
						thisIndicies[j] = (float)newIndices[j] * newIndexScale[j];// * thisRankScale;
				}

				volume[newIndices] = this[thisIndicies];
			}, reshapeOptions.ThreadingOptions);

			this._shape = newShape;
			this._rank = newRank;
			this._area = newArea;
			this._strides = newVolume.Strides;

			if (_elements is IDisposable disposable)
				disposable.Dispose();

			_elements = InstantiateData(newShape);

			this.Foreach((IHyperVolume<T> volume, int index) => {
				volume[index] = newVolume[index];
			}, reshapeOptions.ThreadingOptions);

			newVolume.Dispose();
		}

		public void Reshape(params int[] newShape) =>
			Reshape(newShape, new ReshapeOptions());
	}
}
