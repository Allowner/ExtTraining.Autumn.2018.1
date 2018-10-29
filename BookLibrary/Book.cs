using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        //TODO
        public readonly string title;
        public readonly string author;
        public readonly string year;
        public readonly string publishingHous;
        public readonly string edition;
        public readonly string pages;
        public readonly string price;

        public Book(string title, string author, string year, string publishingHous,
            string edition, string pages, string price)
        {
            this.title = title;
            this.author = author;
            this.year = year;
            this.publishingHous = publishingHous;
            this.edition = edition;
            this.pages = pages;
            this.price = price;
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            string currentString = "Book: ";

            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return currentString + string.Format("{1}, {0}", title, author);
                case "T":
                    return currentString + title;
                case "Y":
                    return currentString + string.Format("{1}, {0}, {2}", title, author, year);
                case "YPH":
                    return currentString + string.Format("{1}, {0}, {2}, '{3}'", title, author, year, publishingHous);
                case "YPR":
                    return currentString + string.Format("{1}, {0}, {2}, {3:C}", title, author, year, double.Parse(price));
                case "ALL":
                    return currentString + string.Format("{1}, {0}, {2}, '{3}', {4}, {5}, {6:C}",
                       title, author, year, publishingHous, edition, pages, double.Parse(price));
                default:
                    throw new FormatException(string.Format("Format {0} is not supported!", format));

            }
        }
    }
}
