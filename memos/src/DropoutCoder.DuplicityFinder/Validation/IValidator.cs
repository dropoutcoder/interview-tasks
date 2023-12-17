namespace DropoutCoder.CodingFun.DuplicityFinder.Validation {
    public interface IValidator<T> {
        bool IsValid(T value);
    }
}