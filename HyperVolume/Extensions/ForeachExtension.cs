namespace PST.HyperVolume.Extensions
{
    using PST.HyperVolume.Selection;

    static public class ForeachExtension {
		static public void Foreach<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ISelection<T>? selection = null, ThreadingOptions threadingOptions = default) {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

			int volumeArea = volume.Area;
			int threadsToUse = threadingOptions.ThreadsToUse(volumeArea);

			if (threadsToUse <= 1)
            {
				for (int i = 0; i < volumeArea; i++)
                {
					// TODO: May not be as efficent as two sections of code depending on if selection is null or not
					float selectionStrength = selection?.SelectionStrength(volume, i) ?? 0;
					float selectionThreshold = selection?.SelectionThreshold ?? 0;

                    if (selectionStrength >= selectionThreshold)
                    {
                        action(volume, i);
                    }
				}
			}
            else
            {
				int threadBlockSize = volumeArea / threadsToUse;

				Parallel.For(0, threadsToUse, i => {
					int localStart = i * threadBlockSize;
					int localEnd = (i == threadsToUse - 1) ? volumeArea : localStart + threadBlockSize;

					for (int j = localStart; j < localEnd; j++)
                    {
						float selectionStrength = selection?.SelectionStrength(volume, j) ?? 0;
						float selectionThreshold = selection?.SelectionThreshold ?? 0;

                        if (selectionStrength >= selectionThreshold)
                        {
                            action(volume, j);
                        }
					}
				});
			}
		}

		static public void Foreach<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ISelection<T> selection) =>
			Foreach(volume, action, selection, new ThreadingOptions());

		static public void Foreach<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ThreadingOptions threadingOptions) =>
			Foreach(volume, action, null, threadingOptions);

		/********************************************* ASYNC METHODS *********************************************/
/*
		static public async Task ForeachAsync<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ISelection<T>? selection = null, ThreadingOptions threadingOptions = default) =>
			await Task.Run(() => Foreach<T>(volume, action, selection, threadingOptions));

		static public async Task ForeachAsync<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ISelection<T> selection) =>
			await Task.Run(() => Foreach<T>(volume, action, selection, new ThreadingOptions()));		

		static public async Task ForeachAsync<T>(this IHyperVolume<T> volume, Action<IHyperVolume<T>, int> action, ThreadingOptions threadingOptions) =>
			await Task.Run(() => Foreach<T>(volume, action, null, threadingOptions));
*/
	}
}
