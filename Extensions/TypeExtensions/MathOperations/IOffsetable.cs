using System;

namespace PST.Extensions.TypeExtensions.MathOperations {
    public interface IOffsetable<T, U> {
        T OffsetBy(U value);
    }
}
