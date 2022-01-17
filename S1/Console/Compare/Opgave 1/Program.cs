using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"17 < 10 = {17 < 20}");
            Console.WriteLine($"20 > 20 = {20 > 20}");
            Console.WriteLine($"20 <= 20 = {20 <= 20}");
            Console.WriteLine($"50 != 10 * 5 = {50 != 10 * 5}");
            Console.WriteLine($"27 - 0.15 >= 28 - 1.15 = {27 - 0.15 >= 28 - 1.15}");
            Console.WriteLine($"5 * 3 == 15 = {5 * 3 == 15}");
            Console.WriteLine($"5/5 == 1 = {5/5 == 1}");

            Console.ReadLine();
        }
    }
}
