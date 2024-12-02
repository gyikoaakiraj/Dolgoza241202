using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class author
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid Id { get; private set; }

        public author(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("A teljes név nem lehet üres.");

            var nameParts = fullName.Split(' ');

            if (nameParts.Length != 2 ||
                nameParts[0].Length < 3 || nameParts[0].Length > 32 ||
                nameParts[1].Length < 3 || nameParts[1].Length > 32)
            {
                throw new ArgumentException("A név részei egyenként minimum 3, maximum 32 karakter hosszúak lehetnek.");
            }

            FirstName = nameParts[0];
            LastName = nameParts[1];
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
