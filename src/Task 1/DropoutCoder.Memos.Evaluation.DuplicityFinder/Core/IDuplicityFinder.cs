using System.Collections.Generic;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder.Core {
    public interface IDuplicityFinder<T> {
        IEnumerable<T> Find(IEnumerable<T> collection);
    }
}
