using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_task
{
    public static class SpecificArrayMethodsExtensions
    {
        public static void ForEachEven<T>(this IEnumerable<T> numbers, Action<T> performAction)
        {
            var evenNumberDigits = numbers.Where((x, i) => (i + 1) % 2 == 0).ToList();

            evenNumberDigits.ForEach(performAction);
        }
        public static void ForEachOdd<T>(this IEnumerable<T> numbers, Action<T> performAction)
        {
            foreach (var item in numbers.Where((x, i) => (i + 1) % 2 != 0))
            {
                performAction(item);
            }
        }
    }
}
