using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator;
using CrazyNumberGenerator.Pipeline;
using CrazyNumberGenerator.Providers;

namespace ConsoleApplication1
{
    class LuckyNumberRegistation : IRegistrationItemsProvider
    {
        public IList<IOperation<INumberFilter>> Read()
        {
            var items = new List<IOperation<INumberFilter>>();
            items.Add(new LuckyNumberAnalyzer(7, "LUCKY NUMBER SLEVEN!"));
            items.Add(new JustOutputTheNumberAnalyzer());
            return items;
        }
    }
}