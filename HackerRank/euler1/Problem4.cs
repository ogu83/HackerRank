using System;

namespace euler1
{
    /// <summary>
    /// Project Euler #4: Largest palindrome product
    /// </summary>
    public class Problem4
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                long N;
                long.TryParse(NN, out N);

                for (long n = N-1; n >= 101101; n--)
                {
                    bool isAnswer = false;
                    if (palindrome(n))
                    {
                        for (int i = 100; i < 1000; i++)
                        {
                            if (n % i == 0 && n / i > 99 && n / i < 1000)
                            {
                                isAnswer = true;
                                Console.WriteLine(n);
                                break;
                            }
                        }
                        if (isAnswer)
                            break;
                    }
                }
            }
        }

        public static long reverse(long n)
        {
            long r, s = 0;
            while (n > 0)
            {
                r = n % 10;
                n /= 10;
                s = s * 10 + r;
            }
            return s;
        }

        public static bool palindrome(long n)
        {
            return n == reverse(n);
        }
    }
}