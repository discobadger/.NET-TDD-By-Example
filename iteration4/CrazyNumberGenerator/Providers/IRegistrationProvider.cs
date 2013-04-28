using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyNumberGenerator.Pipeline;

namespace CrazyNumberGenerator.Providers
{
    public interface IRegistrationItemsProvider
    {
        IList<IOperation<INumberFilter>> Read();
    }
}
