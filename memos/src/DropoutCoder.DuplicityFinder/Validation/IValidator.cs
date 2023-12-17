namespace DropoutCoder.DuplicityFinder.Validation
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}