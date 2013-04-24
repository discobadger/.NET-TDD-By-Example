using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyNumberGenerator;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipe = new CrazyStringGenerator();

            Console.Out.Write("How many?: ");
            var amount = int.Parse(Console.ReadLine());

            foreach (var item in pipe.Execute(amount))
                Console.Out.WriteLine(item);
        }
    }
}
