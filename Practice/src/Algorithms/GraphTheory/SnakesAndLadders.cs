using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class SnakesAndLadders
    {
        private const int D = 6;
        private const int N = 100;

        // Solve using Dynamic Programming
        public static void Solution()
        {
            // var t = int.Parse(Console.ReadLine());
            var t = 1;

            while (t-- > 0)
            {
                //// var ladders = ReadCoordinates(int.Parse(Console.ReadLine()));
                //// var snakes = ReadCoordinates(int.Parse(Console.ReadLine()));

                var ladders = new Dictionary<int, int> { { 98, 12 }, { 80, 2 } };
                var snakes = new Dictionary<int, int> { { 81, 11 } };

                var minPath = new int[N + 1];

                for (int i = 2; i <= 7; i++)
                {
                    minPath[i] = 1;
                }

                for (int i = 8; i <= 100; i++)
                {
                    minPath[i] = GetMinPath(i, minPath, ladders);

                    if (snakes.ContainsKey(i))
                    {
                        for (int j = snakes[i]; j <= i; j++)
                        {
                            minPath[j] = GetMinPath(j, minPath, ladders);
                        }
                    }
                }

                Console.WriteLine(minPath[N]);
            }
        }

        //// Breadth-first search

        private static int GetMinPath(int i, IList<int> minPath, IDictionary<int, int> ladders)
        {
            var min = minPath.Skip(i - D).Take(D).Min() + 1;
            return ladders.ContainsKey(i) ? Math.Min(min, minPath[ladders[i]]) : min;
        }

        private static Dictionary<int, int> ReadCoordinates(int count)
        {
            var ret = new Dictionary<int, int>();

            while (count-- > 0)
            {
                var arr = Console.ReadLine().Split(' ');
                var x = int.Parse(arr[0]);
                var y = int.Parse(arr[1]);

                ret.Add(x > y ? x : y, x > y ? y : x);
            }

            return ret;
        }
    }
}
