namespace DropoutCoder.Memos.Evaluation.DuplicityFinder.Validation {
    public interface IValidator<T> {
        bool IsValid(T value);
    }
}