using System;
using System.Linq;

namespace Algorithms.Implementation
{
    public class ServiceLane
    {
        public static void Solve()
        {
            var nt = Console.ReadLine().Split(' ');
            var t = int.Parse(nt[1]);
            var serviceLane = Console.ReadLine().Split(' ');
            var sl = new int[serviceLane.Length];

            for (int i = 0; i < serviceLane.Length; i++)
            {
                sl[i] = int.Parse(serviceLane[i]);
            }

            while (t-- > 0)
            {
                var ij = Console.ReadLine().Split(' ');
                var i = int.Parse(ij[0]);
                var j = int.Parse(ij[1]);

                Console.WriteLine(sl.Skip(i).Take(j - i + 1).Min());
            }
        }


        /*
        * Store the index positions of occurance of 1, 2, 3 in an array
        * Perform a binary search to see if there is occurance of 1 in between i and j
        * then if 1 is not there check for 2 otherwise 1 is the ans
        * if 2 is there then 2 is the ans
        * if 1 and 2 are not there then only 3 is possible
        */
        public static void Solve2()
        {
            var nt = Console.ReadLine().Split(' ');

            var n = int.Parse(nt[0]);
            var t = int.Parse(nt[1]);

            var a1 = new int[n];
            var a2 = new int[n];

            var max1 = 0;
            var max2 = 0;

            var s = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                var val = int.Parse(s[i]);

                if (val == 1)
                {
                    a1[max1++] = i;
                }
                else if (val == 2)
                {
                    a2[max2++] = i;
                }
            }
                
            for (int k = 0; k < t; k++)
            {
                var ij = Console.ReadLine().Split(' ');
                var i = int.Parse(ij[0]);
                var j = int.Parse(ij[1]);

                if (Find(a1, max1, i, j))
                {
                    Console.WriteLine(1);
                }
                else if (Find(a2, max2, i, j))
                {
                    Console.WriteLine(2);
                }
                else
                {
                    Console.WriteLine(3);
                }
            }

        }

        public static bool Find(int[] a, int max, int start, int stop)
        {
            if (max <= 0)
            {
                return false;
            }

            var low = 0;
            var high = max - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (a[mid] == stop || (a[mid] >= start && a[mid] < stop))
                {
                    return true;
                }
                else if (a[mid] < start)
                {
                    low = mid + 1;
                }
                else if (a[mid] > stop)
                {
                    high = mid - 1;
                }
            }

            return false;
        }
    }
}
