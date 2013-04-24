using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public class LuckyNumber : IOperation<INumberFilter>
    {
        private int _number;
        private string _ifTrue;

        public LuckyNumber(int number, string ifTrue)
        {
            _number = number;
            _ifTrue = ifTrue;
        }

        public string Execute(int i)
        {
            if (i == _number)
                return _ifTrue;

            return null;
        }
    }
}
