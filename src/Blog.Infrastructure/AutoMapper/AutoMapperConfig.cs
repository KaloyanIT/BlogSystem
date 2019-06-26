using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Blog.Infrastructure.AutoMapper
{
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
                    if (i.GetGenericTypeDefinition() == typeof(IHaveMapFrom<>))
                    {
                        var source = i.GetGenericArguments()[0];
                        var destination = type;

                        mapperConfiguration.CreateMap(source, destination);
                    }
                    else if (i.GetGenericTypeDefinition() == typeof(IHaveMapTo<>))
                    {
                        var source = type;
                        var destination = i.GetGenericArguments()[0];

                        mapperConfiguration.CreateMap(source, destination);
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
