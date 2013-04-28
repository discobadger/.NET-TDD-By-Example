using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public sealed class JustOutputTheNumberAnalyzer : IOperation<INumberFilter>, IAnalyzer
    {
        public string Execute(int i)
        {
            return i.ToString();
        }
    }
}
