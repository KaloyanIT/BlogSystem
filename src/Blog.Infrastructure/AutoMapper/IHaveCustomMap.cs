namespace Blog.Infrastructure.AutoMapper
{
    using global::AutoMapper;

    public interface IHaveCustomMap : IHaveMap
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
