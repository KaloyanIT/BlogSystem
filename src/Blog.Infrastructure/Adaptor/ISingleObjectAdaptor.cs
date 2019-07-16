namespace Blog.Infrastructure.Adaptor
{
    public interface ISingleObjectAdaptor<T, T1>
        where T : class
        where T1 : class
    {
        void Adapt(T fromValue, T1 toValue);
    }
}
