using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace euler1
{
    /// <summary>
    /// Project Euler #8: Largest product in a series
    /// </summary>
    public class Problem8
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                const int INT_MIN = -100000009;
                long k, m, max1 = INT_MIN, ans;
                var lStr = Console.ReadLine();
                m = long.Parse(lStr.Split(' ')[0]);
                k = long.Parse(lStr.Split(' ')[1]);
                var ss = Console.ReadLine();
                for (int i = 0; i < m - k + 1; i++)
                {
                    ans = 1;
                    for (int j = 0; j < k; j++)
                        ans = ans * (ss[i + j] - '0');
                    max1 = Math.Max(ans, max1);
                }
                Console.WriteLine(max1);
            }

        }
    }
}
