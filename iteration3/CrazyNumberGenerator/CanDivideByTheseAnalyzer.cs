using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    class CanDivideByTheseAnalyzer : IOperation<INumberFilter>, IAnalyzer
    {
        private IEnumerable<int> _dividers;
        private string _ifTrue;

        public CanDivideByTheseAnalyzer(IEnumerable<int> dividers, string ifTrue)
        {
            _dividers = dividers;
            _ifTrue = ifTrue;
        }

        public string Execute(int i)
        {
            if (i.CanDivideBy(_dividers))
                return _ifTrue;

            return null;
        }
    }
}
