using PST.Types;
using PST.HyperVolume.Selection;

namespace PST.HyperVolume.Extensions
{
    static public class SetValuesExtension {
		static public void SetValues<T>(
			this IHyperVolume<T> volume, 
			Func<IHyperVolume<T>, int, T> computeValueFunc, 
			ISelection<T>? selection = null,
			ThreadingOptions threadingOptions = default) {

			volume.Foreach(
				(IHyperVolume<T> volume, int index) => volume[index] = computeValueFunc(volume, index), 
				selection, 
				threadingOptions
			);
		}

		static public void SetValues<T, U>(
			this IHyperVolume<T> volume,
			U value,
			ISelection<T>? selection = null,
			ThreadingOptions threadingOptions = default) {

			if (value is null)
				throw new ArgumentNullException(nameof(value));

			object assignmentValue = default(T) ?? throw new Exception();

			volume.Foreach(
				(IHyperVolume<T> volume, int index) => {
					Assignment.AssignTo(value, ref assignmentValue);
					volume[index] = (T) assignmentValue;
				},
				selection,
				threadingOptions
			);
		}

		static public async Task SetValuesAsync<T>(
			this IHyperVolume<T> volume,
			Func<IHyperVolume<T>, int, T> computeValueFunc,
			ISelection<T>? selection = null,
			ThreadingOptions threadingOptions = default) {

			await volume.ForeachAsync(
				(IHyperVolume<T> volume, int index) => volume[index] = computeValueFunc(volume, index),
				selection,
				threadingOptions
			);
		}

		static public async Task SetValuesAsync<T, U>(
			this IHyperVolume<T> volume,
			U value,
			ISelection<T>? selection = null,
			ThreadingOptions threadingOptions = default) {

			if (value is null)
				throw new ArgumentNullException(nameof(value));

			object assignmentValue = default(T) ?? throw new Exception();

			await volume.ForeachAsync(
				(IHyperVolume<T> volume, int index) => {
					Assignment.AssignTo(value, ref assignmentValue);
					volume[index] = (T)assignmentValue;
				},
				selection,
				threadingOptions
			);
		}
	}
}
