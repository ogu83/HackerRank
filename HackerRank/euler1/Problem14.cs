using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace euler1
{
    /// <summary>
    /// Project Euler #14: Longest Collatz sequence
    /// </summary>
    public class Problem14
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            var cache = new Dictionary<int, int>();
            var rArr = new int[row];

            Stopwatch watch = new Stopwatch();
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                int N;
                int.TryParse(NN, out N);
                rArr[r] = N;
            }

            watch.Start();

            for (int r = 0; r < row; r++)
            {
                var N = rArr[r];

                var result = 0;
                var lcc = 0;
                for (int n = N; n > N * .5; n--)
                {
                    var cc = collatzCount(n, cache);
                    if (cc > lcc)
                    {
                        result = n;
                        lcc = cc;
                    }
                }
                Console.WriteLine(result);
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds + " ms");
        }

        static int collatzCount(int n, Dictionary<int, int> cache)
        {
            var fn = n;
            var c = 0;
            if (!cache.TryGetValue(n, out c))
            {
                while (n > 1)
                {
                    if (cache.ContainsKey(n))
                    {
                        c += cache[n];
                        break;
                    }
                    c++;
                    if (n % 2 == 0)
                        n >>= 1;
                    else
                        n = 3 * n + 1;
                }
                cache.Add(fn, c);
            }
            return c;
        }
    }
}