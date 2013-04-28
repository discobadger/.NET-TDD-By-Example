using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyNumberGenerator;
using CrazyNumberGenerator.Pipeline;

namespace ConsoleApplication1
{
    class LuckyNumberAnalyzer : IOperation<INumberFilter>, IAnalyzer
    {
        private int _number;
        private string _ifTrue;

        public LuckyNumberAnalyzer(int number, string ifTrue)
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
