using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            /*
            Console.WriteLine("Indtast højden på 5 personer.");

            Console.Write($"Person 1: ");
            double.TryParse(Console.ReadLine(), out double height1);
            Console.Write($"Person 2: ");
            double.TryParse(Console.ReadLine(), out double height2);
            Console.Write($"Person 3: ");
            double.TryParse(Console.ReadLine(), out double height3);
            Console.Write($"Person 4: ");
            double.TryParse(Console.ReadLine(), out double height4);
            Console.Write($"Person 5: ");
            double.TryParse(Console.ReadLine(), out double height5);

            sum = height1 + height2 + height3 + height4 + height5;
            
            Console.WriteLine($"Gennemsnits højden på personerne er: {sum / 5}");
            */
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Person {i + 1}: ");
                double.TryParse(Console.ReadLine(), out double height);
                sum += height;
            }

            Console.WriteLine($"Gennemsnits højden på personerne er: {sum / 5}");*/
            Console.ReadLine();
        }
    }
}
