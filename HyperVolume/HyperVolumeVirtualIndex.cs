namespace PST.HyperVolume {
    using System;

    public partial class HyperVolume<T>
    {
        public float[] VirtualInicies(int[] virtualShape, float[] virtualIndicies) {
			if (virtualShape is null || virtualShape.Length == 0) {
				throw new ArgumentException(nameof(virtualShape), "virtualShape must not be null and have at least one dimension");
			}

			if (virtualIndicies is null || virtualIndicies.Length != virtualShape.Length) {
				throw new ArgumentException("virtualIndicies must not be null and have the same length as virtualShape");
			}

			if (virtualIndicies.Length != Rank)
			{
				throw new ArgumentException(nameof(virtualIndicies), "virtualIndicies must have the same length as the current rank");
			}

			float[] thisIndicies = new float[Rank];

			for (int i = 0; i < virtualShape.Length; i++) {
				if (virtualShape[i] < 1) {
					throw new ArgumentException("virtualShape must have all positive values", nameof(virtualShape));
				}
				if (virtualIndicies[i] < 0 || virtualIndicies[i] >= virtualShape[i]) {
					throw new ArgumentException("virtualIndicies must be within the bounds of virtualShape", nameof(virtualIndicies));
				}

				float thisScale = (float)(Shape[i] - 1.0f) / (float)(virtualShape[i] - 1.0f);

				thisIndicies[i] = thisScale * virtualIndicies[i];
			}

			return thisIndicies;
		}
	}
}
