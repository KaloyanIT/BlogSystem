namespace Blog.Infrastructure.AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::AutoMapper;

    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init()
        {
            var autoMapperCfg = new AutoMapperConfig();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var projectAssemblies = assemblies
                .Where(a => a.FullName.Contains("Blog")).ToList();

            MapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    foreach (var assembly in assemblies)
                    {
                        if (assembly.IsDynamic)
                        {
                            continue;
                        }

                        var types = assembly.GetExportedTypes();
                        LoadMappings(types, cfg);
                    }
                });
        }

        private static void LoadMappings(IEnumerable<Type> types, IProfileExpression mapperConfiguration)
        {
            foreach (var type in types.Where(x => x.IsAbstract == false && x.IsInterface == false))
            {
                var interfaces = type.GetInterfaces().Where(x => x.IsGenericType);

                foreach (var i in interfaces)
                {
                    var interfaceArgs = i.GetGenericArguments()[0];

                    if (i.GetGenericTypeDefinition() == typeof(IHaveReverseMap<>))
                    {
                        mapperConfiguration.CreateMap(interfaceArgs, type).ReverseMap();
                    }
                    else if (i.GetGenericTypeDefinition() == typeof(IHaveMapFrom<>))
                    {
                        mapperConfiguration.CreateMap(interfaceArgs, type);
                    }
                    else if (i.GetGenericTypeDefinition() == typeof(IHaveMapTo<>))
                    {
                        mapperConfiguration.CreateMap(type, interfaceArgs);
                    }
                    else if (typeof(IHaveCustomMap).IsAssignableFrom(type))
                    {
                        var map = (IHaveCustomMap)Activator.CreateInstance(type);

                        map.CreateMappings(mapperConfiguration);
                    }

                }
            }
        }
    }
}
