using PST.HyperVolume.Extensions;
using PST.HyperVolume.Implementations;
using System.Diagnostics;

static public class Program {
	public static void Main() {
		var sw = Stopwatch.StartNew();
		sw.Start();

		var testVolume = new ArrayHyperVolume<float>(2,2);
		testVolume.TypeInterpolationMethod = (float a, float b, float t) => a + (b - a) * t;

		int volumeArea = testVolume.Area;

		for (int i = 0; i < volumeArea; i++) {
			int[] indicies = testVolume.Indices(i);

			testVolume[indicies] = (i+1);
		}

		testVolume.SetValues((sbyte) 1);
		testVolume.SetValues((byte)1);
		testVolume.SetValues((short)1);
		testVolume.SetValues((ushort)1);
		testVolume.SetValues((int)1);
		testVolume.SetValues((uint)1);
		testVolume.SetValues((long)1);
		testVolume.SetValues((ulong)1);
		testVolume.SetValues((float)1);
		testVolume.SetValues((double)1);
		testVolume.SetValues((decimal)1);



		Console.WriteLine(testVolume);

		testVolume.Reshape(3);
		Console.WriteLine("Reshaped Test Volume\n" + testVolume);

		/*
		  
		 
			incides scale for 2x2 to 3x3 is 1.0 (newShape.Length / oldShape.Length)
			elements scale for 2x2 to 3x3 is 0.5 (newShape[n].Length / oldShape[n].Length)
		 
			0.0 1.0
			2.0 3.0

			

		  
		 */

		/*
				var testVolume = new ArrayHyperVolume<float>(3, 3, 3);
				testVolume.TypeInterpolationMethod = (float a, float b, float t) => a + (b - a) * t;
				testVolume.SetValues((IHyperVolume<float> volume, int index) => index * 1.5f);
				Console.WriteLine("Test Volume\n" + testVolume);

				var clonedVolume = testVolume.Clone();
				clonedVolume.SetValues(2.5f);
				Console.WriteLine("Cloned Volume\n" + clonedVolume);

				testVolume.Reshape(3, 3, 3);
				Console.WriteLine("Reshaped Test Volume\n" + testVolume);
		*/
		sw.Stop();
		Console.WriteLine(sw.ElapsedTicks);

		Console.ReadKey();
	}
}

