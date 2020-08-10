using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DropoutCoder.CodingFun.DuplicityFinder.Core;
using DropoutCoder.CodingFun.DuplicityFinder.Validation;

namespace DropoutCoder.CodingFun.DuplicityFinder {
    class Program {
        private static IValueGenerator<int> _generator = new Int32Generator(/*DateTime.Now.Millisecond*/);
        private static IEnumerable<IDuplicityFinder<int>> _finders = new IDuplicityFinder<int>[] {
            new LinqDuplicityFinder<int>(),
            new HashsetDuplicityFinder<int>()
        };

        static void Main(string[] args) {
        #region Count selection
        ItemCountInput:
            Console.WriteLine("How many items should be generated?");
            var itemCountInput = Console.ReadLine();

            var itemCountValidator = new RangeValidator(UInt32.MinValue + 2, UInt32.MaxValue);

            if (!UInt32.TryParse(itemCountInput, out uint count) || !itemCountValidator.IsValid(count)) {
                Console.WriteLine($"Can you write positive integer, please? Number between {itemCountValidator.Min} and {itemCountValidator.Max}.");
                goto ItemCountInput;
            }
        #endregion

        #region Finder selection
        FinderIndexInput:
            Console.WriteLine("Which duplicity finder you would like to use?");

            Console.WriteLine("[0] All of them");
            int finderId = 0;
            foreach (var finder in _finders) {
                Console.WriteLine($"[{++finderId}] {finder.GetType().Name}");
            }

            var indexInput = Console.ReadLine();

            var finderIndexValidator = new RangeValidator(0, Convert.ToUInt32(_finders.Count()));

            if (!UInt32.TryParse(indexInput, out uint index) || !finderIndexValidator.IsValid(index)) {
                Console.WriteLine($"Can you write positive integer, please? Number between {finderIndexValidator.Min} and {finderIndexValidator.Max}.");
                goto FinderIndexInput;
            }
            #endregion

            #region Running duplicity check
            try {
                var finders = index == 0 ? _finders : _finders.Where((m, i) => i == index);

                var initializer = new ArrayInitializer<int>(_generator);

                int[] array = initializer.Initialize(count);

                var stopwatch = new Stopwatch();

                foreach (var finder in finders) {
                    stopwatch.Start();
                    var result = finder.Find(array);
                    stopwatch.Stop();

                    Console.WriteLine($"Found {result.Count()} duplicate entries in {stopwatch.ElapsedMilliseconds} milliseconds!");
                    Console.WriteLine();

                    //foreach (var item in result) {
                    //    Console.WriteLine($"{item}");
                    //}

                    stopwatch.Reset();
                }
            } catch (Exception) {
                Console.WriteLine("Oh, heck! Something went terribly wrong. Sorry.");
            }
            #endregion

            #region Application flow restart
            Console.WriteLine("Do you want to start over again? (y/n)");
            var restartInput = Console.ReadKey();

            if (restartInput.Key == ConsoleKey.Y) {
                Console.Clear();
                goto ItemCountInput;
            } else if (restartInput.Key != ConsoleKey.N) {
                Console.WriteLine("You really have a problems with letter, huh?");
            }
            #endregion
        }
    }
}
