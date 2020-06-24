namespace Blog.Infrastructure.Adapter
{
    using System.Collections.Generic;

    public interface IMultipleObjectAdaptor<T, T1> : ISingleObjectAdapter<T, T1>
        where T : class
        where T1 : class
    {
        void Adapt(IEnumerable<T> fromValues, ICollection<T1> toValues);
    }
}
