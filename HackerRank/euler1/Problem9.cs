using System;

namespace euler1
{
    /// <summary>
    /// Project Euler #9: Special Pythagorean triplet
    /// </summary>
    public class Problem9
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                long N;
                long.TryParse(NN, out N);

                long a;
                long max = -1;
                if (N % 2 == 0)
                    for (a = 1; a <= N / 3; a++)
                    {
                        long b;
                        for (b = a + 1; b <= N / 2; b++)
                        {
                            long c = N - a - b;
                            if (a * a + b * b == c * c)
                                max = Math.Max(max, a * b * c);
                        }
                    }
                Console.WriteLine(max);
            }
        }
    }
}
