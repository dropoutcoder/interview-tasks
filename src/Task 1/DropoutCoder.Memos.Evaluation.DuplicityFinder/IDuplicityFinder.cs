using System.Collections.Generic;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder {
    public interface IDuplicityFinder<T> {
        IEnumerable<T> Find(IEnumerable<T> collection);
    }
}
