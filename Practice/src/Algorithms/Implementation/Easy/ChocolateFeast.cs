using System;

namespace Algorithms.Implementation
{
    public class ChocolateFeast
    {
        public static void Solve()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var ncm = Console.ReadLine().Split(' ');
                var n = int.Parse(ncm[0]);
                var c = int.Parse(ncm[1]);
                var m = int.Parse(ncm[2]);
                var w = 0;
                var total = 0;

                while (n >= c || w >= m)
                {
                    var buy = n / c;
                    n -= buy * c;
                    w += buy;
                    total += buy;

                    var swap = w / m;
                    w += swap * (1 - m);
                    total += swap;
                }

                Console.WriteLine(total);
            } 
        }

        public static void Solve2()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var ncm = Console.ReadLine().Split(' ');
                var n = int.Parse(ncm[0]);
                var c = int.Parse(ncm[1]);
                var m = int.Parse(ncm[2]);

                var wrappers = n / c;
                int remaining = wrappers;
                int total = wrappers;

                while (remaining >= m)
                {
                    total += (remaining / m);
                    remaining = remaining / m + remaining % m;
                }

                Console.WriteLine(total);
            }
        }

        public static void Solve3()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var ncm = Console.ReadLine().Split(' ');
                var n = int.Parse(ncm[0]);
                var c = int.Parse(ncm[1]);
                var m = int.Parse(ncm[2]);

                var b = n / c;
                var total = b + (b - 1) / (m - 1);

                Console.WriteLine(total);
            }
        }
    }
}
