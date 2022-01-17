using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast 2 tal til division:");

            Console.Write("a: ");
            double.TryParse(Console.ReadLine(), out double a);

            Console.Write("b: ");
            double.TryParse(Console.ReadLine(), out double b);

            if (b != 0)
            {
                Console.WriteLine($"Resultat: {a / b}");
            }
            else Console.WriteLine("Man kan ikke dividere med 0!");

            Console.ReadLine();
        }
    }
}
