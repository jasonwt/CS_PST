using System.ComponentModel;

namespace PST.HyperVolume {
    public struct ThreadingOptions {
        private int _requestedThreads = 0;
        private int _minElementsPerThread = 1;

        public int RequestedThreads {
			set {
				if (value < 0)
					throw new ArgumentOutOfRangeException("Requested threads must be a positive integer");

				_requestedThreads = value;
			}
		}

        public int MinElementsPerThread {
            set {
                if (value < 1)
					throw new ArgumentOutOfRangeException("Minimum elements per thread must be a positive integer >= 1");

				_minElementsPerThread = value;
            }
        }

        public ThreadingOptions() {
            _requestedThreads = 0;
            _minElementsPerThread = 1;
        }

        public ThreadingOptions(int requestedThreads = 0, int minElementsPerThread = 1) {
            if (requestedThreads < 0)
                throw new ArgumentOutOfRangeException("requestedThreads", "Requested threads must be a positive integer");

            if (minElementsPerThread < 1)
                throw new ArgumentOutOfRangeException("minElementsPerThread", "Minimum elements per thread must be a positive integer >= 1");

            _requestedThreads = Math.Min(requestedThreads, Environment.ProcessorCount - 1);
            _minElementsPerThread = minElementsPerThread;
        }

        public int ThreadsToUse(int numElements) {
            if (_minElementsPerThread == 0)
                return 0;

            return Math.Min(_requestedThreads, numElements / _minElementsPerThread);
        }
    }
}
