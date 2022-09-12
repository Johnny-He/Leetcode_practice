using System;

namespace Leetcode
{
    class Leetcode64
    {
        public int MinPathSum(int[,] grid)
        {
            int m = grid.GetLength(0) - 1;
            int n = grid.GetLength(1) - 1;
            for (int i = 1; i <= m; i++)
            {
                grid[i, 0] += grid[i - 1, 0];
            }

            for (int i = 1; i <= n; i++)
            {
                grid[0, i] += grid[0, i - 1];
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    grid[i, j] += Math.Min(grid[i - 1, j], grid[i, j - 1]);
                }
            }

            return grid[m, n];

        }

        public void show(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
