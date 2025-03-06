using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class StringLengthRangeAttribute : Attribute
	{
		public int Min { get; }
		public int Max { get; }

		public StringLengthRangeAttribute(int min, int max)
		{
			Min = min;
			Max = max;
		}
	}
}
