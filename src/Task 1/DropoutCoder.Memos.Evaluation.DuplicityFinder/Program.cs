using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DropoutCoder.Memos.Evaluation.DuplicityFinder {
    class Program {
        private static IValueGenerator<int> _generator = new Int32Generator(/*DateTime.Now.Millisecond*/);
        private static IArrayFactory<int> _factory = new ArrayFactory<int>();

        static void Main(string[] args) {
            var array = _factory.Create(1_000_000);
            var initializer = new ArrayInitializer<int>(_generator);
            
            if (initializer.TryInitialize(ref array)) {

                var stopwatch = new Stopwatch();

                IDuplicityFinder<int> finder = new LinqDuplicityFinder<int>();
                //IDuplicityFinder<int> finder = new HashsetDuplicityFinder<int>();

                stopwatch.Start();
                var result = finder.Find(array);
                stopwatch.Stop();

                Console.WriteLine($"Found {result.Count()} duplicate entries in {stopwatch.ElapsedMilliseconds} milliseconds!");
                Console.WriteLine();

                foreach (var item in result) {
                    Console.WriteLine($"{item}");
                }
              } else {
                Console.WriteLine("Oh, heck! Something went terribly wrong. Sorry.");
            }           

            Console.ReadKey();
        }
    }
}
