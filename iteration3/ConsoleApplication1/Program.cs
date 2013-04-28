using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyNumberGenerator;
using CrazyNumberGenerator.Pipeline;
using CrazyNumberGenerator.Providers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // standard workflow invoked
            var pipe = new CrazyStringGenerator();

            Console.Out.Write("How many?: ");
            var amount = int.Parse(Console.ReadLine());

            foreach (var item in pipe.Execute(amount))
                Console.Out.WriteLine(item);


            // Re-use existing code for another use-case
            pipe = new CrazyStringGenerator(new LuckyNumberRegistation());

            Console.Out.Write("How many?: ");
            amount = int.Parse(Console.ReadLine());

            foreach (var item in pipe.Execute(amount))
                Console.Out.WriteLine(item);
        }
    }
}
