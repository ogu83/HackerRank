using System;
using System.Numerics;

namespace euler1
{
    /// <summary>
    /// Project Euler #13: Large sum    
    /// </summary>
    public class Problem13
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            BigInteger sum = 0;
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                BigInteger N;
                BigInteger.TryParse(NN, out N);
                sum += N;
            }
            Console.WriteLine(sum.ToString().Length > 10 ? sum.ToString().Substring(0, 10) : sum.ToString());
        }
    }
}
