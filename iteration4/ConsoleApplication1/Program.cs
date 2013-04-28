using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using CrazyNumberGenerator;
using CrazyNumberGenerator.Pipeline;
using CrazyNumberGenerator.Providers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ServiceLocator.Resolve<IRegistrationItemsProvider>();

            // standard workflow invoked
            var pipe = new CrazyStringGenerator(provider);

            Console.Out.Write("How many?: ");
            var amount = int.Parse(Console.ReadLine());

            foreach (var item in pipe.Execute(amount))
                Console.Out.WriteLine(item);

            Console.ReadKey();

            // Note: on the second call to resolve, based on the (id)registrationItemsProvider component 
            // defaulting to singleton, windsor will not new-up a new instance of LuckyNumberRegistration
            provider = ServiceLocator.Resolve<IRegistrationItemsProvider>();
            pipe = new CrazyStringGenerator(provider);

            foreach (var item in pipe.Execute(amount))
                Console.Out.WriteLine(item);

            Console.ReadKey();

            ServiceLocator.Release(provider);
        }
    }
}
