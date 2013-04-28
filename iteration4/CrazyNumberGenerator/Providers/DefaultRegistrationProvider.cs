using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CrazyNumberGenerator.Pipeline;

[assembly: InternalsVisibleTo("Tests")]

namespace CrazyNumberGenerator.Providers
{
    sealed internal class DefaultRegistrationProvider : IRegistrationItemsProvider
    {
        public DefaultRegistrationProvider() 
        {
        }

        public IList<IOperation<INumberFilter>> Read()
        {
            var items = new List<IOperation<INumberFilter>>();

            items.Add(new CanDivideByTheseAnalyzer(new List<int> { 3, 5 }, "hellogoodbye"));
            items.Add(new CanDivideByAnalyzer(3, "hello"));
            items.Add(new CanDivideByAnalyzer(5, "goodbye"));
            items.Add(new JustOutputTheNumberAnalyzer());

            return items;
        }
    }
}
