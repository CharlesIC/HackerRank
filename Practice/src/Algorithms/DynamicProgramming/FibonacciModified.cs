using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public class FibonacciModified
    {
        public void Solution()
        {
            var arr = Console.ReadLine().Split(' ');

            var a = BigInteger.Parse(arr[0]);
            var b = BigInteger.Parse(arr[1]);
            var n = int.Parse(arr[2]);

            var res = new BigInteger(0);

            for (var i = 2; i < n; i++)
            {
                res = a + (b * b);
                a = b;
                b = res;
            }

            DisplayBigInt(res);
        }


        // The built-in ToString logic for BitInteger is too slow
        // This method chops the big int up into smaller pices to speed it up
        private static void DisplayBigInt(BigInteger n)
        {
            const int SplitLimit = 1024;

            var ans = new List<BigInteger>();
            var p10 = BigInteger.Pow(10, SplitLimit);
            var fmt = new string('0', SplitLimit);

            while (n != 0)
            {
                ans.Add(n % p10);
                n /= p10;
            }

            Console.Write(ans[ans.Count - 1]);

            for (var i = ans.Count - 2; i >= 0; i--)
            {
                var str = ans[i].ToString();
                Console.Write("{0}{1}", fmt.Substring(0, SplitLimit - str.Length), str);
            }

            Console.WriteLine();
        }

        // Too slow
        private static StringBuilder GetBigIntString(BigInteger n)
        {
            const int SplitLimit = 1024;

            var sb = new StringBuilder();
            var ans = new List<BigInteger>();
            var p10 = BigInteger.Pow(10, SplitLimit);

            while (n != 0)
            {
                ans.Add(n % p10);
                n /= p10;
            }

            sb.Append(ans[ans.Count - 1]);

            var fmt = new string('0', SplitLimit);

            for (var i = ans.Count - 2; i >= 0; i--)
            {
                var str = ans[i].ToString();
                sb.Append(string.Format("{0}{1}", fmt.Substring(0, SplitLimit - str.Length), str));
            }

            return sb;
        }
    }
}
