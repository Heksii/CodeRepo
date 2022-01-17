using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornavnEfternavn.VD.Opg2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Casper Kjær Meltesen"; // Mit fulde navn
            string address = "Løjt Nørregade 28 6200 Aabenraa"; // Min addresse
            string email = "casp196b@edu.campusvejle.dk"; // Min Asp-IT mail
            string path = Environment.CurrentDirectory; // Fil path til programmet

            int age = 16; // Min alder
            int birthYear = 2005; // Mit fødselsår
            int temp = 7; // Temperaturen i vejle den 19. marts 2019

            double promille = .3; // En promille på 0,3

            double whole = 1; // 100%
            double fiveForths = 1.25; // 125%
            double oneForth = .25; // 25%

            double tiny = double.Epsilon; // Den mindste verdi en double kan holde

            Console.WriteLine("Strings:"); // Skriv alle strings i konsollen
            Console.WriteLine($"1: {fullName}");
            Console.WriteLine($"2: {address}");
            Console.WriteLine($"3: {email}\n");
            Console.WriteLine($"4: {path}\n");

            Console.WriteLine("Integers:"); // Skriv alle heltal i konsollen
            Console.WriteLine($"5: {age}");
            Console.WriteLine($"6: {birthYear}");
            Console.WriteLine($"7: {temp}\n");

            Console.WriteLine("Doubles:"); // Skriv alle decimaltal i konsollen
            Console.WriteLine($"8: {promille}");
            Console.WriteLine($"9: {whole}");
            Console.WriteLine($"10: {fiveForths}");
            Console.WriteLine($"11: {oneForth}");
            Console.WriteLine($"12: {tiny}\n");

            Console.WriteLine();

            byte byteValue = 150;
            int intValue = -250;
            float floatValue = (float)Math.PI;
            double doubleValue = Math.PI;
            bool boolValue = true;

            Console.WriteLine($"Byte: {byteValue}");
            Console.WriteLine($"Int: {intValue}");
            Console.WriteLine($"Float: {floatValue}");
            Console.WriteLine($"Double: {doubleValue}");
            Console.WriteLine($"Bool: {boolValue}");

            Console.ReadLine();
        }
    }
}
