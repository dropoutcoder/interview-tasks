using System;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder {
    public class ArrayInitializer<T> {
        private readonly IValueGenerator<T> _generator;

        public ArrayInitializer(IValueGenerator<T> generator) {
            _generator = generator ?? throw new ArgumentNullException();
        }

        public bool TryInitialize(ref T[] array) {
            bool result = false;

            try {
                for (int i = 0; i < array.Length; i++) {
                    array[i] = _generator.Generate();
                }

                result = true;
            } catch(Exception e) {
                throw new ApplicationException("We have a problem during array initialization, sir!", e);
            }

            return result;
        }
    }
}
