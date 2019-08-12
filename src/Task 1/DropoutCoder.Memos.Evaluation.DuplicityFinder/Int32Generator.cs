using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder {
    public interface IValueGenerator<T> {
        T Generate();
    }

    public class Int32Generator : IValueGenerator<int> {
        private readonly Random _random;

        public Int32Generator() {
            _random = new Random();
        }

        // In case we want to have every pseudo random function with different outcomes each time we use it
        //public Int32Generator(int seed) {
        //    _random = new Random(seed);
        //}

        public int Generate() {
            return _random.Next();
        }
    }
}
