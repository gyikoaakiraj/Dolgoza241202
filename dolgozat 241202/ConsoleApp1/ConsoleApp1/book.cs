using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Book
    {
        public long ISBN { get; private set; }
        public List<author> Authors { get; private set; }
        public string Title { get; private set; }
        public int ReleaseYear { get; private set; }
        public string Language { get; private set; }
        public int Stock { get; set; }
        public decimal Price { get; private set; }

        public Book(long isbn, List<string> authors, string title, int releaseYear, string language, int stock, decimal price)
        {
            ISBN = isbn;
            Authors = authors.Select(a => new author(a)).ToList();
            Title = title;
            ReleaseYear = releaseYear;
            Language = language;
            Stock = stock;
            Price = price;
        }

        public static List<Book> BooksList = new List<Book>();

        public static void GenerateRandomBooks(int count)
        {
            Random random = new Random();
            var titles = new[]
            {
            "A Tűz Gyümölcse",
            "The Fire's Fruit",
            "Az Elveszett Játék",
            "The Lost Game",
            "A Szív Nehezen Feled",
            "Heart is Hard to Forget",
            "A Rózsa Titka",
            "The Secret of the Rose"
        };

            for (int i = 0; i < count; i++)
            {
                string title;
                string language = random.NextDouble() < 0.8 ? "magyar" : "angol";
                title = titles[random.Next(titles.Length)];

                List<string> authors = new List<string>();
                if (random.NextDouble() < 0.7)
                {
                    authors.Add("John Doe");
                }
                else
                {
                    int authorCount = random.Next(2, 4);
                    for (int j = 0; j < authorCount; j++)
                    {
                        authors.Add("Jane Doe");
                    }
                }

                int stock = random.NextDouble() < 0.3 ? 0 : random.Next(5, 11);
                long isbn;
                do
                {
                    isbn = random.Next(100000000, 1000000000);
                } while (BooksList.Any(b => b.ISBN == isbn));

                var book = new Book(isbn, authors, title, DateTime.Now.Year, language, stock, 4500);
                BooksList.Add(book);
            }
        }
    }
}