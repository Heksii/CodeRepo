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
            Console.Write("Indtast din månedsløn: ");
            double.TryParse(Console.ReadLine(), out double monthlyPay);

            Console.WriteLine($"Din årsløn er {monthlyPay * 12}kr.\n");

            Console.Write($"Indtast prisen på huset du vil købe: ");
            double.TryParse(Console.ReadLine(), out double housePrice);

            Console.WriteLine($"Du har råd til huset: {housePrice*.2 <= monthlyPay*12}");
            Console.ReadLine();
        }
    }
}
