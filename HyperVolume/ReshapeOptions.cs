namespace PST.HyperVolume {
	public struct ReshapeOptions {
		public ThreadingOptions ThreadingOptions { get; set; } = new ThreadingOptions();

		public ReshapeOptions() {
			ThreadingOptions = new ThreadingOptions();
		}
	}
}
