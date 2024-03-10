
namespace PST.Types {
	public static class DeepCopy {
		public static object? DeepCopyStruct(object source, Type? structType, object?[]? args = null) {
            if (structType is null)
            {
                return null;
            }

            if (!structType.IsValueType)
            {
                throw new ArgumentException("Type is not a struct.", nameof(structType));
            }

			object? newStruct = Activator.CreateInstance(structType);

            if (newStruct is null)
            {
                throw new ArgumentNullException(nameof(newStruct));
            }

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
            {
                throw new ArgumentNullException(nameof(source));
            }

			Type type = source.GetType();

            return type switch
            {
                _ when type.IsArray => FromArray((Array)source, args),
                _ when type.IsEnum => Enum.ToObject(type, args),
                _ when type.IsClass => FromClass((object)source, args),
                //_ when type.IsValueType => FromStruct(source, args),
                _ => throw new ArgumentException("Type is not an array, enum, class, or struct.", nameof(type)),
            };
		}
	}
}
