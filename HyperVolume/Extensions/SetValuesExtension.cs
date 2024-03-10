using PST.HyperVolume.Selection;

namespace PST.HyperVolume.Extensions {
	static public class SetValuesExtension {
		static public void SetValues<T>(
			this IHyperVolume<T> volume, 
			Func<IHyperVolume<T>, int, T> computeValueFunc, 
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			volume.Foreach(
				(IHyperVolume<T> volume, int index) => volume[index] = computeValueFunc(volume, index), 
				selection, 
				threadingOptions
			);
		}

		static public void SetValues<T>(
			this IHyperVolume<T> volume, 
			T value,
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			volume.Foreach(
				(IHyperVolume<T> volume, int index) => volume[index] = value, 
				selection, 
				threadingOptions
			);
		}

		static public async Task SetValuesAsync<T>(
			this IHyperVolume<T> volume,
			Func<IHyperVolume<T>, int, T> computeValueFunc,
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			await volume.ForeachAsync(
				(IHyperVolume<T> volume, int index) => volume[index] = computeValueFunc(volume, index),
				selection,
				threadingOptions
			);
		}

		static public async Task SetValuesAsync<T>(
			this IHyperVolume<T> volume,
			T value,
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			await volume.ForeachAsync(
				(IHyperVolume<T> volume, int index) => volume[index] = value,
				selection,
				threadingOptions
			);
		}
	}
}
