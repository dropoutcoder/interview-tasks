namespace DropoutCoder.Memos.Evaluation.DuplicityFinder.Validation {
    public class RangeValidator : IRangeValidator<uint> {
        public RangeValidator(uint min, uint max) {
            this.Min = min;
            this.Max = max;
        }

        public uint Min { get; }
        public uint Max { get; }

        public bool IsValid(uint count) {
            return Min <= count && count <= Max;
        }
    }
}
