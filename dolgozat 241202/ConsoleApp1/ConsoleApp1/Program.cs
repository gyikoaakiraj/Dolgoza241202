namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book.GenerateRandomBooks(15);

            int initialStock = Book.BooksList.Sum(b => b.Stock);
            decimal totalRevenue = 0;
            int outOfStockCount = 0;

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                if (Book.BooksList.Count == 0)
                {
                    Console.WriteLine("Nincs több könyv a listában.");
                    break;
                }

                var selectedBook = Book.BooksList[random.Next(Book.BooksList.Count)];

                if (selectedBook == null)
                {
                    Console.WriteLine("A kiválasztott könyv nem található.");
                    continue;
                }

                if (selectedBook.Stock > 0)
                {
                    selectedBook.Stock--;
                    totalRevenue += selectedBook.Price;
                }
                else
                {
                    if (random.NextDouble() < 0.5)
                    {
                        int additionalStock = random.Next(1, 11);
                        selectedBook.Stock += additionalStock;
                        Console.WriteLine($"Beszereztek {additionalStock} db {selectedBook.Title} könyvet.");
                    }
                    else
                    {

                        outOfStockCount++;
                        Book.BooksList.Remove(selectedBook);
                        Console.WriteLine($"{selectedBook.Title} elfogyott a nagykerből.");
                    }
                }
            }

            int finalStock = Book.BooksList.Sum(b => b.Stock);
            int stockChange = finalStock - initialStock;

            Console.WriteLine($"\nBruttó bevétel: {totalRevenue} Ft");
            Console.WriteLine($"Elfogyott könyvek a nagykerből: {outOfStockCount} db");
            Console.WriteLine($"Készletváltozás: {initialStock} db (kezdeti) -> {finalStock} db (jelenlegi), Különbség: {stockChange} db");
        }
    }   
}
