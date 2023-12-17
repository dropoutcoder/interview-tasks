namespace DropoutCoder.DuplicityFinder.Validation
{
    public class RangeValidator : IRangeValidator<uint>
    {
        public RangeValidator(uint min, uint max)
        {
            Min = min;
            Max = max;
        }

        public uint Min { get; }
        public uint Max { get; }

        public bool IsValid(uint count)
        {
            return Min <= count && count <= Max;
        }
    }
}
