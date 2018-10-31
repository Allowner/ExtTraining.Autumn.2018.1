using System;
using System.Collections;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        public static Book testBook = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40m);

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.TestCases))]
        public string BookLibrary_BookToString_ReturnFormattedString(Book book, string format, IFormatProvider formatProvider)
        {
            return book.ToString(format, formatProvider);
        }

        [Test]
        public void BookLibrary_WithWrongFormat_ThrowFormatException()
            => Assert.Throws<FormatException>(() => testBook.ToString("WRONGFORMAT"));

        public class DataForTests
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(testBook, "T", null).Returns("Book: C# in Depth");
                    yield return new TestCaseData(testBook, "G", null).Returns("Book: Jon Skeet, C# in Depth");
                    yield return new TestCaseData(testBook, "Y", null).Returns("Book: Jon Skeet, C# in Depth, 2019");
                    yield return new TestCaseData(testBook, "YPH", null).Returns("Book: Jon Skeet, C# in Depth, 2019, 'Manning'");
                    yield return new TestCaseData(testBook, "YPR", new CultureInfo("en-us")).Returns("Book: Jon Skeet, C# in Depth, 2019, $40.00");
                    yield return new TestCaseData(testBook, "ALL", null).Returns("Book: Jon Skeet, C# in Depth, 2019, 'Manning', 4, 900, 40,00 ₽");
                }
            }
        }
    }
}
