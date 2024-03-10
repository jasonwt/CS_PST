
namespace PST.Types {
	public static class DeepCopy {
		public static object? DeepCopyStruct(object source, Type? structType, object?[]? args = null) {
			if (structType is null)
				return null;

			if (!structType.IsValueType)
				throw new ArgumentException("Type is not a struct.", nameof(structType));

			var newStruct = Activator.CreateInstance(structType);

			if (newStruct is null)
				throw new ArgumentNullException(nameof(newStruct));

			return newStruct;
		}

		public static T FromClass<T>(T source, params object?[] args) where T : class {
			throw new NotImplementedException();
		}
		public static T FromStruct<T>(T source, params object?[] args) where T : struct {
			throw new NotImplementedException();
		}

		public static Array FromArray(Array source, params object?[] args) {
			throw new NotImplementedException();
		}

		public static object From(object source, params object?[] args) {
			if (source is null)
				throw new ArgumentNullException(nameof(source));

			Type type = source.GetType();

			if (type.IsArray)
				return FromArray((Array)source, args);

			if (type.IsEnum)
				return Enum.ToObject(type, args);

			if (type.IsClass)
				return FromClass((object)source, args);

			//			if (type.IsValueType)
			//			return FromStruct(source, args);

			throw new ArgumentException("Type is not an array, enum, class, or struct.", nameof(type));
		}
	}
}
