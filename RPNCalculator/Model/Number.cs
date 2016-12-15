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
            //boxing i unboxing aby zapobiec wartościom typu "12," na stosie
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

        /*
         * Zamiana obiektów klasy Number na ich reprezentację w sekundach
         * Używane w dodawaniu i odejmowaniu czasu
         */
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

        /*
         * Zamiana zsumowanych lub odjętych wcześniej sekund na obiekt klasy Number
         */
        public Number SecondsToNumber(Double seconds)
        {
            if (seconds < 0.0) //ujemne wartości czasu nie istnieją
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

        /*
         * Sprawdza, czy podana przez użytkownika data zgadza się z formatem: dd.MMyyyy
         */
        public bool CheckDateFormat()
        {
            String pattern = "d" + decimalSeparator + "MMyyyy";
            DateTime parsedDate;
            return DateTime.TryParseExact(_value, pattern, null, DateTimeStyles.None, out parsedDate);
        }

        /*
         * Zwraca obiekt DateTime na podstawie podanego przez użytkownika stringa: dd.MMyyyy
         */
        public DateTime GetDateFromCustomFormat()
        {
            String pattern = "d" + decimalSeparator + "MMyyyy";
            DateTime parsedDate;
            DateTime.TryParseExact(_value, pattern, null, DateTimeStyles.None, out parsedDate);
            return parsedDate;
        }

        /*
         * Do daty można dodać ilość dni, ale nie inną datę
         * Ponadto niemożliwe jest dodanie do ilości dni jakiejś daty, powinno dodawać się
         * do pewnej daty ilość dni
         */
        public Number DateAddition(Number otherNumber)
        {
            DateTime d2 = this.GetDateFromCustomFormat();
            DateTime result = DateTime.FromOADate(d2.ToOADate() + otherNumber.getDoubleValue());
            return new Number(result.ToString("d" + decimalSeparator + "MMyyyy"));
        }

        /*
         * Od daty można odjąć inną datę
         * Odejmować można również od pewnej daty ilość dni (ale nie na odwrót!)
         */
        public Number DateSubtraction(Number otherNumber)
        {
            DateTime d2 = this.GetDateFromCustomFormat();
            if (otherNumber.ToString().Contains(decimalSeparator))
            {
                DateTime d1 = otherNumber.GetDateFromCustomFormat();
                return new Number((d2.ToOADate() - d1.ToOADate()).ToString());
            }
            else
            {
                DateTime result = DateTime.FromOADate(d2.ToOADate() - otherNumber.getDoubleValue());
                return new Number(result.ToString("d" + decimalSeparator + "MMyyyy"));
            }
            
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
