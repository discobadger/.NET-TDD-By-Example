using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public class CanDivideByThese : IOperation<INumberFilter>
    {
        private IEnumerable<int> _dividers;
        private string _ifTrue;

        public CanDivideByThese(IEnumerable<int> dividers, string ifTrue)
        {
            _dividers = dividers;
            _ifTrue = ifTrue;
        }

        public string Execute(int i)
        {
            if (!(i.CanDivideByMultiple(_dividers)).Contains(false))
                return _ifTrue;

            return null;
        }
    }
}
