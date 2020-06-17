namespace Blog.Infrastructure.AutoMapper
{
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface IHaveReverseMap<T> : IHaveMap where T : class
#pragma warning restore CA1040 // Avoid empty interfaces
    {
    }
}
