namespace PST.HyperVolume.Selection.Implementations {
	public class VolumeSelection<T> : Selection<T> {
		internal readonly struct SelectionVolume {
			public int[] MinIndicies { get; }
			public int[] MaxIndices { get; }
			public float SelectionStrength { get; }

			public SelectionVolume(int[] minIndicies, int[] maxIndiceis, float selectionStrength = 1.0f) {
                if (minIndicies is null || maxIndiceis is null)
                {
                    throw new ArgumentNullException(minIndicies is null ? nameof(minIndicies) : nameof(maxIndiceis), "minIndices and maxIndicies must not be null.");
                }

                if (minIndicies.Length == 0 || maxIndiceis.Length == 0)
                {
                    throw new ArgumentException("minIndicies and maxIndices must have at least one element.");
                }

                if (minIndicies.Length != maxIndiceis.Length)
                {
                    throw new ArgumentException("minIndicies and maxIndices must have the same length.");
                }

                if (selectionStrength is < 0.0f or > 1.0f)
                {
                    throw new ArgumentOutOfRangeException(nameof(selectionStrength), "SelectionStrength must be between 0 and 1.");
                }

				for (int i = 0; i < minIndicies.Length; i++)
                {
                    if (minIndicies[i] < 0 || maxIndiceis[i] < 0)
                    {
                        throw new ArgumentException("minIndicies and maxIndices must be greater than or equal to 0.");
                    }

                    if (minIndicies[i] > maxIndiceis[i])
                    {
                        throw new ArgumentException("minIndicies must be less than or equal to maxIndices.");
                    }
				}

				MinIndicies = minIndicies;
				MaxIndices = maxIndiceis;
				SelectionStrength = selectionStrength;
			}
		}

		private readonly List<SelectionVolume> selectionVolumes = new();

		public void AddVolume(int[] minIndices, int[] maxIndicies, float selectionStrength = 1.0f) {
			selectionVolumes.Add(new SelectionVolume(minIndices, maxIndicies, selectionStrength));
		}

		public override bool InitSelection(IHyperVolume<T> volume, float strengthThreshold = 0) {
            if (volume is null)
            {
                throw new ArgumentNullException(nameof(volume), "volume must not be null");
            }

            if (!base.InitSelection(volume, strengthThreshold))
            {
                return false;
            }

			foreach (SelectionVolume record in selectionVolumes)
            {
                if (record.MinIndicies.Length > volume.Rank || record.MaxIndices.Length > volume.Rank)
                {
                    throw new ArgumentOutOfRangeException("Selection indices must be within the bounds of the surface.");
                }
			}

			return true;
		}

		public override float SelectionStrength(IHyperVolume<T> volume, int flatIndex) {
			int[] expandedIndices = volume.Indices(flatIndex);

			float selectionStrength = 0.0f;

			foreach (SelectionVolume record in selectionVolumes)
            {
				for (int i = 0; i < record.MinIndicies.Length; ++i)
                {
                    if (expandedIndices[i] >= record.MinIndicies[i] && expandedIndices[i] <= record.MaxIndices[i])
                    {
                        selectionStrength = Math.Max(selectionStrength, record.SelectionStrength);
                    }
				}
			}

			return selectionStrength;
		}
	}
}
