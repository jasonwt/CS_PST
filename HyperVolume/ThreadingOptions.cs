using System.ComponentModel;

namespace PST.HyperVolume {
    public struct ThreadingOptions {
        private int _requestedThreads = 0;
        private int _minElementsPerThread = 1;

        public int RequestedThreads {
			set => _requestedThreads = value >= 0 ? value : throw new ArgumentOutOfRangeException("Requested threads must be a positive integer");
		}

        public int MinElementsPerThread {
            set => _requestedThreads = value > 0 ? value : throw new ArgumentOutOfRangeException("Minimum elements per thread must be a positive integer >= 1");
        }

        public ThreadingOptions() {
            _requestedThreads = 0;
            _minElementsPerThread = 1;
        }

        public ThreadingOptions(int requestedThreads = 0, int minElementsPerThread = 1) {
            _requestedThreads = requestedThreads >= 0 ? requestedThreads :
                throw new ArgumentOutOfRangeException("Requested threads must be a positive integer");

            _minElementsPerThread = minElementsPerThread > 0 ? minElementsPerThread :
                throw new ArgumentOutOfRangeException("Minimum elements per thread must be a positive integer >= 1");

            _requestedThreads = Math.Min(_requestedThreads, Environment.ProcessorCount - 1);
        }

        public int ThreadsToUse(int numElements) =>
            (_minElementsPerThread == 0 ? 0 : Math.Min(_requestedThreads, numElements / _minElementsPerThread));
    }
}
