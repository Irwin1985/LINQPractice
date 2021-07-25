using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    public static class LinqToXML
    {
        public static void ShowSample()
        {
            // Let's say we have the following collection of books
            Book[] books = new Book[]
            {
                new Book("Ajax in Action", "Manning", 2005),
                new Book("Windows Forms in Action", "Manning", 2006),
                new Book("RSS and Atom in Action", "Manning", 2006),
            };
            // Here is the resule we would like to get if we ast for the books
            // published in 2006
            XElement xml = new XElement("books",
                from book in books
                where book.Year == 2006
                select new XElement("book",
                    new XAttribute("title", book.Title),
                    new XElement("publisher", book.Publisher)
                    )
            );
            Console.WriteLine(xml);
        }
    }   
    class Book
    {
        public string Publisher;
        public string Title;
        public int Year;
        public Book(string title, string publisher, int year)
        {
            Title = title;
            Publisher = publisher;
            Year = year;
        }
    }
}
