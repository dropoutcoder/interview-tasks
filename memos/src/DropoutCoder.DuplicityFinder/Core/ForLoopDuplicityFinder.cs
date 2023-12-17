using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.DuplicityFinder.Core
{
    public class ForLoopDuplicityFinder<T> : IDuplicityFinder<T>
    {
        public IEnumerable<T> Find(T[] items)
        {
            // null check
            // size check
            var duplicates = new List<T>(items.Length / 2);

            for (int current = 0; current < items.Length; current++)
            {
                var value = items[current];
                for (int following = current + 1; following < items.Length; following++)
                {
                    if (value.Equals(items[following]) && duplicates.Contains(value))
                    {
                        duplicates.Add(value);
                    }
                }
            }

            return duplicates;
        }
    }
}
