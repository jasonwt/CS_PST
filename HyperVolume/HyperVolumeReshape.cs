namespace PST.HyperVolume
{
    using PST.HyperVolume.Extensions;
    using PST.Types;

    public abstract partial class HyperVolume<T> {
		/***************************** PUBLIC RESHAPE METHOD ***************************/

		public void Reshape(int[] newShape, ReshapeOptions reshapeOptions) {
            if (newShape is null || newShape.Length == 0)
            {
                throw new ArgumentException("New shape must not be null and have at least one dimension", nameof(newShape));
            }

			var assignmentMethod = Assignment.AssignToMethod(typeof(float), typeof(T)) ??
                throw new InvalidOperationException("No assignment method found for type T");

			Type thisType = GetType();
			int thisRank = Rank;
			int thisArea = Area;
			int[] thisShape = Shape;

			int newRank = newShape.Length;
			float thisRankScale = (float)thisRank / (float)newRank;

            if (newRank > thisRank)
            {
                throw new ArgumentException("New rank must be less than or equal to current rank", nameof(newShape));
            }

			float[] newIndexScale = new float[Math.Max(newRank, Rank)];

            // TODO: This needs to be refactored
			for (int i = 0; i < newRank; i++) 
            {
                if (newShape[i] < 1)
                {
                    throw new ArgumentException("New shape must have all positive values", nameof(newShape));
                }

				if (i < thisRank && newShape[i] > 1)
                {
                    newIndexScale[i] = (float)(thisShape[i] - 1.0f) / (float)(newShape[i] - 1.0f);
				}
			}

			IHyperVolume<T>? newVolume = (IHyperVolume<T>?)Activator.CreateInstance(thisType, newShape) ??
				throw new InvalidOperationException("Failed to create new instance of IHyperVolume");

			newVolume.TypeInterpolationMethod = TypeInterpolationMethod;

			int newArea = newVolume.Area;

			newVolume.Foreach((volume, index) => {
				int[] newIndices = volume.Indices(index);

				float[] thisIndicies = new float[thisRank];

				for (int j = 0; j < thisRank; j++)
                {
                    thisIndicies[j] = j switch
                    {
                        _ when j >= newRank => (float)(thisShape[j] - 1) * 0.5f,
                        _ when newShape[j] == 1 => (float)(thisShape[j] - 1) * 0.5f,
                        _ => (float)newIndices[j] * newIndexScale[j]// * thisRankScale
                    };
				}

				volume[newIndices] = this[thisIndicies];
			}, reshapeOptions.ThreadingOptions);

			_shape = newShape;
			_rank = newRank;
			_area = newArea;
			_strides = newVolume.Strides;

            if (_elements is IDisposable disposable)
            {
                disposable.Dispose();
            }

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
