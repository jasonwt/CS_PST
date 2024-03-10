using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST.Assignments {
	static public partial class Assign {
		public delegate void AssignmentDelegate (object from, ref object to);

		static public bool To(object from, ref object to) {
			if (from is null || to is null)
				throw new ArgumentNullException(from is null ? nameof(from) : nameof(to));

			Type fromType = from.GetType();
			Type toType = to.GetType();

			if (typeof(IAssignFrom).IsAssignableFrom(toType)) {
				((IAssignFrom)to).AssignFrom(from);
				return true;
			}

			if (typeof(IAssignTo).IsAssignableFrom(fromType)) {
				((IAssignTo)from).AssignTo(ref to);
				return true;
			}

			switch (Type.GetTypeCode(fromType)) {
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					break;

				default:
					return false;
			}

			switch (Type.GetTypeCode(toType)) {
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					to = Convert.ChangeType(from, toType);
					return true;
			}

			return false;
		}
		
		static public AssignmentDelegate? Method(Type fromType, Type toType) {
			if (typeof(IAssignFrom).IsAssignableFrom(toType)) {
				return (object from, ref object to) => {
					((IAssignFrom)to).AssignFrom(from);
				};
			}

			if (typeof(IAssignTo).IsAssignableFrom(fromType)) {
				return (object from, ref object to) => {
					((IAssignTo)from).AssignTo(ref to);
				};
			}

			switch (Type.GetTypeCode(fromType)) {
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					break;

				default:
					throw new InvalidCastException();
			}

			switch (Type.GetTypeCode(toType)) {
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					return (object from, ref object to) => to = Convert.ChangeType(from, toType);
			}

			throw new InvalidCastException();
		}
		
	}
}
