using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models
{
    public class QualityValueAttribute : Attribute
    {
        public int QualityValue { get; protected set; }

        public QualityValueAttribute(int qualityValue)
        {
            QualityValue = qualityValue;
        }
    }
}
