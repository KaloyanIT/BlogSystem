namespace Blog.Infrastructure.Validators
{
    public interface IValidatorStrategy<T>
    {
        bool IsValid(T validateThis);
    }
}
