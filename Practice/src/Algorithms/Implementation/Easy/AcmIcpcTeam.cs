/*
*   Sources:
*       http://codereview.stackexchange.com/questions/80458/acm-icpc-team-challenge-on-hackerrank-easy
*       http://stackoverflow.com/questions/5063178/counting-bits-set-in-a-net-bitarray-class/14354311#14354311
*/

using System;
using System.Collections;

namespace Algorithms.Implementation
{
    public class AcmIcpcTeam
    {
        public static void Solve()
        {
            var nm = Console.ReadLine().Split(' ');
            var n = int.Parse(nm[0]);
            var m = int.Parse(nm[1]);

            var topics = new BitArray[n];

            for (int i = 0; i < n; i++)
            {
                topics[i] = new BitArray(m);
                var skills = Console.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    topics[i].Set(j, skills[j] == '1');
                }
            }

            var maxSkills = 0;
            var bestTeams = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var teamSkills = new BitArray(m).Or(topics[i]).Or(topics[j]);
                    var countSkills = CountSetBitsFast(teamSkills);

                    if (countSkills > maxSkills)
                    {
                        maxSkills = countSkills;
                        bestTeams = 1;
                    }
                    else if (countSkills == maxSkills)
                    {
                        bestTeams++;
                    }
                }
            }

            Console.WriteLine(maxSkills);
            Console.WriteLine(bestTeams);
        }

        public static void Solve2()
        {
            var nm = Console.ReadLine().Split(' ');
            var numMembers = int.Parse(nm[0]);
            var numTopics = int.Parse(nm[1]);

            var topicCount = new int[numMembers];
            var memberMatrix = new char[numMembers][];

            var maxTopics = 0;
            var bestTeams = 0;

            for (int member = 0; member < numMembers; member++)
            {
                var skills = Console.ReadLine().ToCharArray();
                var skillCount = CountTopics(skills);

                memberMatrix[member] = skills;
                topicCount[member] = skillCount;

                for (int matchWith = 0; matchWith < member; matchWith++)
                {
                    int common = CountCommon(skills, skillCount, memberMatrix[matchWith], 
                                     topicCount[matchWith], numTopics, maxTopics);

                    if (common >= maxTopics)
                    {
                        if (common > maxTopics)
                        {
                            maxTopics = common;
                            bestTeams = 0;
                        }

                        bestTeams++;
                    }
                }
            }

            Console.WriteLine(maxTopics);
            Console.WriteLine(bestTeams);
        }

        private static int CountCommon(char[] member, int memberTopics, char[] match, int machTopics,
                                       int width, int needTopics)
        {
            int potential = memberTopics + machTopics;
            int count = 0;

            for (int i = 0; i < width && potential >= needTopics; i++)
            {
                if (member[i] == '1' || match[i] == '1')
                {
                    count++;

                    if (member[i] == match[i])
                    {
                        potential--;
                    }
                }
            }

            return count;
        }

        private static int CountTopics(char[] topicMap)
        {
            var count = 0;
            for (int i = 0; i < topicMap.Length; i++)
            {
                if (topicMap[i] != 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountSetBits(BitArray b)
        {
            var count = 0;

            for (int i = 0; i < b.Length; i++)
            {
                count += b.Get(i) ? 1 : 0;
            }

            return count;
        }

        private static int CountSetBitsFast(BitArray b)
        {
            var ints = new int[(b.Count >> 5) + 1];
            b.CopyTo(ints, 0);
            var count = 0;

            // Fix for not truncated bits in last integer that may have been set to true with SetAll()
            ints[ints.Length - 1] &= ~(-1 << (b.Count % 32));

            for (int i = 0; i < ints.Length; i++)
            {
                var c = ints[i];

                // Magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                unchecked
                {
                    c = c - ((c >> 1) & 0x55555555);
                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                }

                count += c;
            }

            return count;
        }
    }
}
