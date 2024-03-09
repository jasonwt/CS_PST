using PST.Extensions.MathOperations;

namespace PST.HyperVolume.Extentions
{
    static public partial class MathExtensions {
		static public T OffsetBy<T, U>(this T value, U offset) where T : IOffsetable<T, U> =>
			value.OffsetBy(offset);

		static public sbyte OffsetBy(this sbyte value, sbyte offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, byte offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, short offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, ushort offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, int offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, uint offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, long offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, ulong offset) => (sbyte)(value + (long) offset);
		static public sbyte OffsetBy(this sbyte value, float offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, double offset) => (sbyte)(value + offset);
		static public sbyte OffsetBy(this sbyte value, decimal offset) => (sbyte)(value + offset);

		static public byte OffsetBy(this byte value, sbyte offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, byte offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, short offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, ushort offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, int offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, uint offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, long offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, ulong offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, float offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, double offset) => (byte)(value + offset);
		static public byte OffsetBy(this byte value, decimal offset) => (byte)(value + offset);

		static public short OffsetBy(this short value, sbyte offset) => (short)(value + offset);
		static public short OffsetBy(this short value, byte offset) => (short)(value + offset);
		static public short OffsetBy(this short value, short offset) => (short)(value + offset);
		static public short OffsetBy(this short value, ushort offset) => (short)(value + offset);
		static public short OffsetBy(this short value, int offset) => (short)(value + offset);
		static public short OffsetBy(this short value, uint offset) => (short)(value + offset);
		static public short OffsetBy(this short value, long offset) => (short)(value + offset);
		static public short OffsetBy(this short value, ulong offset) => (short)(value + (long) offset);
		static public short OffsetBy(this short value, float offset) => (short)(value + offset);
		static public short OffsetBy(this short value, double offset) => (short)(value + offset);
		static public short OffsetBy(this short value, decimal offset) => (short)(value + offset);

		static public ushort OffsetBy(this ushort value, sbyte offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, byte offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, short offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, ushort offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, int offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, uint offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, long offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, ulong offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, float offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, double offset) => (ushort)(value + offset);
		static public ushort OffsetBy(this ushort value, decimal offset) => (ushort)(value + offset);

		static public int OffsetBy(this int value, sbyte offset) => value + offset;
		static public int OffsetBy(this int value, byte offset) => value + offset;
		static public int OffsetBy(this int value, short offset) => value + offset;
		static public int OffsetBy(this int value, ushort offset) => value + offset;
		static public int OffsetBy(this int value, int offset) => value + offset;
		static public int OffsetBy(this int value, uint offset) => (int)(value + offset);
		static public int OffsetBy(this int value, long offset) => (int)(value + offset);
		static public int OffsetBy(this int value, ulong offset) => (int)(value + (long) offset);
		static public int OffsetBy(this int value, float offset) => (int)(value + offset);
		static public int OffsetBy(this int value, double offset) => (int)(value + offset);
		static public int OffsetBy(this int value, decimal offset) => (int)(value + offset);

		static public uint OffsetBy(this uint value, sbyte offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, byte offset) => value + offset;
		static public uint OffsetBy(this uint value, short offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, ushort offset) => value + offset;
		static public uint OffsetBy(this uint value, int offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, uint offset) => value + offset;
		static public uint OffsetBy(this uint value, long offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, ulong offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, float offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, double offset) => (uint)(value + offset);
		static public uint OffsetBy(this uint value, decimal offset) => (uint)(value + offset);

		static public long OffsetBy(this long value, sbyte offset) => value + offset;
		static public long OffsetBy(this long value, byte offset) => value + offset;
		static public long OffsetBy(this long value, short offset) => value + offset;
		static public long OffsetBy(this long value, ushort offset) => value + offset;
		static public long OffsetBy(this long value, int offset) => value + offset;
		static public long OffsetBy(this long value, uint offset) => value + offset;
		static public long OffsetBy(this long value, long offset) => value + offset;
		static public long OffsetBy(this long value, ulong offset) => (long)(value + (long) offset);
		static public long OffsetBy(this long value, float offset) => (long)(value + offset);
		static public long OffsetBy(this long value, double offset) => (long)(value + offset);
		static public long OffsetBy(this long value, decimal offset) => (long)(value + offset);

		static public ulong OffsetBy(this ulong value, sbyte offset) => value + (ulong) offset;
		static public ulong OffsetBy(this ulong value, byte offset) => value + offset;
		static public ulong OffsetBy(this ulong value, short offset) => value + (ulong) offset;
		static public ulong OffsetBy(this ulong value, ushort offset) => value + offset;
		static public ulong OffsetBy(this ulong value, int offset) => value + (ulong) offset;
		static public ulong OffsetBy(this ulong value, uint offset) => value + offset;
		static public ulong OffsetBy(this ulong value, long offset) => value + (ulong) offset;
		static public ulong OffsetBy(this ulong value, ulong offset) => value + offset;
		static public ulong OffsetBy(this ulong value, float offset) => (ulong)(value + offset);
		static public ulong OffsetBy(this ulong value, double offset) => (ulong)(value + offset);
		static public ulong OffsetBy(this ulong value, decimal offset) => (ulong)(value + offset);

		static public float OffsetBy(this float value, sbyte offset) => value + offset;
		static public float OffsetBy(this float value, byte offset) => value + offset;
		static public float OffsetBy(this float value, short offset) => value + offset;
		static public float OffsetBy(this float value, ushort offset) => value + offset;
		static public float OffsetBy(this float value, int offset) => value + offset;
		static public float OffsetBy(this float value, uint offset) => value + offset;
		static public float OffsetBy(this float value, long offset) => value + offset;
		static public float OffsetBy(this float value, ulong offset) => value + offset;
		static public float OffsetBy(this float value, float offset) => value + offset;
		static public float OffsetBy(this float value, double offset) => (float) ((double) value + offset);
		static public float OffsetBy(this float value, decimal offset) => (float)(value + (float) offset);

		static public double OffsetBy(this double value, sbyte offset) => value + offset;
		static public double OffsetBy(this double value, byte offset) => value + offset;
		static public double OffsetBy(this double value, short offset) => value + offset;
		static public double OffsetBy(this double value, ushort offset) => value + offset;
		static public double OffsetBy(this double value, int offset) => value + offset;
		static public double OffsetBy(this double value, uint offset) => value + offset;
		static public double OffsetBy(this double value, long offset) => value + offset;
		static public double OffsetBy(this double value, ulong offset) => value + offset;
		static public double OffsetBy(this double value, float offset) => value + offset;
		static public double OffsetBy(this double value, double offset) => value + offset;
		static public double OffsetBy(this double value, decimal offset) => (double)(value + (double) offset);
		
		static public decimal OffsetBy(this decimal value, sbyte offset) => value + offset;
		static public decimal OffsetBy(this decimal value, byte offset) => value + offset;
		static public decimal OffsetBy(this decimal value, short offset) => value + offset;
		static public decimal OffsetBy(this decimal value, ushort offset) => value + offset;
		static public decimal OffsetBy(this decimal value, int offset) => value + offset;
		static public decimal OffsetBy(this decimal value, uint offset) => value + offset;
		static public decimal OffsetBy(this decimal value, long offset) => value + offset;
		static public decimal OffsetBy(this decimal value, ulong offset) => value + offset;
		static public decimal OffsetBy(this decimal value, float offset) => value + (decimal) offset;
		static public decimal OffsetBy(this decimal value, double offset) => value + (decimal) offset;
		static public decimal OffsetBy(this decimal value, decimal offset) => value + offset;
	}
}
