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
            Console.WriteLine("Indtast 3 tal: ");

            double.TryParse(Console.ReadLine(), out double a);
            double.TryParse(Console.ReadLine(), out double b);
            double.TryParse(Console.ReadLine(), out double c);

            if ((a > b) && (a > c))
            {
                if (b > c)
                {
                    Console.WriteLine($"\n{a}, {b}, {c}");
                }
                else
                {
                    Console.WriteLine($"\n{a} {c} {b}");
                }
            }
            else if ((b > a) && (b > c))
            {
                if (a > c)
                {
                    Console.WriteLine($"\n{b} {a} {c}");
                }
                else
                {
                    Console.WriteLine($"\n{b} {c} {a}");
                }
            }
            else if ((c > a) && (c > b))
            {
                if (a > b)
                {
                    Console.WriteLine($"\n{c} {a} {a}");
                }
                else
                {
                    Console.WriteLine($"\n{c} {a} {a}");
                }
            }

            Console.ReadLine();
        }
    }
}
