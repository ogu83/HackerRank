using System;
using System.Linq;

namespace CamelCase
{
    public class Main
    {
        public static void Exec()
        {
            string s = Console.ReadLine();
            int i1 = 0;
            int r = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if ((s[i].ToString() == s[i].ToString().ToUpper() 
                    && s[i-1].ToString() == s[i-1].ToString().ToLower())
                        || i == s.Length - 1)
                {                    
                    r++;
                }
            }
            Console.WriteLine(r);
        }
    }
}
