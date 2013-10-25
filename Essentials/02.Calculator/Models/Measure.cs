using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.Calculator.Models
{
    public enum BitByte
    {
        Bit,
        Byte
    }

    public enum Thousand
    {
        None,
        Kilo,
        Mega,
        Giga,
        Tera,
        Peta,
        Exa,
        Zetta,
        Yotta
    }

    public class Measure
    {
        public BitByte BitBite { get; set; }
        public Thousand Thousand { get; set; }
        public int Kilo { get; set; }
        public int? Quantity { get; set; }
        public double? InBits { get; set; }


        public double? Calculate()
        {
            double? calcValue = this.InBits * this.Quantity;
            if (this.BitBite == BitByte.Byte)
            {
                calcValue /= 8;
            }

            calcValue /= Math.Pow(this.Kilo, (int)this.Thousand);
            return calcValue;
        }
    }
}