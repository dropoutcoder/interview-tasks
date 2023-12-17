using System.Collections.Generic;

namespace DropoutCoder.DuplicityFinder.Core
{
    public interface IDuplicityFinder<T>
    {
        IEnumerable<T> Find(T[] items);
    }
}
