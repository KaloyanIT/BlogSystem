namespace Blog.Infrastructure.AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::AutoMapper;

    public sealed class AutoMapperConfig : Profile
    {
        public static MapperConfiguration? MapperConfiguration { get; private set; }

        //public AutoMapperConfig()
        //{
        //    var mapFromType = typeof(IHaveMapFrom<>);
        //    var mapToType = typeof(IHaveMapTo<>);
        //    var reverseMapType = typeof(IHaveReverseMap<>);
        //    var customMapType = typeof(IHaveCustomMap);

        //    var modelRegistrations = AssemblyHelper
        //        .GetAllBlogAssemblies()
        //        .SelectMany(x => x.GetExportedTypes())
        //        .Where(t => t.IsClass && !t.IsAbstract)
        //        .Select(t => new
        //        {
        //            Type = t, 
        //            HaveMapFrom = this.GetMappingModel(t, mapFromType), 
        //            HaveMapTo = this.GetMappingModel(t, mapToType), 
        //           HaveReverseMap = this.GetMappingModel(t, reverseMapType), 
        //           HaveCustomMap = t.GetInterfaces()
        //                .Where(i => i == customMapType)
        //                .Select(i => (IHaveCustomMap?)Activator.CreateInstance(t))
        //                .FirstOrDefault()
        //        });

        //    foreach (var modelRegistration in modelRegistrations)
        //    {
        //        if(modelRegistration.HaveMapFrom != null)
        //        {
        //            this.CreateMap(modelRegistration.HaveMapFrom, modelRegistration.Type);
        //        }

        //        if(modelRegistration.HaveMapTo != null)
        //        {
        //            this.CreateMap(modelRegistration.Type, modelRegistration.HaveMapTo);
        //        }

        //        if(modelRegistration.HaveReverseMap != null)
        //        {
        //            this.CreateMap(modelRegistration.HaveMapFrom, modelRegistration.Type).ReverseMap();
        //        }

        //        modelRegistration.HaveCustomMap?.CreateMappings(this);
        //    }
        //}

        public static void Init()
        {
            var autoMapperCfg = new AutoMapperConfig();

            var projectAssemblies = AssemblyHelper.GetAllBlogAssemblies();

            MapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    LoadMappings(cfg);
                    //foreach (var assembly in projectAssemblies)
                    //{
                    //    if (assembly.IsDynamic)
                    //    {
                    //        continue;
                    //    }

                    //    var types = assembly.GetExportedTypes();
                    //    LoadMappings(types, cfg);
                    //}
                });
        }

        private static Type? GetMappingModel(Type type, Type mappingInterface)
           => type.GetInterfaces()
               .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface)
               ?.GetGenericArguments()
               .First();

        private static void LoadMappings(IProfileExpression mapperConfiguration)
        {
            var mapFromType = typeof(IHaveMapFrom<>);
            var mapToType = typeof(IHaveMapTo<>);
            var reverseMapType = typeof(IHaveReverseMap<>);
            var customMapType = typeof(IHaveCustomMap);

            var modelRegistrations = AssemblyHelper
                .GetAllBlogAssemblies()
                .SelectMany(x => x.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    HaveMapFrom = GetMappingModel(t, mapFromType),
                    HaveMapTo = GetMappingModel(t, mapToType),
                    HaveReverseMap = GetMappingModel(t, reverseMapType),
                    HaveCustomMap = t.GetInterfaces()
                        .Where(i => i == customMapType)
                        .Select(i => (IHaveCustomMap?)Activator.CreateInstance(t))
                        .FirstOrDefault()
                })
                .ToList();

            foreach (var modelRegistration in modelRegistrations)
            {
                if (modelRegistration.HaveMapFrom != null)
                {
                    mapperConfiguration.CreateMap(modelRegistration.HaveMapFrom, modelRegistration.Type);
                }

                if (modelRegistration.HaveMapTo != null)
                {
                    mapperConfiguration.CreateMap(modelRegistration.Type, modelRegistration.HaveMapTo);
                }

                if (modelRegistration.HaveReverseMap != null)
                {
                    mapperConfiguration.CreateMap(modelRegistration.HaveReverseMap, modelRegistration.Type).ReverseMap();
                }

                modelRegistration.HaveCustomMap?.CreateMappings(mapperConfiguration);
            }       
        }
    }
}
