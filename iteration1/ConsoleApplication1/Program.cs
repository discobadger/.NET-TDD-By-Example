using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var csg = new CrazyStringGenerator();

            foreach (var item in csg.Process(100))
                Console.Out.WriteLine(item);

            Console.ReadKey();
        }
    }

    public class CrazyStringGenerator
    {
        public IList<string> Process(int total)
        {
            int x = 1;
            var items = new List<string>();

            while (x < (total + 1))
            {
                items.Add(Filter(x));
                x++;
            }

            return items;
        }

        public string Filter(int i)
        {
            if (!(i.CanDivideByMultiple(new List<int> { 3, 5 })).Contains(false))
                return "hellogoodbye";
            if (i.CanDivideBy(3))
                return "hello";
            if (i.CanDivideBy(5))
                return "goodbye";

            return i.ToString();
        }
    }

    public static class MyExtensions
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
