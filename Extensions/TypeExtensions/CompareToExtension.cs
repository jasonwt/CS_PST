using System;

namespace PST.Extensions.TypeExtensions
{
    static public class CompareToExtension
    {
        static public int CompareTo<T, U>(this T a, U b) where T : IComparable<U>
            => a.CompareTo(b);

        static public int CompareTo(this sbyte a, sbyte b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this byte a, byte b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this short a, short b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this ushort a, ushort b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this int a, int b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this uint a, uint b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this long a, long b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this ulong a, ulong b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this float a, float b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this double a, double b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this decimal a, decimal b) => a < b ? -1 : a > b ? 1 : 0;
        static public int CompareTo(this bool a, bool b) => a == b ? 0 : a ? 1 : -1;
        static public int CompareTo(this char a, char b) => a < b ? -1 : a > b ? 1 : 0;
    }
}
