using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LoanPaymentCalculator
{
    static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string st)
        {
            return string.IsNullOrEmpty(st);
        }

        public static string ReplaceWithNewLine(this string st, string substring)
        {
            return st.Replace(substring, substring+Environment.NewLine);
        }

        public static string Join(this IEnumerable<string> list, string delimiter)
        {
            return list.Aggregate(string.Empty,
                (result, part) =>
                    result + (result.IsNullOrEmpty() ? string.Empty : delimiter) + part);
        }

        public static T GetAttribute<T>(this MemberInfo member, bool isRequired)
            where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture, 
                        "The {0} attribute must be defined on member {1}", 
                        typeof(T).Name, 
                        member.Name));
            }

            return (T)attribute;
        }

        public static string GetDisplayName(this MemberInfo property)
        {
            var displayAttr = (DisplayAttribute)property.GetCustomAttributes(typeof (DisplayAttribute), false).FirstOrDefault();
            if (displayAttr == null)
            {
                return property.Name;
            }

            return displayAttr.Name;
        }
    }
}
