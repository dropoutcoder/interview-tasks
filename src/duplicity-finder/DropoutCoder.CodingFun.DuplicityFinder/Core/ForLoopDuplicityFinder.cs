using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.CodingFun.DuplicityFinder.Core
{
    public class ForLoopDuplicityFinder<T> : IDuplicityFinder<T>
    {
        public IEnumerable<T> Find(T[] array)
        {
            // null check
            // size check
            var duplicates = new List<T>(array.Length / 2);

            for (int current = 0; current < array.Length; current++)
            {
                var value = array[current];
                for(int following = current + 1; following < array.Length; following++)
                {
                    if(value.Equals(array[following]) && duplicates.Contains(value))
                    {
                        duplicates.Add(value);
                    }
                }
            }

            return duplicates;
        }
    }
}
