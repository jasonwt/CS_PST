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

			if (threads > 1 && blockSize > 100) {
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
				for (int i = (int)start; i < end; i++)
					newArray[i - (int)start] = volume[i];
			}

			return newArray;
		}

		static public T[] ToArray<T>(this IHyperVolume<T> volume, int startingIndex, int endingIndex) =>
			ToArray(volume, startingIndex, endingIndex, 0);

		static public T[] ToArray<T>(this IHyperVolume<T> volume, int requestedThreads) =>
			ToArray(volume, 0, volume.Area, requestedThreads);

		static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int? startingIndex = null,
			int? endingIndex = null,
			int? requestedThreads = null) {

			return await Task.Run(() => ToArray(volume, startingIndex, endingIndex, requestedThreads));
		}

		static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int startingIndex,
			int endingIndex) {

			return await Task.Run(() => ToArray(volume, startingIndex, endingIndex, 0));
		}

		static public async Task<T[]> ToArrayAsync<T>(
			this IHyperVolume<T> volume,
			int requestedThreads) {

			return await Task.Run(() => ToArray(volume, 0, volume.Area, requestedThreads));
		}
	}
}
