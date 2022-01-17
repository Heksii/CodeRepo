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
            Console.WriteLine("Indtast 2 tal:");

            Console.Write("a: ");
            double.TryParse(Console.ReadLine(), out double a);

            Console.Write("b: ");
            double.TryParse(Console.ReadLine(), out double b);

            if (a == b)
            {
                Console.WriteLine("\nDe to tal er ens!");
            } else Console.WriteLine("\nDe to tal er ikke ens!");

            Console.ReadLine();
        }
    }
}
