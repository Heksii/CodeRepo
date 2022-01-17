using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast dit fornavn: ");
            string firstName = Console.ReadLine();

            Console.Write("Indtast dit efternavn: ");
            string lastName = Console.ReadLine();

            string fullName = $"{firstName} {lastName}";

            Console.WriteLine($"\nLængden på dit navn: {fullName.Length}");
            Console.WriteLine($"Alt med stort: {fullName.ToUpper()}");
            Console.WriteLine($"Alt med småt: {fullName.ToLower()}");
            Console.WriteLine($"Dine initialer er: {firstName[0]}{lastName[0]}");

            Console.ReadLine();
        }
    }
}
