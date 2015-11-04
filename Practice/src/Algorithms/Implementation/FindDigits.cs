using System;

namespace Practice
{
    public class FindDigits
    {
        public void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var n = Console.ReadLine();
                var digits = n.ToCharArray();
                var num = int.Parse(n);

                var count = 0;
                foreach (var digit in digits)
                {
                    var d = int.Parse(digit.ToString());

                    if (d != 0 && num % d == 0)
                    {
                        count++;
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}
