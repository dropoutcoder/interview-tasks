using System.Collections.Generic;
using System.Linq;

namespace DropoutCoder.CodingFun.DuplicityFinder.Core
{
    public class HashsetDuplicityFinder<T> : IDuplicityFinder<T>
    {
        public IEnumerable<T> Find(T[] collection)
        {
            // null check
            // size check

            var size = collection.Count();

            var singles = new HashSet<T>(size);
            var _duplicates = new HashSet<T>(size / 2);

            foreach (var item in collection)
            {
                if (!singles.Add(item))
                {
                    if (_duplicates.Add(item))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
