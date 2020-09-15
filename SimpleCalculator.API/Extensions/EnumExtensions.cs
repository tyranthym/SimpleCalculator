using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayAttributeName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute == null)
            {
                return enumValue.ToString();
            }
            return displayAttribute.GetName();
        }
    }
}
