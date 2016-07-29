using System;
using System.Linq;

namespace CutTheSticks
{
    public class Main
    {
        public static void Exec()
        {
            var count = long.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(x => long.Parse(x));
            Console.WriteLine(count);
            if (numbers.Count() == count)
                while (count > 1)
                {
                    var minNumber = numbers.Min();
                    numbers = numbers.Select(x => Math.Abs(x - minNumber)).Where(y => y > 0);
                    if (numbers.Count() >= count)
                        break;
                    count = numbers.Count();
                    if (count > 0)
                        Console.WriteLine(count);
                }
        }
    }
}
