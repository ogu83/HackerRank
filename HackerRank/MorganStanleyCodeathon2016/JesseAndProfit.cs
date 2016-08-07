using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MorganStanleyCodeathon2016
{
    public class JesseAndProfit
    {
        public static void Exec()
        {
            var NDLine = Console.ReadLine();
            var N = int.Parse(NDLine.Split(' ')[0]);
            var D = int.Parse(NDLine.Split(' ')[1]);

            var dayLine = Console.ReadLine();
            var Ns = dayLine.Split(' ').Select(x => int.Parse(x)).ToArray();
            var NsDict = new Dictionary<int, int>();
            for (int i = 0; i < Ns.Count(); i++)
                NsDict.Add(i, Ns[i]);

            var NsDictO = NsDict.OrderBy(x => x.Value).ToArray();
            for (int i = 0; i < D; i++)
            {
                var d = int.Parse(Console.ReadLine());
                try
                {
                    var result = NsDictO.Select(x => new int[] { x.Key + 1, NsDictO.FirstOrDefault(y => y.Value - x.Value == d).Key + 1 })
                        .ToArray()
                        .Where(a => a[0] < a[1]).OrderBy(a1 => a1[1] - a1[0]).First();

                    Console.WriteLine("{0} {1}", result[0], result[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(-1);
                }
            }
        }
    }    
}
