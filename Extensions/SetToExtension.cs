using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST.Extensions {
	static public class SetToExtension {
		public static T SetTo<T, U>(this T value, U newValue) where T: ISetable<T, U> =>
			value.SetTo(newValue);

		public static sbyte SetTo(this sbyte value, sbyte newValue) => newValue;
		public static sbyte SetTo(this sbyte value, byte newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, short newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, ushort newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, int newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, uint newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, long newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, ulong newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, float newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, double newValue) => (sbyte) newValue;
		public static sbyte SetTo(this sbyte value, decimal newValue) => (sbyte) newValue;

		public static byte SetTo(this byte value, sbyte newValue) => (byte) newValue;
		public static byte SetTo(this byte value, byte newValue) => newValue;
		public static byte SetTo(this byte value, short newValue) => (byte) newValue;
		public static byte SetTo(this byte value, ushort newValue) => (byte) newValue;
		public static byte SetTo(this byte value, int newValue) => (byte) newValue;
		public static byte SetTo(this byte value, uint newValue) => (byte) newValue;
		public static byte SetTo(this byte value, long newValue) => (byte) newValue;
		public static byte SetTo(this byte value, ulong newValue) => (byte) newValue;
		public static byte SetTo(this byte value, float newValue) => (byte) newValue;
		public static byte SetTo(this byte value, double newValue) => (byte) newValue;
		public static byte SetTo(this byte value, decimal newValue) => (byte) newValue;

		public static short SetTo(this short value, sbyte newValue) => newValue;
		public static short SetTo(this short value, byte newValue) => newValue;
		public static short SetTo(this short value, short newValue) => newValue;
		public static short SetTo(this short value, ushort newValue) => (short) newValue;
		public static short SetTo(this short value, int newValue) => (short) newValue;
		public static short SetTo(this short value, uint newValue) => (short) newValue;
		public static short SetTo(this short value, long newValue) => (short) newValue;
		public static short SetTo(this short value, ulong newValue) => (short) newValue;
		public static short SetTo(this short value, float newValue) => (short) newValue;
		public static short SetTo(this short value, double newValue) => (short) newValue;
		public static short SetTo(this short value, decimal newValue) => (short) newValue;

		public static ushort SetTo(this ushort value, sbyte newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, byte newValue) => newValue;
		public static ushort SetTo(this ushort value, short newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, ushort newValue) => newValue;
		public static ushort SetTo(this ushort value, int newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, uint newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, long newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, ulong newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, float newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, double newValue) => (ushort) newValue;
		public static ushort SetTo(this ushort value, decimal newValue) => (ushort) newValue;

		public static int SetTo(this int value, sbyte newValue) => newValue;
		public static int SetTo(this int value, byte newValue) => newValue;
		public static int SetTo(this int value, short newValue) => newValue;
		public static int SetTo(this int value, ushort newValue) => newValue;
		public static int SetTo(this int value, int newValue) => newValue;
		public static int SetTo(this int value, uint newValue) => (int) newValue;
		public static int SetTo(this int value, long newValue) => (int) newValue;
		public static int SetTo(this int value, ulong newValue) => (int) newValue;
		public static int SetTo(this int value, float newValue) => (int) newValue;
		public static int SetTo(this int value, double newValue) => (int) newValue;
		public static int SetTo(this int value, decimal newValue) => (int) newValue;

		public static uint SetTo(this uint value, sbyte newValue) => (uint) newValue;
		public static uint SetTo(this uint value, byte newValue) => newValue;
		public static uint SetTo(this uint value, short newValue) => (uint) newValue;
		public static uint SetTo(this uint value, ushort newValue) => newValue;
		public static uint SetTo(this uint value, int newValue) => (uint) newValue;
		public static uint SetTo(this uint value, uint newValue) => newValue;
		public static uint SetTo(this uint value, long newValue) => (uint) newValue;
		public static uint SetTo(this uint value, ulong newValue) => (uint) newValue;
		public static uint SetTo(this uint value, float newValue) => (uint) newValue;
		public static uint SetTo(this uint value, double newValue) => (uint) newValue;
		public static uint SetTo(this uint value, decimal newValue) => (uint) newValue;

		public static long SetTo(this long value, sbyte newValue) => newValue;
		public static long SetTo(this long value, byte newValue) => newValue;
		public static long SetTo(this long value, short newValue) => newValue;
		public static long SetTo(this long value, ushort newValue) => newValue;
		public static long SetTo(this long value, int newValue) => newValue;
		public static long SetTo(this long value, uint newValue) => newValue;
		public static long SetTo(this long value, long newValue) => newValue;
		public static long SetTo(this long value, ulong newValue) => (long) newValue;
		public static long SetTo(this long value, float newValue) => (long) newValue;
		public static long SetTo(this long value, double newValue) => (long) newValue;
		public static long SetTo(this long value, decimal newValue) => (long) newValue;

		public static ulong SetTo(this ulong value, sbyte newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, byte newValue) => newValue;
		public static ulong SetTo(this ulong value, short newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, ushort newValue) => newValue;
		public static ulong SetTo(this ulong value, int newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, uint newValue) => newValue;
		public static ulong SetTo(this ulong value, long newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, ulong newValue) => newValue;
		public static ulong SetTo(this ulong value, float newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, double newValue) => (ulong) newValue;
		public static ulong SetTo(this ulong value, decimal newValue) => (ulong) newValue;

		public static float SetTo(this float value, sbyte newValue) => newValue;
		public static float SetTo(this float value, byte newValue) => newValue;
		public static float SetTo(this float value, short newValue) => newValue;
		public static float SetTo(this float value, ushort newValue) => newValue;
		public static float SetTo(this float value, int newValue) => newValue;
		public static float SetTo(this float value, uint newValue) => newValue;
		public static float SetTo(this float value, long newValue) => newValue;
		public static float SetTo(this float value, ulong newValue) => newValue;
		public static float SetTo(this float value, float newValue) => newValue;
		public static float SetTo(this float value, double newValue) => (float) newValue;
		public static float SetTo(this float value, decimal newValue) => (float) newValue;

		public static double SetTo(this double value, sbyte newValue) => newValue;
		public static double SetTo(this double value, byte newValue) => newValue;
		public static double SetTo(this double value, short newValue) => newValue;
		public static double SetTo(this double value, ushort newValue) => newValue;
		public static double SetTo(this double value, int newValue) => newValue;
		public static double SetTo(this double value, uint newValue) => newValue;
		public static double SetTo(this double value, long newValue) => newValue;
		public static double SetTo(this double value, ulong newValue) => newValue;
		public static double SetTo(this double value, float newValue) => newValue;
		public static double SetTo(this double value, double newValue) => newValue;
		public static double SetTo(this double value, decimal newValue) => (double) newValue;

		public static decimal SetTo(this decimal value, sbyte newValue) => newValue;
		public static decimal SetTo(this decimal value, byte newValue) => newValue;
		public static decimal SetTo(this decimal value, short newValue) => newValue;
		public static decimal SetTo(this decimal value, ushort newValue) => newValue;
		public static decimal SetTo(this decimal value, int newValue) => newValue;
		public static decimal SetTo(this decimal value, uint newValue) => newValue;
		public static decimal SetTo(this decimal value, long newValue) => newValue;
		public static decimal SetTo(this decimal value, ulong newValue) => newValue;
		public static decimal SetTo(this decimal value, float newValue) => (decimal) newValue;
		public static decimal SetTo(this decimal value, double newValue) => (decimal) newValue;
		public static decimal SetTo(this decimal value, decimal newValue) => newValue;
	}
}
