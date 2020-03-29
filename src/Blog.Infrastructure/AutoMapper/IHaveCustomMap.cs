namespace Blog.Infrastructure.AutoMapper
{
    using global::AutoMapper;

    public interface IHaveCustomMap
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
