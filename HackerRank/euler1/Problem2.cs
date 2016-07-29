using System;
using System.Numerics;

namespace euler1
{
    public class Problem2
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                BigInteger N;
                BigInteger.TryParse(NN, out N);

                BigInteger pF = 1;
                BigInteger f = 2;
                BigInteger sum = 0;
                while (f < N)
                {
                    if (f % 2 == 0)
                        sum += f;

                    var ff = f;
                    f = f + pF;
                    pF = ff;
                }
                Console.WriteLine(sum);
            }
        }
    }
}
