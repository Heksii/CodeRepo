using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornavnEfternavn.VD.Opg3
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadKey();
        }
    }
}
