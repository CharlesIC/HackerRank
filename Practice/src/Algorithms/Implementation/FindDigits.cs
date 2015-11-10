using System;

namespace Algorithms
{
    using System.Linq;

    public class FindDigits
    {
        public void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            for (var i = 0; i < t; i++)
            {
                var n = Console.ReadLine();
                var digits = n.ToCharArray();
                var num = int.Parse(n);
                var count = digits.Select(digit => int.Parse(digit.ToString())).Count(d => d != 0 && num % d == 0);

                Console.WriteLine(count);
            }
        }
    }
}
