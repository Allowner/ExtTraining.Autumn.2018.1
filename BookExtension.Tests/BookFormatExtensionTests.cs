using BookLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        public static Book testBook = new Book("C# in Depth", "Jon Skeet", "2019", "Manning", "4", "900", "40");
        [Test]
        public void BookFormatExtension_FormatBook_ReturnString()
        {
            IFormatProvider fp = new BookFormatExtension();
            string formated = string.Format(fp, "{0:TP}", testBook);
            string expected = "Book: C# in Depth, 900";

            Assert.AreEqual(formated, expected);
        }
    }
}
