using System;
using System.Linq;

namespace Algorithms.Implementation
{
    public class LibraryFine
    {
        public static void Solve()
        {
            var r = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var e = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var fine = 0;

            if (r[2] != e[2])
            {
                if (r[2] > e[2])
                {
                    fine = 10000;
                }
            }
            else if (r[1] != e[1])
            {
                fine = Math.Max(0, r[1] - e[1]) * 500;
            }
            else
            {
                fine = Math.Max(0, r[0] - e[0]) * 15;
            }

            Console.WriteLine(fine);
        }
    }
}
