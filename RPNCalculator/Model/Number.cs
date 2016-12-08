using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPNCalculator.Model
{
    class Number
    {
        private String decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private String _value;


        public Number(String value)
        {
            //packing and unpacking to eliminate leading zeroes.
            _value = Double.Parse(value).ToString();
        }

        public Double getDoubleValue()
        {
            return Double.Parse(_value);
        }

        public static Number operator +(Number n1, Number n2)
        {
            return new Number((n1.getDoubleValue() + n2.getDoubleValue()).ToString());
        }

        public static Number operator -(Number n1, Number n2)
        {
            return new Number((n1.getDoubleValue() - n2.getDoubleValue()).ToString());
        }

        public static Number operator *(Number n1, Number n2)
        {
            return new Number((n1.getDoubleValue() * n2.getDoubleValue()).ToString());
        }

        public static Number operator /(Number n1, Number n2)
        {
            return new Number((n1.getDoubleValue() / n2.getDoubleValue()).ToString());
        }

        public static Number operator ^(Number n1, Number n2)
        {
            return new Number((Math.Pow(n1.getDoubleValue(), n2.getDoubleValue())).ToString());
        }

        public static Number operator ++(Number n1)
        {
            return new Number(Math.Sqrt(n1.getDoubleValue()).ToString());
        }

        public static Number operator ~(Number n1)
        {
            return new Number((1.0 / n1.getDoubleValue()).ToString());
        }

        public Double[] ToSeconds(Number[] numTab)
        {
            Double[] seconds = new Double[2];
            int i = 0;
            foreach (Number num in numTab)
            {
                Double d = Math.Round(num.getDoubleValue(), 2, MidpointRounding.AwayFromZero);
                Double whole = Math.Floor(d);
                Double fract = Math.Round((d - whole)*100, 2, MidpointRounding.AwayFromZero);
                seconds[i] = whole * 60 + fract;
                i++;
            }
            return seconds;
        }

        public Number SecondsToNumber(Double seconds)
        {
            if (seconds < 0.0) //cant have negative time values
                return new Number("0");
            Double wholePart = (int)seconds / 60;
            int fractPart = (int)Math.Round(seconds % 60, 2, MidpointRounding.AwayFromZero);
            return new Number(wholePart.ToString() + decimalSeparator + fractPart.ToString("D2"));
        }

        public Number TimeAddition(Number otherNumber)
        {
            Number[] numTab = { this, otherNumber };
            Double[] seconds = ToSeconds(numTab);
            return SecondsToNumber(seconds.Sum());        
        }

        public Number TimeSubtraction(Number otherNumber)
        {
            Number[] numTab = { this, otherNumber };
            Double[] seconds = ToSeconds(numTab);
            return SecondsToNumber(seconds[0] - seconds[1]);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
