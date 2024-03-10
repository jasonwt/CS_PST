using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PST.Assignments {
	static public partial class Assign {

		static public void FromInt(int value, ref object to) {
			// check if to implements IAssignFrom
//			if (to is IAssignFrom assignFrom) {
	//			assignFrom.To(ref value, typeof(int));
		//	}


			



		}
		
		static public void From(object from, ref object to) {
			Type fromType = from.GetType();
			Type toType = to.GetType();

			if (fromType == toType) {
				to = from;
				return;
			}

			
		}

//		static public Func<object, object> Method(Type fromType, Type toType) {

	//	}
		
	}
}
