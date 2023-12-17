using System.Collections.Generic;
using System.Linq;

namespace DropoutCoder.DuplicityFinder.Core
{
    public class LinqDuplicityFinder<T> : IDuplicityFinder<T>
    {
        public IEnumerable<T> Find(T[] items)
        {
            // null check
            // size check

            return items
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key);
        }
    }
}
