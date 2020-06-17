namespace Blog.Infrastructure.AutoMapper
{
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface IHaveMapTo<T> : IHaveMap where T : class
#pragma warning restore CA1040 // Avoid empty interfaces
    {
    }
}
