using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace CustomAttribute
{
	public static class CustomValidation
	{
		public static bool Validate(object entity)
		{
			Type entityType = entity.GetType();
			PropertyInfo[] properties = entityType.GetProperties(
											BindingFlags.Public | BindingFlags.Instance);
			bool isValid = true;

			foreach (PropertyInfo property in properties)
			{
				object propertyValue = property.GetValue(entity);

				// Required Field Validation
				if (property.GetCustomAttribute(typeof(RequiredFieldAttribute)) != null)
				{
					if (propertyValue == null || (propertyValue is string str && string.IsNullOrWhiteSpace(str)))
					{
						Console.WriteLine($"Error: {property.Name} is required!");
						isValid = false;
					}
				}

				// String Length Validation
				var lengthAttribute = property.GetCustomAttribute<StringLengthRangeAttribute>();
				if (lengthAttribute != null && propertyValue is string strValue)
				{
					if (strValue.Length < lengthAttribute.Min || strValue.Length > lengthAttribute.Max)
					{
						Console.WriteLine($"Error: {property.Name} must be between {lengthAttribute.Min} and {lengthAttribute.Max} characters!");
						isValid = false;
					}
				}
			}

			return isValid;
		}
	}

}
