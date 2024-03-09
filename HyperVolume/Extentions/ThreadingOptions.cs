using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST.HyperVolume.Extentions {
	public class ThreadingOptions {
		private int _requestedThreads = 0;
		private int _minElementsPerThread = 1;

		public ThreadingOptions(int requestedThreads = 0, int minElementsPerThread = 1) {
			if (requestedThreads < 0)
				throw new ArgumentOutOfRangeException("requestedThreads", "Requested threads must be a positive integer");

			if (minElementsPerThread < 1)
				throw new ArgumentOutOfRangeException("minElementsPerThread", "Minimum elements per thread must be a positive integer");

			_requestedThreads = Math.Min(requestedThreads, Environment.ProcessorCount - 1);
			_minElementsPerThread = minElementsPerThread;
		}

		public int ThreadsToUse(int numElements) {
			return Math.Min(_requestedThreads, numElements / _minElementsPerThread);
		}
	}
}
