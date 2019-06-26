using AutoMapper;

namespace Blog.Infrastructure.AutoMapper
{
    public interface IHaveCustomMap
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
