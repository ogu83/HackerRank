using System;
using System.Numerics;

namespace euler1
{
    /// <summary>
    /// Project Euler #6: Sum square difference   
    /// </summary>
    public class Problem6
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                int N;
                int.TryParse(NN, out N);

                long squareSum = 0;
                long sum = 0;
                for (int i = 1; i < N + 1; i++)
                {
                    squareSum += i * i;
                    sum += i;
                }
                sum *= sum;
                Console.WriteLine(sum-squareSum);
            }
        }
    }
}
