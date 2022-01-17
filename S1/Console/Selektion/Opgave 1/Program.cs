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
            Console.Write("Indtast beløb: ");

            double amount = Convert.ToDouble(Console.ReadLine());
            double discount = 0D;

            if (amount > 1000D)
            {
                discount = amount * .05;
            }

            discount = Math.Round(discount, 2);

            Console.WriteLine($"Du får {discount:N2}kr i rabat.");
            Console.ReadLine();
        }
    }
}
