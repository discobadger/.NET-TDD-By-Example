using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyNumberGenerator.Pipeline
{
    public class Pipeline<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();


        public Pipeline<T> Register(IOperation<T> operation)
        {
            operations.Add(operation);
            return this;
        }

        public IList<string> Execute(int total)
        {
            var items = new List<string>();
            int x = 1;

            while (x < (total + 1))
            {
                foreach (IOperation<T> operation in operations)
                {
                    var result = operation.Execute(x);
                    if (result != null)
                    {
                        items.Add(result);
                        break;
                    }
                }

                x++;
            }

            return items;
        }
    }
}
