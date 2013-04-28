using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrazyNumberGenerator.Pipeline;
using CrazyNumberGenerator.Providers;

namespace CrazyNumberGenerator
{
    public sealed class CrazyStringGenerator : Pipeline<INumberFilter>, IStringGenerator
    {
        IRegistrationItemsProvider _registrationItemsProvider;

        public CrazyStringGenerator()
        {
            _registrationItemsProvider = new DefaultRegistrationProvider();
            RegisterWorkflow();
        }

        public CrazyStringGenerator(IRegistrationItemsProvider RegistrationItemsProvider)
        {
            _registrationItemsProvider = RegistrationItemsProvider;

            RegisterWorkflow();
        }

        public void RegisterWorkflow()
        {
            foreach (var operation in _registrationItemsProvider.Read())
                Register(operation);
        }
    }
}
