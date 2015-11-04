using System;
using System.Text;

namespace Practice
{
    public class Sherlock
    {
        public void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
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
                }
                else
                {
                    fives = n;
                    var num = new StringBuilder();

                    for (int j = 0; j < fives; j++)
                    {
                        num.Append('5');
                    }

                    for (int k = 0; k < threes; k++)
                    {
                        num.Append('3');
                    }

                    Console.WriteLine(num);
                }
            }
        }
    }
}
