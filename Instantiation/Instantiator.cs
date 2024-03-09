using System.IO;
using System.Reflection;

namespace PST.Instantiation {
	public static class Instantiator {
		public static Array? InstantiateArrayFromType(Type? elementsType, int[]? lengths) {
			if (elementsType is null) {
				if (lengths is not null)
					throw new ArgumentNullException(nameof(elementsType), "Elements type is null, but lengths is not null.");

				return null;
			}

			if (lengths is null || lengths.Length == 0)
				throw new ArgumentException("lengths must have at least one element.");

			if (lengths.Any(x => x < 0))
				throw new ArgumentOutOfRangeException(nameof(lengths), "Array length cannot be negative.");

			var array = Array.CreateInstance(elementsType, lengths);

			return array;
		}

		public static Enum? InstantiateEnumFromType(Type? enumType, int? selectedValue = null) {
			if (enumType is null)
				return null;

			if (!enumType.IsEnum)
				throw new ArgumentException("Type is not an enum.", nameof(enumType));

			var enumValues = Enum.GetValues(enumType);

			if (enumValues is null)
				throw new ArgumentNullException(nameof(enumValues), "Enum values are null.");

			if (enumValues.Length == 0)
				throw new ArgumentException("Enum has no values.", nameof(enumValues));

			selectedValue ??= enumValues.GetValue(0) as int?;

			if (selectedValue is null)
				throw new ArgumentNullException(nameof(selectedValue), "Selected value is null.");

			return (Enum)Enum.ToObject(enumType, selectedValue);
		}

		public static object? InstantiateClassFromType(Type? classType, object?[]? args = null) {
			if (classType is null)
				return null;

			if (!classType.IsClass)
				throw new ArgumentException("Type is not a class.", nameof(classType));

			if (args is not null) {
				// create new class from type with args
				var newClass = Activator.CreateInstance(classType, args);

				if (newClass is not null)
					return newClass;

			} else {
				var constructors =
					classType
					.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
					.OrderBy(x => x.GetParameters().Length);

				foreach (var constructor in constructors) {
					try {
						var parameters = constructor.GetParameters();
						object? newInstance = null;

						if (parameters.Length == 0) {
							newInstance = constructor.Invoke(null);

						} else {
							object?[] constructArgs = new object?[parameters.Length];

							foreach (var param in parameters)
								constructArgs[param.Position] = InstantiateFromType(param.ParameterType);

							newInstance = constructor.Invoke(constructArgs);
						}

						if (newInstance is not null)
							return newInstance;

					} catch {
					}
				}
			}

			throw new ArgumentException("Can not auto construct class.", nameof(classType));
		}

		public static object? InstantiateStructFromType(Type? structType, object?[]? args = null) {
			if (structType is null)
				return null;

			if (!structType.IsValueType)
				throw new ArgumentException("Type is not a struct.", nameof(structType));

			var newStruct = Activator.CreateInstance(structType);

			if (newStruct is null)
				throw new ArgumentNullException(nameof(newStruct));

			return newStruct;
		}

		public static object? InstantiateFromType(Type? type, params object?[]? args) {
			if (type is null)
				return null;

			if (type.IsArray) {
				if (args is null || args.Length == 0)
					throw new ArgumentException("args must have at least one element.");

				int[] lengths = new int[args.Length];

				for (int i = 0; i < args.Length; i++) {
					if (args[i] is not int)
						throw new ArgumentException("args must be of type int.");

					lengths[i] = Convert.ToInt32(args[i]);
				}

				return InstantiateArrayFromType(type.GetElementType(), lengths);
			}

			if (type.IsEnum) {
				if (args is not null && args.Length > 1)
					throw new ArgumentException("args must have at most one element.");

				int? value = (int?)(args?[0] ?? null);

				return InstantiateEnumFromType(type, value);
			}

			if (type.IsClass) {
				if (args is null || args.Length == 0)
					return InstantiateClassFromType(type);

				return InstantiateClassFromType(type, args);

			}

			if (type.IsValueType) {
				if (args is not null && args.Length > 0)
					throw new ArgumentException("args must have at most zero elements.");

				return InstantiateStructFromType(type);
			}

			throw new ArgumentException("Type is not an array, enum, class, or struct.", nameof(type));
		}
	}
}
