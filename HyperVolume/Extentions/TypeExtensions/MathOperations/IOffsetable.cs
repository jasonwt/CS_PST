using System;

namespace PST.HyperVolume.Extentions.TypeExtensions.MathOperations
{
    public interface IOffsetable<T, U>
    {
        T OffsetBy(U value);
    }
}
