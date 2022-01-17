using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime rightNow = DateTime.Now;
            DateTime today = DateTime.Today;
            DateTime utcNow = DateTime.UtcNow;

            Console.WriteLine($"Lige nu: {rightNow}");
            Console.WriteLine($"I dag: {today}");
            Console.WriteLine($"Lige nu i UTC tidszonen: {utcNow}\n");

            rightNow = rightNow.AddYears(1);
            Console.WriteLine($"a. {rightNow}");

            rightNow = rightNow.AddYears(-2);
            Console.WriteLine($"b. {rightNow}");

            rightNow = rightNow.AddDays(30);
            Console.WriteLine($"c. {rightNow}");

            rightNow = rightNow.AddDays(-17);
            Console.WriteLine($"d. {rightNow}");

            rightNow = rightNow.AddMonths(3);
            Console.WriteLine($"e. {rightNow}");

            rightNow = rightNow.AddMonths(-7);
            Console.WriteLine($"f. {rightNow}");

            rightNow = rightNow.AddHours(23);
            Console.WriteLine($"g. {rightNow}");

            rightNow = rightNow.AddHours(-11);
            Console.WriteLine($"h. {rightNow}");

            rightNow = rightNow.AddHours(23);
            rightNow = rightNow.AddMinutes(17);
            Console.WriteLine($"i. {rightNow}\n");

            DateTime now = DateTime.Now;
            DateTime date = now.Date;

            Console.WriteLine(now);
            Console.WriteLine(date);

            Console.ReadLine();
        }
    }
}
