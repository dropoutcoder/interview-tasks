using System.Collections.Generic;
using System.Linq;

namespace DropoutCoder.CodingFun.DuplicityFinder.Core {
    public class LinqDuplicityFinder<T> : IDuplicityFinder<T> {
        public IEnumerable<T> Find(IEnumerable<T> collection) {
            // null check
            // size check

            return collection
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key);
        }
    }
}
