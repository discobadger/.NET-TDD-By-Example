using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static IEnumerable<int> Iterate(int fromInclusive, int toExclusive)
        {
            for (int i = fromInclusive; i < toExclusive; i++ ) yield return i;
        }

        public virtual IList<string> Execute(int total)
        {
            // Based on the logic as-is, there's no concurrency issue, thus the simplest storage device
            // to use here is actually an Array. ConcurrentBag could be used for pre-empting future changes 
            // (which would involve a bigger change to the basic break-on-null logic), and thus probably 
            // makes the current implementation less-performat.

            //var items = new ConcurrentBag<AnalyzerResult>();
            var items = new string[total];

            Parallel.ForEach(Iterate(1, (total + 1)), d =>
            {
                foreach (IOperation<T> operation in operations)
                {
                    var result = operation.Execute(d);
                    if (result != null)
                    {
                        //items.Add(new AnalyzerResult(d, result));
                        items[(d - 1)] = result;
                        break;
                    }
                }
            });

            //return items.OrderBy(s=>s.SortOrder).Select(t => t.Result).ToList();
            return items.ToList();
        }
    }

    //class AnalyzerResult
    //{
    //    private int _sortOrder;
    //    private string _result;

    //    public int SortOrder { get { return _sortOrder; } }
    //    public string Result { get { return _result; } }

    //    public AnalyzerResult(int sortOrder, string result)
    //    {
    //        _sortOrder = sortOrder;
    //        _result = result;
    //    }
    //}
}
