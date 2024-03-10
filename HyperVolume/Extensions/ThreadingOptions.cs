
namespace PST.HyperVolume.Extensions {
	public class ThreadingOptions {
		private int _requestedThreads = 0;
		private int _minElementsPerThread = 1;

        // REVIEW: Why is this a class and not an immutable struct/record? This seems like something that should be an immutable value type, not something stored on the heap.
		public ThreadingOptions(int requestedThreads = 0, int minElementsPerThread = 1) {
			if (requestedThreads < 0)
				throw new ArgumentOutOfRangeException("requestedThreads", "Requested threads must be a positive integer");

			if (minElementsPerThread < 1)
				throw new ArgumentOutOfRangeException("minElementsPerThread", "Minimum elements per thread must be a positive integer");

            // REVIEW: This is code smell. Why are you limiting to one less than the number of processors? What if the caller wants to use all the processors?
            //         What if the interpolation function is not CPU-bound, but instead is I/O-bound or memory-bound?
			_requestedThreads = Math.Min(requestedThreads, Environment.ProcessorCount - 1);
			_minElementsPerThread = minElementsPerThread;
		}

        // REVIEW: Since there is no way to change the values of the fields, why not just compute this in the constructor and store it as a public auto get-only property?
		public int ThreadsToUse(int numElements) {
			return Math.Min(_requestedThreads, numElements / _minElementsPerThread);
		}
	}
}
