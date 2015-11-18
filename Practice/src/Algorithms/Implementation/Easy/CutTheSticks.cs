using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.Implementation
{
    public class CutTheSticks
    {
        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());
            var sticks = Console.ReadLine().Split(' ');
            var s = new List<int>();

            foreach (var stick in sticks)
            {
                s.Add(int.Parse(stick));
            }
                
            s.Sort();

            while (s.Count > 0)
            {
                Console.WriteLine(s.Count);

                var min = s.First();
                while (s.Count > 0 && s.First() <= min)
                {
                    s.RemoveAt(0);
                }
            }
        }

        public void Solve2()
        {
            var n = int.Parse(Console.ReadLine());
            var sticks = Console.ReadLine().Split(' ');
            var s = new int[sticks.Length];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = int.Parse(sticks[i]);
            }

            Array.Sort(s);

            Console.WriteLine(s.Length);
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != s[i + 1])
                {
                    Console.WriteLine(s.Length - i - 1);
                }
            }
        }
    }
}
