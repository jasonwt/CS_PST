using System;

namespace PST.Extensions.MathOperations {
    public interface IOffsetable<T, U> {
        T OffsetBy(U value);
    }
}
