using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.DuplicityFinder.Core
{
    public class ForLoopDuplicityFinder<T> : IDuplicityFinder<T>
        where T : IEquatable<T>
    {
        public IEnumerable<T> Find(T[] items)
        {
            // null check
            // size check
            var temp = new Dictionary<T, uint>(items.Length / 2);

            for (int i = 0; i < items.Length; i++)
            {
                var current = items[i];
                var exists = temp.TryGetValue(items[i], out uint value);

                if (!exists)
                {
                    temp[current] = 1;
                }
                else if (value == 1)
                {
                    temp[items[i]] += 1;
                    yield return current;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
