using System;
using System.Collections.Generic;

namespace Practice
{
    public class SnakesAndLadders
    {
        public static void Solution()
        {
            var t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                var ladders = ReadCoordinates(int.Parse(Console.ReadLine()));
                var snakes = ReadCoordinates(int.Parse(Console.ReadLine()));


            }
        }

        private static List<Tuple<int, int>> ReadCoordinates(int n)
        {
            var ret = new List<Tuple<int, int>>();

            while (n-- > 0)
            {
                var arr = Console.ReadLine().Split(' ');
                ret.Add(new Tuple<int, int>(int.Parse(arr[0]), int.Parse(arr[1])));
            }

            return ret;
        }
    }
}
