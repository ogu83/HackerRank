using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler1
{
    /// <summary>
    /// Project Euler #1: Multiples of 3 and 5
    /// </summary>
    public class Problem1
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                int N = int.Parse(Console.ReadLine());
                BigInteger sum = 0;

                BigInteger p = (N - 1) / 3;
                sum = ((3 * p * (p + 1)) / 2);

                p = (N - 1) / 15;
                sum = sum - ((15 * p * (p + 1)) / 2);

                p = (N - 1) / 5;
                sum = sum + ((5 * p * (p + 1)) / 2);

                Console.WriteLine(sum);
            }
        }
    }
}
