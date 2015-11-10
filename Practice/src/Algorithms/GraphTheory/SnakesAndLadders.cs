using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class SnakesAndLadders
    {
        private const int D = 6;
        private const int N = 100;

        //var ladders = new Dictionary<int, int> { { 98, 21 } };
        //var snakes = new Dictionary<int, int> { { 13, 8 }, { 15, 6 }, { 16, 5 }, { 18, 3 }, { 17, 4 }, { 12, 9 }, { 14, 7 } };

        // Solve using Dynamic Programming
        public static void SolutionDp()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var minPath = new int[N + 1];

                for (var i = 2; i <= 7; i++)
                {
                    minPath[i] = 1;
                }

                var ladders = ReadCoordinates(int.Parse(Console.ReadLine()));
                var snakes = ReadCoordinates(int.Parse(Console.ReadLine()));

                for (var i = 8; i <= 100; i++)
                {
                    var shortestPath = GetMinPath(i, minPath, ladders, snakes);

                    // Terminate this test case and return -1
                    if (shortestPath == -1)
                    {
                        i = 100;
                        minPath[i] = -1;
                        continue;
                    }

                    minPath[i] = shortestPath;

                    // If this square has a snake head, we need to go to the tail and
                    // update the shortest path for all squares up to the current one
                    if (snakes.ContainsKey(i))
                    {
                        var y = snakes[i];
                        minPath[y] = Math.Min(minPath[y], minPath[i]);

                        for (var j = y + 1; j <= i; j++)
                        {
                            minPath[j] = GetMinPath(j, minPath, ladders, snakes);
                        }
                    }
                }

                Console.WriteLine(minPath[N]);
            }
        }

        // Solve using Breadth-first Search
        public static void SolutionBfs()
        {
             var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                
            }
        }

        private static int GetMinPath(int i, IList<int> minPath, IDictionary<int, int> ladders, IDictionary<int, int> snakes)
        {
            // Eliminate squares with snake heads
            var precedingSquares = minPath.Skip(i - D).Take(D).Where((path, idx) => !snakes.ContainsKey(i - D + idx)).ToList();

            if (precedingSquares.Count == 0)
            {
                return -1;
            }

            // Choose to jump from a preceding square or use a ladder if one exists
            var min = precedingSquares.Min() + 1;
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
