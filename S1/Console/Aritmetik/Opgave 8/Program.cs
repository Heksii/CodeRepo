using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast navnet og prisen på seks varer:");

            Console.Write("Navn: ");
            string name1 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price1);

            Console.Write("\nNavn: ");
            string name2 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price2);

            Console.Write("\nNavn: ");
            string name3 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price3);

            Console.Write("\nNavn: ");
            string name4 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price4);

            Console.Write("\nNavn: ");
            string name5 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price5);

            Console.Write("\nNavn: ");
            string name6 = Console.ReadLine();
            Console.Write("Pris: ");
            double.TryParse(Console.ReadLine(), out double price6);

            Console.WriteLine($"\n1. {name1}, Pris: {price1}kr.");
            Console.WriteLine($"2. {name2}, Pris: {price2}kr.");
            Console.WriteLine($"3. {name3}, Pris: {price3}kr.");
            Console.WriteLine($"4. {name4}, Pris: {price4}kr.");
            Console.WriteLine($"5. {name5}, Pris: {price5}kr.");
            Console.WriteLine($"6. {name6}, Pris: {price6}kr.\n");

            double sum = price1 + price2 + price3 + price4 + price5 + price6;
            double moms = sum * .25;

            Console.WriteLine($"Pris uden moms: {sum}");
            Console.WriteLine($"Moms beløb: {moms}");
            Console.WriteLine($"Total pris: {sum + moms}\n");

            Console.Write("Indtast den mængde du vil betale: ");

            double.TryParse(Console.ReadLine(), out double payment);
            
            // Hvis betalingen er større end total-prisen, så skriv kundens returbeløb, ellers skriv hvad de skylder.
            string output = payment > sum + moms ? $"Dit returbeløb er {payment - (sum + moms)}" : $"Du skylder {sum + moms - payment}";

            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}
