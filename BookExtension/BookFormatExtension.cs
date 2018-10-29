using BookLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider standart;

        public BookFormatExtension() : this(CultureInfo.CurrentCulture)
        {

        }

        public BookFormatExtension(IFormatProvider formatProvider)
        {
            standart = formatProvider;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {

            if (arg == null || format != "TP")
            {
                return string.Format(standart, "{0:" + format + "}", arg);
            }
            string currentString = "Book: ";
            Book book = (Book)arg;
            return currentString + string.Format("{0}, {1}", book.title, book.pages);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
