using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast dit fornavn: ");
            string firstNname = Console.ReadLine();
            Console.Write("Indtast dit efternavn: ");
            string lastName = Console.ReadLine();

            string fullName = $"{firstNname} {lastName}";

            Console.WriteLine($"\nDu hedder {fullName}");
            Console.WriteLine($"Alt med stort: {fullName.ToUpper()}");
            Console.WriteLine($"Alt med småt: {fullName.ToLower()}");

            Console.ReadLine();
        }
    }
}
