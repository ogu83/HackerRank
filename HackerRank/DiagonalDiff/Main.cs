using System;
using System.Linq;

namespace DiagonalDiff
{
    public class Main
    {
        public static void Exec()
        {
            //var rowCount = 3;
            //matrix[0] = 11;
            //matrix[1] = 2;
            //matrix[2] = 4;
            //matrix[3] = 4;
            //matrix[4] = 5;
            //matrix[5] = 6;
            //matrix[6] = 10;
            //matrix[7] = 8;
            //matrix[8] = -12;

            var rowCount = int.Parse(Console.ReadLine());
            var matrix = new int[rowCount * rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                var line = Console.ReadLine();
                var row = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int r = 0; r < row.Count(); r++)
                    matrix[r + (i * rowCount)] = row[r];
            }


            int sum0 = 0;
            for (int i = 0; i < matrix.Length; i += (rowCount + 1))
                sum0 += matrix[i];

            int sum1 = 0;
            for (int i = matrix.Length - (rowCount); i > 0; i -= (rowCount - 1))
                sum1 += matrix[i];

            var result = Math.Abs(sum1 - sum0);
            Console.WriteLine(result);

        }
    }
}
