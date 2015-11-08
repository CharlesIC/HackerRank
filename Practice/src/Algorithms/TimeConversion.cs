using System;

namespace Practice
{
    public class TimeConversion
    {
        // Custom time conversion logic
        public static void Solution()
        {
            var time = Console.ReadLine();
            var nums = time.Split(':');

            var h = int.Parse(nums[0]);
            var m = int.Parse(nums[1]);
            var s = int.Parse(nums[2].Remove(nums[2].Length - 2));

            // 12:00AM - 12:59AM --> 00:00 - 00:59
            if (time.EndsWith("AM") && h >= 12)
            {
                h -= 12;
            }

            // 01:00AM - 12:59AM --> 01:00 - 12:59

            // 01:00PM - 11:59PM --> 13:00 - 23:59
            if (time.EndsWith("PM") && h < 12)
            {
                h += 12;
            }

            Console.WriteLine("{0:00}:{1:00}:{2:00}", h, m, s);
        }


        // Use built-in methods
        public static void Solution2()
        {
            var time = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(time.ToString("HH:mm:ss"));
        }
    }
}
