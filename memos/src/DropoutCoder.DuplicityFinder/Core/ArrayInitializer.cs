using System;

namespace DropoutCoder.DuplicityFinder.Core
{
    public class ArrayInitializer<T>
    {
        private readonly IValueGenerator<T> _generator;

        public ArrayInitializer(IValueGenerator<T> generator)
        {
            _generator = generator ?? throw new ArgumentNullException();
        }

        public T[] Initialize(uint count)
        {
            T[] array = new T[count];

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = _generator.Generate();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("We encounter a problem during array initialization, sir!", e);
            }

            return array;
        }
    }
}
