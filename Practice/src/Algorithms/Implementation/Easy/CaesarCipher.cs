using System;
using System.Text;

namespace Algorithms.Implementation
{
    public class CaesarCipher
    {
        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            var k = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    var a = char.IsUpper(s[i]) ? 'A' : 'a';
                    sb.Append((char)(a + ((s[i] - a + k) % 26)));
                }
                else
                {
                    sb.Append(s[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
