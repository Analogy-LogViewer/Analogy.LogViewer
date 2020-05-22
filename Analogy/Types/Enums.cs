using Analogy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Analogy.Types
{
    public enum UpdateMode
    {
        [Display(Name = "Never")] Never,
        [Display(Name = "Each Startup")] EachStartup,
        [Display(Name = "Once a Week")] OnceAWeek,
        [Display(Name = "Once a Month")] OnceAMonth,
    }

    public static class EnumUtils
    {
        public static string GetDisplay(this Enum value)

        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            DisplayAttribute[] attributes = (DisplayAttribute[])value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Count() != 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return attributes[0].Name;

        }

        public static Dictionary<string, string> GetDisplayValues(this Type enumType)
        {
            var enumValues = new Dictionary<string, string>();
            foreach (Enum value in Enum.GetValues(enumType))
            {
                enumValues.Add(value.ToString(), value.GetDisplay());
            }

            return enumValues;
        }
    }
}