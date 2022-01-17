using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast et tal: ");
            double.TryParse(Console.ReadLine(), out double x);

            Console.Write("Indtast et tal mere: ");
            double.TryParse(Console.ReadLine(), out double y);

            Console.WriteLine(x>y?$"{x}\n{y}":$"{y}\n{x}");
            Console.ReadLine();

            /*if (x > y)
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
            }
            else
            {
                Console.WriteLine(y);
                Console.WriteLine(x);
            }

            Console.ReadLine();*/
        }
    }
}
