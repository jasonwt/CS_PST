using System;

namespace PST.HyperVolume.Extentions.TypeExtensions.MathOperations
{
    public interface IScalable<T, U>
    {
        T ScaleBy(U value);
    }
}
