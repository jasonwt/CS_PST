
namespace PST.Types {
    using System.Reflection;

    public static class Instantiation {
		public static Array? InstantiateArray(Type? elementsType, int[]? lengths) {
			if (elementsType is null)
            {
                return lengths is null ? null : throw new ArgumentNullException(nameof(elementsType), "Elements type is null, but lengths is not null.");
			}

            if (lengths is null || lengths.Length == 0)
            {
                throw new ArgumentException("lengths must have at least one element.");
            }

            if (lengths.Any(x => x < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(lengths), "Array length cannot be negative.");
            }

			var array = Array.CreateInstance(elementsType, lengths);

			return array;
		}

		public static Enum? InstantiateEnum(Type? enumType, int? selectedValue = null) {
            if (enumType is null)
            {
                return null;
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type is not an enum.", nameof(enumType));
            }

			Array? enumValues = Enum.GetValues(enumType);

            if (enumValues is null)
            {
                throw new ArgumentNullException(nameof(enumValues), "Enum values are null.");
            }

            if (enumValues.Length == 0)
            {
                throw new ArgumentException("Enum has no values.", nameof(enumValues));
            }

			selectedValue ??= enumValues.GetValue(0) as int?;

            if (selectedValue is null)
            {
                throw new ArgumentNullException(nameof(selectedValue), "Selected value is null.");
            }

			return (Enum)Enum.ToObject(enumType, selectedValue);
		}

		public static object? InstantiateClass(Type? classType, object?[]? args = null) {
            if (classType is null)
            {
                return null;
            }

            if (!classType.IsClass)
            {
                throw new ArgumentException("Type is not a class.", nameof(classType));
            }

			if (args is not null) 
            {
				// create new class from type with args
				object? newClass = Activator.CreateInstance(classType, args);

                if (newClass is not null)
                {
                    return newClass;
                }
			}
            else
            {
                IOrderedEnumerable<ConstructorInfo> constructors =
					classType
					.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
					.OrderBy(x => x.GetParameters().Length);

				foreach (ConstructorInfo constructor in constructors)
                {
					try
                    {
                        ParameterInfo[] parameters = constructor.GetParameters();
						object? newInstance = null;

						if (parameters.Length == 0)
                        {
							newInstance = constructor.Invoke(null);

						}
                        else
                        {
							object?[] constructArgs = new object?[parameters.Length];

                            foreach (ParameterInfo param in parameters)
                            {
                                constructArgs[param.Position] = Instantiate(param.ParameterType);
                            }

							newInstance = constructor.Invoke(constructArgs);
						}

                        if (newInstance is not null)
                        {
                            return newInstance;
                        }
                    }
                    catch
                    {
                    }
				}
			}

			throw new ArgumentException("Can not auto construct class.", nameof(classType));
		}

		public static object? InstantiateStruct(Type? structType, object?[]? args = null) {
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

		public static object? Instantiate(Type? type, params object?[]? args) {
            if (type is null)
            {
                return null;
            }

			if (type.IsArray) 
            {
                if (args is null || args.Length == 0)
                {
                    throw new ArgumentException("args must have at least one element.");
                }

				int[] lengths = new int[args.Length];

				for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] is not int)
                    {
                        throw new ArgumentException("args must be of type int.");
                    }

					lengths[i] = Convert.ToInt32(args[i]);
				}

				return InstantiateArray(type.GetElementType(), lengths);
			}

			if (type.IsEnum)
            {
                if (args is not null && args.Length > 1)
                {
                    throw new ArgumentException("args must have at most one element.");
                }

				int? value = (int?)(args?[0] ?? null);

				return InstantiateEnum(type, value);
			}

			if (type.IsClass)
            {
                return args is null || args.Length == 0 ? InstantiateClass(type) : InstantiateClass(type, args);
			}

			if (type.IsValueType)
            {
                if (args is not null && args.Length > 0)
                {
                    throw new ArgumentException("args must have at most zero elements.");
                }

				return InstantiateStruct(type);
			}

			throw new ArgumentException("Type is not an array, enum, class, or struct.", nameof(type));
		}
	}
}
