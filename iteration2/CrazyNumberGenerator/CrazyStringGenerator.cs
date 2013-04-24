using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator
{
    public class CrazyStringGenerator : Pipeline<INumberFilter>
    {
        public CrazyStringGenerator()
        {
            RegisterWorkflow();
        }

        protected void RegisterWorkflow()
        {
            // NOTE: The order of registration is important for correct behaviour

            // Existing behaviour requirements
            Register(new CanDivideByThese(new List<int> { 3, 5 }, "hellogoodbye")).Register(new CanDivideBy(3, "hello")).Register(new CanDivideBy(5, "goodbye"));

            // Quick new filter
            Register(new LuckyNumber(7, "Lucky Seven!"));

            // Number output now neededm and must be the last in line
            Register(new OtherwiseJustOutputTheNumber());
        }
    }
}
