using System.Collections.Generic;

namespace DropoutCoder.CodingFun.DuplicityFinder.Core {
    public interface IDuplicityFinder<T> {
        IEnumerable<T> Find(T[] collection);
    }
}
