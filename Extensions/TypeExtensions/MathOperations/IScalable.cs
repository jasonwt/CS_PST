using System;

namespace PST.Extensions.TypeExtensions.MathOperations {
    public interface IScalable<T, U> {
        T ScaleBy(U value);
    }
}
