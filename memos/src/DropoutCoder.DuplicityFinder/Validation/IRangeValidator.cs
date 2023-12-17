using System;

namespace DropoutCoder.DuplicityFinder.Validation
{
    public interface IRangeValidator<T> : IValidator<T>
        where T : struct, IEquatable<T>
    {
        T Min { get; }
        T Max { get; }
    }
}
