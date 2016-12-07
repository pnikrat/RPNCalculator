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

        public override string ToString()
        {
            return _value;
        }
    }
}
