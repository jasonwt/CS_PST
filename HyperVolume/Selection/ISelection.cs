
namespace PST.HyperVolume.Selection {
	public interface ISelection<T> {
		float SelectionThreshold { get; set; }
		bool InitSelection(IHyperVolume<T> volume, float strengthThreshold = 0);
		float SelectionStrength(IHyperVolume<T> volume, int index);
	}
}
