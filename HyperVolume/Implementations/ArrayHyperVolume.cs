namespace PST.HyperVolume.Implementations
{
    public class ArrayHyperVolume<T> : HyperVolume<T> {
        public override T[] Elements => (T[])base.Elements;

        public override T this[int index] {
            get {
                if (index > Elements.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return Elements[index];
            }

            set {
                if (index > Elements.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Elements[index] = value;
            }
        }

        protected override object InstantiateData(int[] shape, object? data = null) {
            if (shape is null || shape.Length == 0)
            {
                throw new ArgumentException("shape must not be null and have at least one dimension");
            }

            int totalArrayLength = 1;

            foreach (int length in shape) 
            {
                if (length <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(shape), "All lengths must be greater than 0.");
                }

                totalArrayLength *= length;
            }

            if (data is null)
            {
                return new T[totalArrayLength];
            }

            if (data is not T[] dataArray)
            {
                throw new ArgumentException("Data must be of type T[]", nameof(data));
            }

            if (dataArray.Length != totalArrayLength)
            {
                throw new ArgumentException("Data must have the same length as the product of the shape", nameof(data));
            }

            return dataArray;
        }

        public ArrayHyperVolume(T[]? data, params int[] shape) : base(data, shape) { }

        public ArrayHyperVolume(params int[] shape) : base(shape) { }
    }
}
