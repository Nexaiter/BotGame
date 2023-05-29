using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Enums
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static (string label, string buttonId) GetButton(this Enum buttonId, char separator = '-')
        {
            var label = EnumHelper.GetEnumDescription(buttonId);
            var id = $"{buttonId.GetType().Name}{separator}{buttonId}";
            return (label, id);
        }


        public static List<string> GetEnumNames<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T)).ToList();
        }

        public static Enum GetEnumType(string enumName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = Array.Find(assembly.GetTypes(), x => x.Name == enumName || x.FullName == enumName);
                if (type is null)
                    continue;
                if (type.IsEnum)
                {
                    return (Enum)Activator.CreateInstance(type)!;
                }

            }
            return null;
        }
        public static (Enum enumType, string enumValue) GetEnumTypeAndValueWithSeparator(string enumTypeWithValue, char separator = '-')
        {
            var tempEnum = enumTypeWithValue.Split(separator);
            if(tempEnum == null) { throw new ArgumentNullException("No separator or empty string"); }
            if(tempEnum.Length > 2) { throw new ValidationException("Too long"); }

            var enumName = tempEnum[0];
            var enumValue = tempEnum[1];

            return (GetEnumType(enumName), enumValue);

        }
    }
}
