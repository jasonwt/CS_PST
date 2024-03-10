namespace PST.HyperVolume.Extensions {
	static public class CloningExtension {
        // REVIEW: this should be implemented by the type to avoid reflection as a Copy contructor or a Clone method.
        //         For base types, that would be a non-virtual Clone method, with a protected virtual OnClone (or similar name)
        //         method that derived types can override to copy their own state.
        static public IHyperVolume<T> Clone<T>(this IHyperVolume<T> instance, ThreadingOptions? threadingOptions = null) {
			if (instance is null)
                // REVIEW: use nameof instead of hardcoding the parameter name
                // REVIEW: In .NET 8+, use ArgumentNullException.ThrowIfNull(instance)
                // REVIEW: This is only needed at all when this is used as a library with callers that don't support nullable reference types.
				throw new ArgumentNullException("instance", "Instance cannot be null");

			Type instanceType = instance.GetType();
			Type tType = typeof(T);
			bool tIsValueType = tType.IsValueType;

			int instanceArea = instance.Area;
			int[] instanceShape = instance.Shape.ToArray();

            // REVIEW: Wrong type, since you are guaranteeing that it's not null. Should be IHyperVolume<T> instead of IHyperVolume<T>?
			IHyperVolume<T>? newVolume = (IHyperVolume<T>?)Activator.CreateInstance(instanceType, instanceShape) ??
				throw new InvalidOperationException("Failed to create new instance of IHyperVolume");

			newVolume.TypeInterpolationMethod = instance.TypeInterpolationMethod;

			newVolume.Foreach((volume, index) => {
				T thisValue = instance[index];

				if (tIsValueType)
					volume[index] = thisValue;
				else
					// TODO: Finish PST.Instantiation.DeepCopy
					throw new NotImplementedException("Cloning of non-value types is not yet implemented");

			}, null, threadingOptions);

			return newVolume;
		}

        // REVIEW: Does not need to be async, since it's not doing any async work. Remove `async` and `await`.
        // REVIEW: The CloneAsync method does not seem to be adding much value. Why have it? Callers could easily call Clone and wrap it in a Task.Run if they need it to be async.
		static public async Task<IHyperVolume<T>> CloneAsync<T>(this IHyperVolume<T> instance, ThreadingOptions? threadingOptions = null) =>
			await Task.Run(() => Clone(instance, threadingOptions));
	}
}
