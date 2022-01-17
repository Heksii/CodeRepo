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
            int currentYear = DateTime.Now.Year; // Det nuvæerende år.

            Console.Write("Indtast dit fødselår: ");
            int.TryParse(Console.ReadLine(), out int birthYear);

            birthYear = Math.Min(currentYear, birthYear); // Vær sikker på at fødselsåret er mindre end det nuværende år.
            int age = currentYear - birthYear;

            bool canBuyBeer = age >= 16;
            bool canBuySpirits = age >= 18;

            Console.WriteLine($"Kan du købe øl: {canBuyBeer}.");
            Console.WriteLine($"Kan du købe spiritus: {canBuySpirits}.");

            Console.ReadLine();
        }
    }
}
