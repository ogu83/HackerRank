using System;
using System.Linq;

namespace MagicSquareForming
{
    public class Main
    {
        public static void Exec()
        {
            var matrix = new int[3, 3];
            var cSum = new int[3];
            var rSum = new int[3];
            var dSum = new int[2];
            var sum = 0;
            var retVal = 0;
            for (int r = 0; r < 3; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < 3; c++)
                {
                    matrix[c, r] = int.Parse(line.Split(' ')[c]);

                    cSum[c] += matrix[c, r];
                    rSum[r] += matrix[c, r];

                    if (r == c)
                        dSum[0] += matrix[c, r];
                    else if (r + c == 4)
                        dSum[1] += matrix[c, r];

                    sum += matrix[c, r];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (cSum[i] == rSum[i])
                    retVal += Math.Abs(cSum[i] - 15);
            }

            Console.WriteLine(retVal);
        }
    }
}
