namespace PST.HyperVolume {
    using System.ComponentModel;

    public struct ThreadingOptions {
        private int requestedThreads = 0;
        private int minElementsPerThread = 1;

        public int RequestedThreads {
			set => requestedThreads = value >= 0 ? value : throw new ArgumentOutOfRangeException("Requested threads must be a positive integer");
		}

        public int MinElementsPerThread {
            set => requestedThreads = value > 0 ? value : throw new ArgumentOutOfRangeException("Minimum elements per thread must be a positive integer >= 1");
        }

        public ThreadingOptions() {
            requestedThreads = 0;
            minElementsPerThread = 1;
        }

        public ThreadingOptions(int requestedThreads = 0, int minElementsPerThread = 1) {
            this.requestedThreads = requestedThreads >= 0 ? requestedThreads :
                throw new ArgumentOutOfRangeException("Requested threads must be a positive integer");

            this.minElementsPerThread = minElementsPerThread > 0 ? minElementsPerThread :
                throw new ArgumentOutOfRangeException("Minimum elements per thread must be a positive integer >= 1");

            this.requestedThreads = Math.Min(this.requestedThreads, Environment.ProcessorCount - 1);
        }

        public int ThreadsToUse(int numElements) =>
            (minElementsPerThread == 0 ? 0 : Math.Min(requestedThreads, numElements / minElementsPerThread));
    }
}
