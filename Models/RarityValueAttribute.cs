using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models
{
    public class RarityValueAttribute : Attribute
    {
        public int RarityValue { get; protected set; }

        public RarityValueAttribute(int rarityValue)
        {
            RarityValue = rarityValue;
        }
    }
}
