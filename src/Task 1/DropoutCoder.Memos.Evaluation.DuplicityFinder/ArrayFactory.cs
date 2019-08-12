using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder {
    public interface IArrayFactory<T> {
        T[] Create(uint capacity);
    }

    public class ArrayFactory<T> : IArrayFactory<T> {
        public T[] Create(uint capacity) {
            // no checks needed

            return new T[capacity];
        }
    }
}
