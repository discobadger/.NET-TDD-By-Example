using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public sealed class OtherwiseJustOutputTheNumber : IOperation<INumberFilter>
    {
        public string Execute(int i)
        {
            return i.ToString();
        }
    }
}
