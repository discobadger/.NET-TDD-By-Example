using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public class CanDivideBy : IOperation<INumberFilter>
    {
        private int _number;
        private string _ifTrue;

        public CanDivideBy(int number, string ifTrue)
        {
            _number = number;
            _ifTrue = ifTrue;
        }

        public string Execute(int i)
        {
            if (i.CanDivideBy(_number))
                return _ifTrue;

            return null;
        }
    }
}
