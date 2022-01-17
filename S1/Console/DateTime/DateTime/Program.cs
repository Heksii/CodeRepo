using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DateTime myBirth = new DateTime(2005, 4, 17);
            DateTime queenBirth = new DateTime(1940, 4, 16);
            DateTime grundlov = new DateTime(1849, 6, 5);
            DateTime vmHandball = new DateTime(2019, 1, 10);
            DateTime vacation = new DateTime(2022, 7, 4);
            DateTime now = DateTime.Now;
            DateTime socialActivity = new DateTime(2022, 12, 10, 12, 30, 0);
            DateTime arrival = new DateTime(2022, 12, 1, 9, 50, 0);
            DateTime news = new DateTime(2022, 12, 4, 21, 0, 0);
            */

            DateTime myBirth = DateTime.Parse("2005 04 17");
            DateTime queenBirth = DateTime.Parse("1940 4 16");
            DateTime grundlov = DateTime.Parse("1849 6 5");
            DateTime vmHandball = DateTime.Parse("2019 1 10");
            DateTime vacation = DateTime.Parse("2022 7 4");
            DateTime now = DateTime.Now;
            DateTime socialActivity = DateTime.Parse("2022 12 10 12:30");
            DateTime arrival = DateTime.Parse("2022 12 01 9:50");
            DateTime news = DateTime.Parse("2022 12 04 21:00");

            Console.WriteLine("-----------------------------------\n\nToLongDateString:\n");
            
            Console.WriteLine($"Min fødselsdato: {myBirth.ToLongDateString()}");
            Console.WriteLine($"Dronningens fødselsdato: {queenBirth.ToLongDateString()}");
            Console.WriteLine($"Datoen på underskrift af den første Danmarks Riges Grundlov: {grundlov.ToLongDateString()}");
            Console.WriteLine($"Datoen for den første kamp i VM i Håndbold 2019 (for herrer): {vmHandball.ToLongDateString()}");
            Console.WriteLine($"Datoen for sommerferien for AspIT elever 2022: {vacation.ToLongDateString()}");
            Console.WriteLine($"Nuværende tidspunkt: {now.ToLongDateString()}");
            Console.WriteLine($"Tidspunkt og dato for starten af social aktivitet næste fredag: {socialActivity.ToLongDateString()}");
            Console.WriteLine($"Hvornår jeg mødte i dag: {arrival.ToLongDateString()}");
            Console.WriteLine($"Hvornår TV AVISEN vises sidste gang på lørdag på DR1: {news.ToLongDateString()}\n");

            Console.WriteLine("-----------------------------------\n\nToShortDateString:\n");

            Console.WriteLine($"Min fødselsdato: {myBirth.ToShortDateString()}");
            Console.WriteLine($"Dronningens fødselsdato: {queenBirth.ToShortDateString()}");
            Console.WriteLine($"Datoen på underskrift af den første Danmarks Riges Grundlov: {grundlov.ToShortDateString()}");
            Console.WriteLine($"Datoen for den første kamp i VM i Håndbold 2019 (for herrer): {vmHandball.ToShortDateString()}");
            Console.WriteLine($"Datoen for sommerferien for AspIT elever 2022: {vacation.ToShortDateString()}");
            Console.WriteLine($"Nuværende tidspunkt: {now.ToShortDateString()}");
            Console.WriteLine($"Tidspunkt og dato for starten af social aktivitet næste fredag: {socialActivity.ToShortDateString()}");
            Console.WriteLine($"Hvornår jeg mødte i dag: {arrival.ToLongDateString()}");
            Console.WriteLine($"Hvornår TV AVISEN vises sidste gang på lørdag på DR1: {news.ToShortDateString()}\n");

            Console.WriteLine("-----------------------------------\n\nToString:\n");

            Console.WriteLine($"Min fødselsdato: {myBirth.ToString()}");
            Console.WriteLine($"Dronningens fødselsdato: {queenBirth.ToString()}");
            Console.WriteLine($"Datoen på underskrift af den første Danmarks Riges Grundlov: {grundlov.ToString()}");
            Console.WriteLine($"Datoen for den første kamp i VM i Håndbold 2019 (for herrer): {vmHandball.ToString()}");
            Console.WriteLine($"Datoen for sommerferien for AspIT elever 2022: {vacation.ToString()}");
            Console.WriteLine($"Nuværende tidspunkt: {now.ToString()}");
            Console.WriteLine($"Tidspunkt og dato for starten af social aktivitet næste fredag: {socialActivity.ToString()}");
            Console.WriteLine($"Hvornår jeg mødte i dag: {arrival.ToString()}");
            Console.WriteLine($"Hvornår TV AVISEN vises sidste gang på lørdag på DR1: {news.ToString()}\n");

            Console.WriteLine("\n-----------------------------------");

            Console.ReadLine();
        }
    }
}
