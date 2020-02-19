using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models
{
    public class TypeValueAttribute : Attribute
    {
        public int TypeValue { get; protected set; }

        public TypeValueAttribute(int typeValue)
        {
            TypeValue = typeValue;
        }
    }
}
