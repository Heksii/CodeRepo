using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string adress;
            string city;
            string email;

            int zipCode;
            int phoneNumber;

            Console.Write("Indtast dit fornavn: ");
            firstName = Console.ReadLine();

            Console.Write("Indtast dit efternavn: ");
            lastName = Console.ReadLine();

            Console.Write("Indtast din addresse: ");
            adress = Console.ReadLine();

            Console.Write("Indtast dit postnummer: ");
            zipCode = int.Parse(Console.ReadLine());

            Console.Write("Indtast din By: ");
            city = Console.ReadLine();

            Console.Write("Indtast dit telefon nummer: ");
            phoneNumber = int.Parse(Console.ReadLine());

            Console.Write("Indtast din e-mail adresse: ");
            email = Console.ReadLine();

            Console.WriteLine($"\n{firstName} {lastName}");
            Console.WriteLine($"{adress}");
            Console.WriteLine($"{zipCode} {city}");
            Console.WriteLine($"Tlf.: {phoneNumber}");
            Console.WriteLine($"E-mail: {email}");

            Console.ReadLine();
        }
    }
}
