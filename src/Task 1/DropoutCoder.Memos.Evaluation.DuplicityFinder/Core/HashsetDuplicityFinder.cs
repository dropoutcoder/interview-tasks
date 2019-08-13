using System.Collections.Generic;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder.Core {
    public class HashsetDuplicityFinder<T> : IDuplicityFinder<T> {
        private HashSet<T> _singles = new HashSet<T>();
        private HashSet<T> _duplicates = new HashSet<T>();

        public IEnumerable<T> Find(IEnumerable<T> collection) {
            // null check
            // size check

            foreach (var item in collection) {
                if (!_singles.Add(item)) {
                    if (_duplicates.Add(item)) {
                        yield return item;
                    }
                }
            }

            _singles.Clear();
            _duplicates.Clear();
        }
    }
}
