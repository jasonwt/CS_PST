namespace PST.HyperVolume.Implementations
{
    public class ArrayHyperVolume<T> : HyperVolume<T> {
        public override T[] Elements => (T[])base.Elements;

        public override T this[int index] {
            get {
                if (index > Elements.Length)
                    throw new IndexOutOfRangeException();

                return Elements[index];
            }

            set {
                if (index > Elements.Length)
                    throw new IndexOutOfRangeException();

                Elements[index] = value;
            }
        }

        protected override object InstantiateData(int[] shape, object? data = null) {
            if (shape is null)
                throw new ArgumentNullException("shape");

            int totalArrayLength = 1;

            foreach (var length in shape) {
                if (length <= 0)
                    throw new ArgumentOutOfRangeException(nameof(shape), "All lengths must be greater than 0.");

                totalArrayLength *= length;
            }

            if (data is null)
                return new T[totalArrayLength];

            if (data is not T[] dataArray)
                throw new ArgumentException("Data must be of type T[]", nameof(data));

            if (dataArray.Length != totalArrayLength)
                throw new ArgumentException("Data must have the same length as the product of the shape", nameof(data));

            return dataArray;
        }

        public ArrayHyperVolume(T[]? data, params int[] shape) : base(data, shape) { }

        public ArrayHyperVolume(params int[] shape) : base(shape) { }
/*
        public override ArrayHyperVolume<T> Clone(int requestedThreads = 0) {
            // TODO: This is a shallow copy, should we make a deep copy?
            T[] arrayDataCopy = new T[Elements.Length];
            Elements.CopyTo(arrayDataCopy, 0);

            var clone = new ArrayHyperVolume<T>(arrayDataCopy, Shape.ToArray()) {
                TypeInterpolationMethod = TypeInterpolationMethod
            };

            return clone;
        }
*/
    }
}
