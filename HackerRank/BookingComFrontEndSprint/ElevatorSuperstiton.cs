using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingComFrontEndSprint
{
    public class ElevatorSuperstiton
    {
        public static void Exec()
        {
            for (int i = 1; i <= 1000; i++)
            {
                processData(i);
            }
        }

        private static void processData(int input)
        {
            var index = 0;
            var value = 0;
            while (index < input)
            {
                index++;
                while (true)
                {
                    value++;
                    if (!value.ToString().Contains("13") && !value.ToString().Contains("4"))
                        break;
                }
            }
            Console.WriteLine(value);
        }
    }

    public class GpsCoordination
    {

    }
}
