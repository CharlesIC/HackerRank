using System;

namespace Practice
{
    public class UtopianTree
    {
        public void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());

                var pow = (n + (n % 2)) / 2 + 1;
                var upper = Math.Pow(2, pow);

                Console.WriteLine(upper - 1 - (n % 2));
            }
        }
    }
}
