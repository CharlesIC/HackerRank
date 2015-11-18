using System;
using System.Linq;

namespace Algorithms.Implementation
{
    public class TaumBday
    {
        public static void Solve()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var bw = Console.ReadLine().Split(' ').Select(a => decimal.Parse(a)).ToArray();
                var xyz = Console.ReadLine().Split(' ').Select(a => decimal.Parse(a)).ToArray();

                var black = bw[0];
                var white = bw[1];
                var x = xyz[0];
                var y = xyz[1];
                var z = xyz[2];

                var priceBlack = Math.Min(x, y + z);
                var priceWhite = Math.Min(y, x + z);

                var total = priceWhite * white + priceBlack * black;

                Console.WriteLine(total);
            }
        }
    }
}
