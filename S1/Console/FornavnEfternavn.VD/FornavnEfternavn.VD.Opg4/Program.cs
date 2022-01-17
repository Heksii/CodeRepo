using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornavnEfternavn.VD.Opg4
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------// Variables

            byte minByte = byte.MinValue; // Minimum verdi for en byte
            byte maxByte = byte.MaxValue; // Maximum verdi for en byte

            sbyte minSbyte = sbyte.MinValue; // Minimum verdi for en sbyte
            sbyte maxSbyte = sbyte.MaxValue; // Maximum verdi for en sbyte

            int minInt = int.MinValue; // Minimum verdi for en int
            int maxInt = int.MaxValue; // Maximum verdi for en int

            uint minUint = uint.MinValue; // Minimum verdi for en uint
            uint maxUint = uint.MaxValue; // Maximum verdi for en uint

            long minLong = long.MinValue; // Minimum verdi for en long
            long maxLong = long.MaxValue; // Maximum verdi for en long

            ulong minUlong = ulong.MinValue; // Minimum verdi for en ulong
            ulong maxUlong = ulong.MaxValue; // Maximum verdi for en ulong

            short minShort = short.MinValue; // Minimum verdi for en short
            short maxShort = short.MaxValue; // Maximum verdi for en short

            ushort minUshort = ushort.MinValue; // Minimum verdi for en ushort
            ushort maxUshort = ushort.MaxValue; // Maximum verdi for en ushort

            decimal minDeci = decimal.MinValue; // Minimum verdi for en decimal
            decimal maxDeci = decimal.MaxValue; // Maximum verdi for en decimal

            double minDouble = double.MinValue; // Minimum verdi for en double
            double maxDouble = double.MaxValue; // Maximum verdi for en double

            float minFloat = float.MinValue; // Minimum verdi for en float
            float maxFloat = float.MaxValue; // Maximum verdi for en float

            //--------------------------------------------------------------// Udskriv hele lortet

            Console.WriteLine($"byte: {minByte} {maxByte}");
            Console.WriteLine($"sbyte: {minSbyte} {maxSbyte}");

            Console.WriteLine($"int: {minInt} {maxInt}");
            Console.WriteLine($"uint: {minUint} {maxUint}");

            Console.WriteLine($"long: {minLong} {maxLong}");
            Console.WriteLine($"ulong: {minUlong} {maxUlong}");

            Console.WriteLine($"short: {minShort} {maxShort}");
            Console.WriteLine($"ushort: {minUshort} {maxUshort}");

            Console.WriteLine($"decimal: {minDeci} {maxDeci}");
            Console.WriteLine($"double: {minDouble} {maxDouble}");
            Console.WriteLine($"floal: {minFloat} {maxFloat}");

            Console.ReadLine();
        }
    }
}
