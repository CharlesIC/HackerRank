using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.GraphTheory
{
    public static class SnakesAndLadders
    {
        private const int D = 6;
        private const int N = 100;

        public static void Solve()
        {
            foreach (var inputs in ReadInput())
            {
                Console.WriteLine(SolveDp(inputs[0], inputs[1]));
            }
        }

        // Solve using Dynamic Programming
        public static int SolveDp(IDictionary<int, int> snakes, IDictionary<int, int> ladders)
        {
            // Reverse keys and values
            ladders = ladders.ToDictionary(l => l.Value, l => l.Key);

            var minPath = new int[N + 1];

            for (int i = 2; i <= D + 1; i++)
            {
                minPath[i] = 1;
            }

            for (int i = D + 2; i <= N; i++)
            {
                var shortestPath = GetMinPath(i, minPath, ladders, snakes);

                // Terminate this test case and return -1
                if (shortestPath == -1)
                {
                    return -1;
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

            return minPath[N];
        }

        // Solve using Breadth-first Search
        public static int SolveBfs(IDictionary<int, int> snakes, IDictionary<int, int> ladders)
        {
            var marked = new HashSet<int>();
            var queue = new Queue<Square>();
            queue.Enqueue(new Square{ Position = 1, Rolls = 0 });

            while (queue.Count > 0)
            {
                var square = queue.Dequeue();

                if (square.Position == 100)
                {
                    return square.Rolls;
                }

                if (marked.Contains(square.Position))
                {
                    continue;
                }

                for (int i = 1; i <= D; i++)
                {
                    queue.Enqueue(new Square
                        { 
                            Position = MoveToSquare(square.Position, square.Position + i, snakes, ladders), 
                            Rolls = square.Rolls + 1
                        });
                }

                marked.Add(square.Position);
            }

            return -1;
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

        private static int MoveToSquare(int current, int next, IDictionary<int, int> snakes, IDictionary<int, int> ladders)
        {
            if (snakes.ContainsKey(next))
            {
                return snakes[next];
            }

            if (ladders.ContainsKey(next))
            {
                return ladders[next];
            }

            if (next > N)
            {
                return current;
            }

            return next;
        }

        private static IEnumerable<IList<IDictionary<int, int>>> ReadInput()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var ladders = new Dictionary<int, int>();
                var snakes = new Dictionary<int, int>();

                var l = int.Parse(Console.ReadLine());
                for (int i = 0; i < l; i++)
                {
                    var arr = Console.ReadLine().Split(' ');
                    ladders.Add(int.Parse(arr[0]), int.Parse(arr[1]));
                }

                var s = int.Parse(Console.ReadLine());
                for (int i = 0; i < s; i++)
                {
                    var arr = Console.ReadLine().Split(' ');
                    snakes.Add(int.Parse(arr[0]), int.Parse(arr[1]));
                }

                yield return new[] { snakes, ladders };
            }
        }

        private class Square
        {
            public int Position;
            public int Rolls;
        }
    }
}
