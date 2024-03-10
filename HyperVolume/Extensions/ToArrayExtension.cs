namespace PST.HyperVolume.Extensions {
	static public class ToArrayExtension {
		static public T[] ToArray<T>(
			this IHyperVolume<T> volume, 
			int? startingIndex = null, 
			int? endingIndex = null, 
			int? requestedThreads = null) {

			int area = volume.Area;

			int start = startingIndex ?? 0;
			int end = endingIndex ?? area;

            // REVIEW: You're repeating an implementation detail here that I've seen elsewhere. If you're going to use this pattern in multiple places, consider making it an `internal Lazy<int>` static property.
			int threads = Math.Min(requestedThreads ?? 0, Environment.ProcessorCount - 1);

			if (start < 0 || start >= area)
				throw new ArgumentOutOfRangeException(nameof(start), "Starting index must be greater than or equal to 0 and less than the area of the surface");

			if (end < 0 || end >= area)
				throw new ArgumentOutOfRangeException(nameof(end), "Ending index must be greater than or equal to 0 and less than the area of the surface");

			if (end <= start)
				throw new ArgumentException("Ending index must be greater than the starting index", nameof(end));

			if (threads < 0)
				throw new ArgumentException("Requested threads must be greater than or equal to 0", nameof(requestedThreads));

			int blockSize = end - start;
			T[] newArray = new T[blockSize];

            // REVIEW: Why is 100 the magic number here? Why not 25 or 50? What is the significance of 100?
			if (threads > 1 && blockSize > 100) {
                // REVIEW: unnecessary cast
				int threadBlockSize = area / (int)threads;

				if (threadBlockSize < 25) {
					threads = area / 25;
					threadBlockSize = 25;
				}

				Parallel.For(0, threads, i => {
					int localStart = start + (i * threadBlockSize);
					int localEnd = localStart + threadBlockSize;

					if (i == threads - 1)
						localEnd = end;

					for (int j = localStart; j < localEnd; j++)
						newArray[j - localStart] = volume[j];
				});
			} else {
                // REVIEW: why are you casting?
				for (int i = (int)start; i < end; i++)
					newArray[i - (int)start] = volume[i];
			}

			return newArray;
		}

		static public T[] ToArray<T>(this IHyperVolume<T> volume, int startingIndex, int endingIndex) =>
			ToArray(volume, startingIndex, endingIndex, 0);

		static public T[] ToArray<T>(this IHyperVolume<T> volume, int requestedThreads) =>
			ToArray(volume, 0, volume.Area, requestedThreads);

        // REVIEW: Remove async and await. This method is not doing any async work.
		static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int? startingIndex = null,
			int? endingIndex = null,
			int? requestedThreads = null) {

			return await Task.Run(() => ToArray(volume, startingIndex, endingIndex, requestedThreads));
		}

        // REVIEW: Remove async and await. This method is not doing any async work.
        // REVIEW: You should review whether these ToArrayAsync methods are really necessary. They don't seem to be adding much value... but maybe I'm missing something?
        static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int startingIndex,
			int endingIndex) {

			return await Task.Run(() => ToArray(volume, startingIndex, endingIndex, 0));
		}

        // REVIEW: Remove async and await. This method is not doing any async work.
        static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int requestedThreads) {

			return await Task.Run(() => ToArray(volume, 0, volume.Area, requestedThreads));
		}
	}
}
