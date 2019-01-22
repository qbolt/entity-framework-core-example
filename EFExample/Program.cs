using System;
using System.Collections.Generic;
using System.Linq;

namespace EFExample
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new ExampleContext())
            {
//                var author = new Author
//                {
//                    FirstName = "William",
//                    LastName = "Shakespeare",
//                    Books = new List<Book>
//                    {
//                        new Book {Title = "Hamlet"},
//                        new Book {Title = "Othello"},
//                        new Book {Title = "MacBeth"}
//                    }
//                };
//                context.Add(author);
//                context.SaveChanges();

                IEnumerable<Book> bookQuery =
                    from book in context.Books
                    where book.Title.Contains("l")
                    select book;

                foreach (var book in bookQuery)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
    }
}