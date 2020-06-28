namespace Blog.Infrastructure.Validator
{
    public interface IValidatorStrategy<T>
    {
        bool IsValid(T validateThis);
    }
}
