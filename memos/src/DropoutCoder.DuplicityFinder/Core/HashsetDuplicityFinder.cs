using System.Collections.Generic;
using System.Linq;

namespace DropoutCoder.DuplicityFinder.Core
{
    public class HashsetDuplicityFinder<T> : IDuplicityFinder<T>
    {
        public IEnumerable<T> Find(T[] items)
        {
            // null check
            // size check

            var size = items.Count();

            var singles = new HashSet<T>(size);
            var duplicates = new HashSet<T>(size / 2);

            foreach (var item in items)
            {
                if (!singles.Add(item))
                {
                    if (duplicates.Add(item))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
