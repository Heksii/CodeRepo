using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave3
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------// Delopgave 1
            
            string name;
            string thingILike;
            int age;

            Console.WriteLine("Indtast et navn, en ting, og et tal.");

            name = Console.ReadLine();
            thingILike = Console.ReadLine();
            age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Mit navn er {name}, jeg er {age} år gammel og jeg kan godt lide {thingILike}.\n\n");
            Console.ReadLine();
            Console.Clear();

            //------------------------// Delopgave 2

            Console.Write("Indtast et bogstav: ");
            char character = (char)Console.Read();
            Console.ReadLine();

            Console.WriteLine($"Du tastede '{character}'.");
            Console.ReadLine();
            Console.Clear();

            //------------------------// Delopgave 3
            
            bool validAgeInput = false;

            while (validAgeInput == false)
            {
                try 
                {
                    Console.Write("Indtast din alder: ");
                    string ageInput = Console.ReadLine(); // Tag input fra brugeren

                    // Genbrug age variablen
                    age = int.Parse(ageInput); // Parse inputtet til en int
                }

                catch // Hvis der sker en exception når den prøver at parse inputtet så spørg igen
                {
                    Console.WriteLine("Indtast venligst et heltal.\n");

                    continue; // Hop tilbage til starten af while loopet
                }

                // Hvis den er nået her ned så var der ingen fejl, så hopper den ud af loopet og udskriver

                validAgeInput = true; 

                Console.WriteLine($"\nUtroligt! Er du virkelig kun {age} år??");
            }

            Console.ReadLine();
            Console.Clear();

            //------------------------// Delopgave 4

            double temp = 0;
            
            Console.Write("Indtast din nuværende lokation: ");
            string location = Console.ReadLine();

            bool validTempInput = false;

            while (validTempInput == false)
            {
                try
                {
                    Console.Write("Indtast temperaturen lige nu: ");
                    string tempInput = Console.ReadLine(); // Tag input fra brugeren

                    temp = double.Parse(tempInput); // Parse inputtet til en double
                }

                catch // Hvis der sker en exception når den prøver at parse inputtet så spørg igen.
                {
                    Console.WriteLine("Indtast venligst et tal.\n");

                    continue; // Hop tilbage til starten af while loopet
                }

                // Hvis den er nået her ned så var der ingen fejl, så hopper den ud af loopet og udskriver

                validTempInput = true;

                Console.WriteLine($"\n{temp} er da en fin temperatur for {location}.");
            }

            Console.ReadLine();

            //------------------------// Delopgave 5 og 6 er løst i de forekommende opgaver.
        }
    }
}
