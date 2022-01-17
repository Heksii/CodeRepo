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
            int x = 10;
            int y = 3;

            double resultat1 = x / y;
            double resultat2 = (double)x / (double)y;
            double resultat3 = Math.Round(resultat2, 2);
            double resultat4 = x % y;

            Console.WriteLine("Division med int datatype gemt i en double:");
            Console.WriteLine($"{x} / {y} = "+resultat1);

            Console.WriteLine("\nDivision med konverterede int til double datatype:");
            Console.WriteLine($"{x} / {y} = " + resultat2);

            Console.WriteLine("\nForkortet til 2 decimaler:");
            Console.WriteLine($"{x} / {y} = " + resultat3);

            Console.WriteLine("\nModulus:");
            Console.WriteLine($"{x} % {y} = " + resultat4);

            Console.ReadLine();
        }
    }
}
