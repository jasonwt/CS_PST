﻿namespace PST.HyperVolume.Selection {

    using System;

    public abstract class Selection<T> : ISelection<T> {
		private float _strengthThreshold = 0;

		public float SelectionThreshold {
			get => _strengthThreshold;
			set {
                if (value is < 0 or > 1)
                {
                    throw new ArgumentOutOfRangeException("strengthThreshold", "Strength threshold must be null or a value between 0 and 1");
                }

				_strengthThreshold = value;
			}
		}
		public virtual bool InitSelection(IHyperVolume<T> volume, float strengthThreshold = 0) {
			SelectionThreshold = strengthThreshold;

			return true;
		}

		public abstract float SelectionStrength(IHyperVolume<T> volume, int index);
	}
}
