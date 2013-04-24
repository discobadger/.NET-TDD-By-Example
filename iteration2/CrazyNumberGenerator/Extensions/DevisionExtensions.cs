using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyNumberGenerator
{
    public static class DevisionExtensions
    {
        public static bool CanDivideBy(this int number, int divider)
        {
            return ((number % divider) == 0);
        }

        public static IEnumerable<bool> CanDivideByMultiple(this int number, IEnumerable<int> dividers)
        {
            foreach (int x in dividers)
            {
                yield return ((number % x) == 0);
            }
        }
    }
}
