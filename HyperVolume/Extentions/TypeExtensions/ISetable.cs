namespace PST.HyperVolume.Extentions.TypeExtensions
{
    public interface ISetable<T, U>
    {
        T SetTo(U value);

    }
}
