using System;
using System.Linq;

namespace UptopianTree
{
    public class Main
    {
        public static void Exec()
        {
            int howMany = Convert.ToInt32(Console.ReadLine());
            int[] input = new int[howMany];
            for (int i = 0; i < howMany; i++)
            {
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] result = CalculateGrowth(input);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i].ToString());
            }
        }


        static int[] CalculateGrowth(int[] cycleCounts)
        {
            return cycleCounts.Select(c => CalculateGrowth(c)).ToArray();
        }

        static int CalculateGrowth(int cycleCount)
        {
            var treeHeight = 1;
            var season = true;

            for (int i = 0; i < cycleCount; i++)
            {
                treeHeight = GrowTree(treeHeight, season);
                season = !season;
            }

            return treeHeight;
        }

        static int GrowTree(int initialHeight, bool season)
        {
            return season ? initialHeight * 2 : initialHeight + 1;
        }
    }
}
