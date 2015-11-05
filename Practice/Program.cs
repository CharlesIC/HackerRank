using System;

namespace Practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
//            var arr = Console.ReadLine().Split(' ');
//
//            var a = ulong.Parse(arr[0]);
//            var b = ulong.Parse(arr[1]);
//            var n = int.Parse(arr[2]);

            decimal a = 0;
            decimal b = 1;
            int n = 10;

            for (var i = 2; i < n; i++)
            {
                var x = a + b * b;
                a = b;
                b = x;
            }

            Console.WriteLine(b);
        }
    }
}
