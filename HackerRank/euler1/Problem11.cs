using System;

namespace euler1
{
    /// <summary>
    /// Project Euler #11: Largest product in a grid
    /// </summary>
    public class Problem11
    {
        public static void Exec()
        {
            const int iRow = 20;
            var grid = new int[iRow, iRow];
            for (int r = 0; r < iRow; r++)
            {
                var line = Console.ReadLine();
                var lineArr = line.Split(' ');
                for (int c = 0; c < iRow; c++)
                    grid[r, c] = int.Parse(lineArr[c]);
            }

            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var greatest = 0;
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < columns; c++)
                {
                    if (c < columns - 3)
                    {
                        // Right and "Left"
                        greatest = Math.Max(greatest, grid[r, c] * grid[r, c + 1] * grid[r, c + 2] * grid[r, c + 3]);
                    }

                    if (r < rows - 3)
                    {
                        // Down and "Up"
                        greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c] * grid[r + 2, c] * grid[r + 3, c]);
                        // Diagonally, down to the right
                        if (c < columns - 3)
                            greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c + 1] * grid[r + 2, c + 2] * grid[r + 3, c + 3]);
                        // Diagonally, down to the left
                        if (c > 3)
                            greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c - 1] * grid[r + 2, c - 2] * grid[r + 3, c - 3]);
                    }
                }
            var answer = greatest;
            Console.WriteLine(answer);
        }
    }
}
