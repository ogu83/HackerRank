using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make10Bubbles
{
    public class Main
    {
        public static void Exec()
        {
            var rnd = new Random();
            const int maxBubbleCount = 1000;
            var bubbles = new int[maxBubbleCount];
            var hint = new bool[maxBubbleCount];
            for (int i = 0; i < maxBubbleCount; i++)
                bubbles[i] = rnd.Next(9) + 1;

            Stopwatch s = new Stopwatch();
            s.Start();
            hint1(bubbles, hint);
            s.Stop();
            Console.WriteLine("hint1 : " + s.ElapsedTicks + " ms");
            Console.WriteLine(hint.Count(x => x));
            //for (int i = 0; i < maxBubbleCount; i++)
            //    Console.WriteLine("{0} {1}", bubbles[i], hint[i]);


            //hint = new bool[maxBubbleCount];
            //s.Restart();
            //hint2(bubbles, hint);
            //s.Stop();
            //Console.WriteLine("hint2 : " + s.ElapsedTicks + " ms");
            //Console.WriteLine(hint.Count(x => x));
            //for (int i = 0; i < maxBubbleCount; i++)
            //    Console.WriteLine("{0} {1}", bubbles[i], hint[i]);
        }

        private static void hint2(int[] bubbles, bool[] hint)
        {
            for (int i = 0; i < bubbles.Length; i++)
            {
                if (hint[i]) continue;
                var b = bubbles[i];
                hint[i] = hint2Sub(bubbles, hint, b, i);
            }
        }

        private static bool hint2Sub(int[] bubbles, bool[] hint, int b, int i)
        {
            for (int j = 0; j < bubbles.Length; j++)
            {
                if (hint[j] || i == j) continue;
                var bb = bubbles[j];
                if (bb + b == 10)
                {
                    hint[j] = true;
                    return true;
                }
                else if (bb + b < 10)
                {
                    return hint2Sub(bubbles, hint, bb + b, j);
                }
                else
                    return false;
            }
            return false;
        }

        private static void hint1(int[] bubbles, bool[] hint)
        {
            for (int i = 0; i < bubbles.Length; i++)
            {
                var b = bubbles[i];
                for (int j = 0; j < bubbles.Length; j++)
                {
                    if (i == j) continue;
                    if (hint[i] || hint[j]) continue;
                    var bb = bubbles[j];
                    if (bb + b == 10)
                    {
                        hint[i] = true;
                        hint[j] = true;
                    }
                }
            }

            for (int i = 0; i < bubbles.Length; i++)
            {
                var b = bubbles[i];
                for (int j = 0; j < bubbles.Length; j++)
                {
                    if (i == j) continue;
                    if (hint[i] || hint[j]) continue;
                    var bb = bubbles[j];
                    for (int k = 0; k < bubbles.Length; k++)
                    {
                        if (i == j || j == k || i == k) continue;
                        if (hint[i] || hint[j] || hint[k]) continue;
                        var bbb = bubbles[k];
                        if (bbb + bb + b == 10)
                        {
                            hint[i] = true; 
                            hint[j] = true; 
                            hint[k] = true;
                        }
                    }
                }
            }
        }
    }
}
