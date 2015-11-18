using System;
using System.Text;

namespace Algorithms.Implementation
{
    public class CavityMap
    {
        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());
            var ms = new StringBuilder[n];
            var m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                ms[i] = new StringBuilder(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = int.Parse(ms[i][j].ToString());
                }
            }

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    var p = m[i, j];

                    var cavity =
                        m[i - 1, j] < p &&
                        m[i, j - 1] < p &&
                        m[i, j + 1] < p &&
                        m[i + 1, j] < p;

                    if (cavity)
                    {
                        ms[i][j] = 'X';
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(ms[i]);
            }
        }
    }
}
