using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source string is null");
            }

            if (@base > 16 || @base < 2)
            {
                throw new ArgumentOutOfRangeException("Base out of range");
            }

            string upperSourse = source.ToUpperInvariant();
            int power = 1;
            int @decimal = 0;
            int decimalIncrement;
            for (int i = upperSourse.Length - 1; i >= 0; --i)
            {
                if (CharToInt(upperSourse[i]) >= @base)
                {
                    throw new ArgumentException("Wrong base");
                }

                decimalIncrement = CharToInt(upperSourse[i]) * power;
                if(int.MaxValue - decimalIncrement < @decimal)
                {
                    throw new ArgumentException("Too big value");
                }
                @decimal += decimalIncrement;
                power = power * @base;
            }

            return @decimal;
        }

        private static int CharToInt(char c)
        {
            if (c >= '0' && c <= '9')
                return (int)c - '0';
            else
                return (int)c - 'A' + 10;
        }
    }
}
