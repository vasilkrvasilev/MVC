using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PlaceSystem.CustomAttributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int minValue;

        public MinValueAttribute(int minValue)
        {
            this.minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value >= minValue;
        }
    }
}
