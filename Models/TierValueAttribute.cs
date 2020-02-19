using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models
{
    public class TierValueAttribute : Attribute
    {
        public string TierValue { get; protected set; }

        public TierValueAttribute(string tierValue)
        {
            TierValue = tierValue;
        }
    }
}
