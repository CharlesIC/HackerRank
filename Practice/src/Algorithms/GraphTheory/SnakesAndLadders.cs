using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice
{
    public static class SnakesAndLadders
    {
        private const int d = 6;
        private const int n = 100;

        // Solve using Dynamic Programming
        public static void Solution()
        {
//            var t = int.Parse(Console.ReadLine());
            var t = 1;

            while (t-- > 0)
            {
//                var ladders = ReadCoordinates(int.Parse(Console.ReadLine()));
//                var snakes = ReadCoordinates(int.Parse(Console.ReadLine()));

                var ladders = new Dictionary<int, int>();
                ladders.Add(98, 12);
                ladders.Add(80, 2);

                var snakes = new Dictionary<int, int>();
                snakes.Add(81, 11);

                var minPath = new int[n + 1];

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

                Console.WriteLine(minPath[n]);
            }
        }

        // Breadth-first search

        private static int GetMinPath(int i, IList<int> minPath, IDictionary<int, int> ladders)
        {
            var min = minPath.Skip(i - d).Take(d).Min() + 1;
            return ladders.ContainsKey(i) ? Math.Min(min, minPath[ladders[i]]) : min;
        }

        private static Dictionary<int, int> ReadCoordinates(int count)
        {
            var ret = new Dictionary<int, int>();

            while (count-- > 0)
            {
                var arr = Console.ReadLine().Split(' ');
<<<<<<< HEAD
                var x = int.Parse(arr[0]);
                var y = int.Parse(arr[1]);

                ret.Add(x > y ? x : y, x > y ? y : x);
=======
                ret.Add(new Tuple<int, int>(int.Parse(arr[0]), int.Parse(arr[1])));
>>>>>>> origin/master
            }

            return ret;
        }
    }
}
