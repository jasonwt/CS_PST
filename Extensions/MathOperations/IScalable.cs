using System;

namespace PST.Extensions.MathOperations {
    public interface IScalable<T, U> {
        T ScaleBy(U value);
    }
}
