using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;

            Console.Write("Indtast dit fornavn: ");

            firstName = Console.ReadLine();

            Console.Write("Indtast dit efternavn: ");

            lastName = Console.ReadLine();

            Console.WriteLine($"\nTillyke {firstName} {lastName}.");
            Console.WriteLine("Du er nu godt i gang med at programmere i C#!");

            Console.ReadLine();
        }
    }
}
