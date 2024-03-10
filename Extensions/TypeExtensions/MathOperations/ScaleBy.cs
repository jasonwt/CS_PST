using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PST.Extensions.TypeExtensions.MathOperations;

namespace PST.HyperVolume.Extensions.MathOperations
{
    static public partial class MathExtensions {

		static public T ScaleBy<T, U>(this T value, U factor) where T: IScalable<T, U> =>
			value.ScaleBy(factor);

		static public sbyte ScaleBy(this sbyte value, sbyte factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, byte factor) => (sbyte)((byte) value * factor);
		static public sbyte ScaleBy(this sbyte value, short factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, ushort factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, int factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, uint factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, long factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, ulong factor) => (sbyte)(value * (long) factor);
		static public sbyte ScaleBy(this sbyte value, float factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, double factor) => (sbyte)(value * factor);
		static public sbyte ScaleBy(this sbyte value, decimal factor) => (sbyte)(value * factor);

		static public byte ScaleBy(this byte value, sbyte factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, byte factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, short factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, ushort factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, int factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, uint factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, long factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, ulong factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, float factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, double factor) => (byte)(value * factor);
		static public byte ScaleBy(this byte value, decimal factor) => (byte)(value * factor);

		static public short ScaleBy(this short value, sbyte factor) => (short)(value * factor);
		static public short ScaleBy(this short value, byte factor) => (short)(value * factor);
		static public short ScaleBy(this short value, short factor) => (short)(value * factor);
		static public short ScaleBy(this short value, ushort factor) => (short)(value * factor);
		static public short ScaleBy(this short value, int factor) => (short)(value * factor);
		static public short ScaleBy(this short value, uint factor) => (short)(value * factor);
		static public short ScaleBy(this short value, long factor) => (short)(value * factor);
		static public short ScaleBy(this short value, ulong factor) => (short)(value * (long) factor);
		static public short ScaleBy(this short value, float factor) => (short)(value * factor);
		static public short ScaleBy(this short value, double factor) => (short)(value * factor);
		static public short ScaleBy(this short value, decimal factor) => (short)(value * factor);

		static public ushort ScaleBy(this ushort value, sbyte factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, byte factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, short factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, ushort factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, int factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, uint factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, long factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, ulong factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, float factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, double factor) => (ushort)(value * factor);
		static public ushort ScaleBy(this ushort value, decimal factor) => (ushort)(value * factor);

		static public int ScaleBy(this int value, sbyte factor) => value * factor;
		static public int ScaleBy(this int value, byte factor) => value * factor;
		static public int ScaleBy(this int value, short factor) => value * factor;
		static public int ScaleBy(this int value, ushort factor) => value * factor;
		static public int ScaleBy(this int value, int factor) => value * factor;
		static public int ScaleBy(this int value, uint factor) => (int) ((uint) value * factor);
		static public int ScaleBy(this int value, long factor) => (int)(value * factor);
		static public int ScaleBy(this int value, ulong factor) => (int)(value * (long) factor);
		static public int ScaleBy(this int value, float factor) => (int)(value * factor);
		static public int ScaleBy(this int value, double factor) => (int)(value * factor);
		static public int ScaleBy(this int value, decimal factor) => (int)(value * factor);

		static public uint ScaleBy(this uint value, sbyte factor) => (uint) (value * factor);
		static public uint ScaleBy(this uint value, byte factor) => value * factor;
		static public uint ScaleBy(this uint value, short factor) => (uint) (value * factor);
		static public uint ScaleBy(this uint value, ushort factor) => value * factor;
		static public uint ScaleBy(this uint value, int factor) => value * (uint)factor;
		static public uint ScaleBy(this uint value, uint factor) => value * factor;
		static public uint ScaleBy(this uint value, long factor) => (uint)(value * factor);
		static public uint ScaleBy(this uint value, ulong factor) => (uint)(value * factor);
		static public uint ScaleBy(this uint value, float factor) => (uint)(value * factor);
		static public uint ScaleBy(this uint value, double factor) => (uint)(value * factor);
		static public uint ScaleBy(this uint value, decimal factor) => (uint)(value * factor);

		static public long ScaleBy(this long value, sbyte factor) => value * factor;
		static public long ScaleBy(this long value, byte factor) => value * factor;
		static public long ScaleBy(this long value, short factor) => value * factor;
		static public long ScaleBy(this long value, ushort factor) => value * factor;
		static public long ScaleBy(this long value, int factor) => value * factor;
		static public long ScaleBy(this long value, uint factor) => value * factor;
		static public long ScaleBy(this long value, long factor) => value * factor;
		static public long ScaleBy(this long value, ulong factor) => (long)((ulong) value * factor);
		static public long ScaleBy(this long value, float factor) => (long)(value * factor);
		static public long ScaleBy(this long value, double factor) => (long)(value * factor);
		static public long ScaleBy(this long value, decimal factor) => (long)(value * factor);

		static public ulong ScaleBy(this ulong value, sbyte factor) => value * (ulong)factor;
		static public ulong ScaleBy(this ulong value, byte factor) => value * factor;
		static public ulong ScaleBy(this ulong value, short factor) => value * (ulong)factor;
		static public ulong ScaleBy(this ulong value, ushort factor) => value * factor;
		static public ulong ScaleBy(this ulong value, int factor) => value * (ulong)factor;
		static public ulong ScaleBy(this ulong value, uint factor) => value * factor;
		static public ulong ScaleBy(this ulong value, long factor) => value * (ulong)factor;
		static public ulong ScaleBy(this ulong value, ulong factor) => value * factor;
		static public ulong ScaleBy(this ulong value, float factor) => (ulong)(value * factor);
		static public ulong ScaleBy(this ulong value, double factor) => (ulong)(value * factor);
		static public ulong ScaleBy(this ulong value, decimal factor) => (ulong)(value * factor);

		static public float ScaleBy(this float value, sbyte factor) => value * factor;
		static public float ScaleBy(this float value, byte factor) => value * factor;
		static public float ScaleBy(this float value, short factor) => value * factor;
		static public float ScaleBy(this float value, ushort factor) => value * factor;
		static public float ScaleBy(this float value, int factor) => value * factor;
		static public float ScaleBy(this float value, uint factor) => value * factor;
		static public float ScaleBy(this float value, long factor) => value * factor;
		static public float ScaleBy(this float value, ulong factor) => value * factor;
		static public float ScaleBy(this float value, float factor) => value * factor;
		static public float ScaleBy(this float value, double factor) => (float)((double) value * factor);
		static public float ScaleBy(this float value, decimal factor) => (float)((decimal) value * factor);

		static public double ScaleBy(this double value, sbyte factor) => value * factor;
		static public double ScaleBy(this double value, byte factor) => value * factor;
		static public double ScaleBy(this double value, short factor) => value * factor;
		static public double ScaleBy(this double value, ushort factor) => value * factor;
		static public double ScaleBy(this double value, int factor) => value * factor;
		static public double ScaleBy(this double value, uint factor) => value * factor;
		static public double ScaleBy(this double value, long factor) => value * factor;
		static public double ScaleBy(this double value, ulong factor) => value * factor;
		static public double ScaleBy(this double value, float factor) => (double)(value * (double)factor);
		static public double ScaleBy(this double value, double factor) => value * factor;
		static public double ScaleBy(this double value, decimal factor) => (double)((decimal)value * factor);

		static public decimal ScaleBy(this decimal value, sbyte factor) => value * factor;
		static public decimal ScaleBy(this decimal value, byte factor) => value * factor;
		static public decimal ScaleBy(this decimal value, short factor) => value * factor;
		static public decimal ScaleBy(this decimal value, ushort factor) => value * factor;
		static public decimal ScaleBy(this decimal value, int factor) => value * factor;
		static public decimal ScaleBy(this decimal value, uint factor) => value * factor;
		static public decimal ScaleBy(this decimal value, long factor) => value * factor;
		static public decimal ScaleBy(this decimal value, ulong factor) => value * factor;
		static public decimal ScaleBy(this decimal value, decimal factor) => value * factor;
		static public decimal ScaleBy(this decimal value, float factor) => value * (decimal) factor;
		static public decimal ScaleBy(this decimal value, double factor) => value * (decimal)factor;
	}
}
