

namespace PST.HyperVolume.Selection {
	public interface ISelection<T> {
        // REVIEW: Consider using a `Func<T, bool>` instead of SelectionThreshold and SelectionStrength, unless you need to expose the threshold and strength for other purposes.
		float SelectionThreshold { get; set; }
		bool InitSelection(IHyperVolume<T> volume, float strengthThreshold = 0);
		float SelectionStrength(IHyperVolume<T> volume, int index);
	}
}
