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
            Console.Write("Indtast antallet af sekunder, som skal omregnes til minutter og sekunder: ");

            int seconds = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{seconds} sekunder svarer til {seconds / 60} minutter og {seconds % 60} sekunder.");
            Console.ReadLine();
        }
    }
}
