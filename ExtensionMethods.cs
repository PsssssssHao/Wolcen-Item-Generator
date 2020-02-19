using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WolcenMod.Models;

namespace WolcenMod
{
    public static class ExtensionMethods
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static string GetTierValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            TierValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(TierValueAttribute), false) as TierValueAttribute[];

            return attribs.Length > 0 ? attribs[0].TierValue : null;
        }

        public static int GetRarityValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            RarityValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(RarityValueAttribute), false) as RarityValueAttribute[];

            return attribs.Length > 0 ? attribs[0].RarityValue : 0;
        }

        public static int GetQualityValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            QualityValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(QualityValueAttribute), false) as QualityValueAttribute[];

            return attribs.Length > 0 ? attribs[0].QualityValue : 0;
        }

        public static int GetTypeValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            TypeValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(TypeValueAttribute), false) as TypeValueAttribute[];

            return attribs.Length > 0 ? attribs[0].TypeValue : 0;
        }
    }
}
