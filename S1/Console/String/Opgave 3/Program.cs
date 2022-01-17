using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast dit fornavn: ");
            string firstName = Console.ReadLine();

            Console.Write("Indtast dit efternavn: ");
            string lastName = Console.ReadLine();

            Console.WriteLine($"\nDine initialer er: {firstName[0]}{lastName[0]}");

            Console.ReadLine();
        }
    }
}
