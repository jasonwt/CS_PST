using PST.HyperVolume;
using PST.HyperVolume.Implementations;
using PST.HyperVolume.Extentions;
using System.Diagnostics;
using System.Security.Cryptography;

static public class Program {
	public static void Main() {
		var sw = Stopwatch.StartNew();
		sw.Start();

		var testVolume = new ArrayHyperVolume<float>(2, 2);
		testVolume.TypeInterpolationMethod = (float a, float b, float t) => a + (b - a) * t;

		for (int y = 0; y < testVolume.Shape[1]; y++) {
			for (int x = 0; x < testVolume.Shape[0]; x++) {
				testVolume[x, y] = testVolume.Index(x, y);
			}
		}

		Console.WriteLine(testVolume);

		testVolume.Reshape(3, 3);
		Console.WriteLine("Reshaped Test Volume\n" + testVolume);

		/*
		  
		 
			incides scale for 2x2 to 3x3 is 1.0 (newShape.Length / oldShape.Length)
			elements scale for 2x2 to 3x3 is 0.5 (newShape[n].Length / oldShape[n].Length)
		 
			0.0 1.0
		    2.0 3.0

				4.0 5.0
				6.0 7.0
		 
			0.0 0.5 1.0
			1.0 1.5 2.0
			2.0 2.5 3.0

				2.0 2.5 3.0
				3.0 3.5 4.0
				4.0 4.5 5.0
			
					4.0 4.5 5.0
					5.0 5.5 6.0
					6.0 6.5 7.0
		  
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

