using PST.Types;
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

		static public void SetValues<T, U>(
			this IHyperVolume<T> volume,
			U value,
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			if (value is null)
				throw new ArgumentNullException(nameof(value));

			object assignmentValue = default(T) ?? throw new Exception();

            // REVIEW: Exception handling?
			volume.Foreach(
				(IHyperVolume<T> volume, int index) => {
                    // REVIEW: What if AssignTo returns false?
					Assignment.AssignTo(value, ref assignmentValue);
					volume[index] = (T) assignmentValue;
				},
				selection,
				threadingOptions
			);
		}

        // REVIEW: async methods that don't do anything but call another async method should not be async. Just return the result of the other async method.
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

        // REVIEW: async methods that don't do anything but call another async method should not be async. Just return the result of the other async method.
        static public async Task SetValuesAsync<T, U>(
			this IHyperVolume<T> volume,
			U value,
			ISelection<T>? selection = null,
			ThreadingOptions? threadingOptions = null) {

			if (value is null)
				throw new ArgumentNullException(nameof(value));

            // REVIEW: This will always throw for reference types.
            // REVIEW: Why are you using `object` here? It's guaranteed to be `T`.
			object assignmentValue = default(T) ?? throw new Exception();

			await volume.ForeachAsync(
				(IHyperVolume<T> volume, int index) => {
					Assignment.AssignTo(value, ref assignmentValue);
                    // REVIEW: You're mutating something in parallel. What if someone calls SetValuesAsync in parallel on the same volume?
					volume[index] = (T)assignmentValue;
				},
				selection,
				threadingOptions
			);
		}
	}
}
