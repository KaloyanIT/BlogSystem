namespace Blog.Infrastructure
{
    public interface IValidatorStrategy<T>
    {
        bool IsValid(T validateThis);
    }
}
