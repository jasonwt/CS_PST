namespace PST.Extensions.TypeExtensions {
    public interface ISetable<T, U> {
        T SetTo(U value);
    }
}
