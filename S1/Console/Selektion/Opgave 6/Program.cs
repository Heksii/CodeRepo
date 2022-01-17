using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = 0D;
            double price = 0D;

            Console.Write("Indtast vægten på et brev du gerne vil sende (i gram): ");
            double.TryParse(Console.ReadLine(), out weight);

            if (weight < 20)
            {
                price = 5;
            }
            else if (weight >= 20 && weight < 50)
            {
                price = 7;
            }
            else if (weight >= 50 && weight < 100)
            {
                price = 10;
            }
            else if (weight >= 100 && weight < 150)
            {
                price = 15;
            }
            else if (weight >= 150 && weight < 200)
            {
                price = 20;
            }
            else price = 30;

            Console.WriteLine($"Prisen på at sende brevet er: {price:N2}kr\n");

            Console.Write("Skal brevet sendes ekspres? (Y/N): ");
            int answer = Console.Read();
            Console.ReadLine();

            if (answer == 89 || answer == 121) // 89 er "Y", 121 er "y".
            {
                Console.WriteLine($"Din endelige pris bliver {(price * 1.5):N2}kr");
            }

            Console.ReadLine();
        }
    }
}
