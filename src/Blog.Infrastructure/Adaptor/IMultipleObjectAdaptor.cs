using System.Collections.Generic;

namespace Blog.Infrastructure.Adaptor
{
    public interface IMultipleObjectAdaptor<T, T1> : ISingleObjectAdaptor<T, T1>
        where T : class
        where T1 : class
    {
        void Adapt(IEnumerable<T> fromValues, ICollection<T1> toValues);
    }
}
