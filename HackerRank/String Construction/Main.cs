using System;
using System.Linq;

namespace String_Construction
{
    public class Main
    {
        public static void Exec()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < n; a0++)
            {
                string s = Console.ReadLine();
                int cost = 0;
                for (int i = 1; i <= s.Length; i++)
                {
                    cost++;
                    var p = s.Substring(0, i);
                    var subStrings = PossibleUniqueSubString(p).OrderByDescending(x => x.Length).ToArray();
                    foreach (var ss in subStrings)
                    {
                        var pSS = p + ss;
                        if (ss.Length + i <= s.Length)
                        {
                            var pSS1 = s.Substring(0, i + ss.Length);
                            if (pSS == pSS1)
                            {
                                i += ss.Length;                                
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(cost);
            }
        }

        public static string[] PossibleUniqueSubString(string input)
        {
            string final = "";
            for (int i = 0; i < input.Length; i++)
            {
                string str = "";
                for (int j = i; j < input.Length; j++)
                {
                    str += input[j];
                    final += str + ",";
                }
            }
            final = final.Remove(final.Length - 1, 1);
            string[] arr = final.Split(',');
            arr = arr.Distinct().ToArray();
            return arr;
        }
    }
}
