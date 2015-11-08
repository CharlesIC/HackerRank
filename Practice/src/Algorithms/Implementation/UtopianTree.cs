/*
* 
* Notes:
*   I solved this by skethcing a graph of the tree height and noticing that it much
*   resembled the graph of 2^x. Then, I dervied the equation ralating n (the number of
*   years) to x, and another one for the actual height once the power of two is known.
* 
*/

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
