using System;
using System.Text;

namespace Algorithms
{
    public class Sherlock
    {
        public static void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            for (var i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());

                var threes = 0;
                var fives = 0;

                while (n % 3 != 0 && n > 2)
                {
                    threes += 5;
                    n -= 5;
                }

                if (n % 3 != 0)
                {
                    Console.WriteLine(-1);
                    continue;
                }

                fives = n;
                var num = new StringBuilder();

                for (var j = 0; j < fives; j++)
                {
                    num.Append('5');
                }

                for (var k = 0; k < threes; k++)
                {
                    num.Append('3');
                }

                Console.WriteLine(num);
            }
        }

        public static void Solution2()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var n = int.Parse(Console.ReadLine());
                var fives = MaxFivesIn(n);

                if (fives == -1)
                {
                    Console.WriteLine(fives);
                    continue;
                }

                for (var i = 0; i < fives; i++)
                {
                    Console.Write(555);
                }

                var threes = (n - (3 * fives)) / 5;
                for (var i = 0; i < threes; i++)
                {
                    Console.Write(33333);
                }

                Console.WriteLine();
            }
        }

        private static int MaxFivesIn(int n)
        {
            var x = 0;
            for (; n >= 5 * x; x++)
            {
                var y = n - (5 * x);

                if (y % 3 == 0)
                {
                    return y / 3;
                }
            }

            return -1;
        }
    }
}
