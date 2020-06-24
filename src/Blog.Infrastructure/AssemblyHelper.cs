namespace Blog.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Blog.Infrastructure.AutoMapper;

    public static class AssemblyHelper
    {
        public static ICollection<Assembly> GetDomainAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            return assemblies;
        }

        public static ICollection<Assembly> GetAllBlogServiceAssemblies()
        {
            var assemblies = GetDomainAssemblies()
                .Where(x => x.GetName().Name!.StartsWith("Blog", StringComparison.OrdinalIgnoreCase))
                .ToList();

            assemblies
                .SelectMany(x => x.GetReferencedAssemblies()
                    .Where(x => x.Name!.StartsWith("Blog", StringComparison.OrdinalIgnoreCase)))
                .Distinct()
                //.Where(y => assemblies.Any((a) => a.FullName == y.FullName) == false)
                .ToList()
                .ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(x)));


            return assemblies;
        }

        public static ICollection<Assembly> GetAllBlogAssemblies()
        {
            var assemblies = GetDomainAssemblies()
                .Where(x => x.GetName().Name!.StartsWith("Blog", StringComparison.OrdinalIgnoreCase) 
                && x.IsDynamic == false)
                .ToList();

            assemblies
            .SelectMany(x => x.GetReferencedAssemblies().Where(x => x.Name!.StartsWith("Blog", StringComparison.OrdinalIgnoreCase)))
            .Distinct()
            .Where(y => assemblies.Any((a) => a.FullName == y.FullName) == false)
            .ToList()
            .ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(x)));
           

            return assemblies;
        }

        public static Assembly GetAssembly(string name)
        {
            var assemblies = AssemblyHelper.GetDomainAssemblies();

            var assembly = assemblies.SingleOrDefault(x => x.GetName().Name == name);

            if (assembly == null)
            {
                assembly = Assembly.Load(name);
            }

            return assembly;
        }

        private static void LoadReferencedAssembly(Assembly assembly)
        {
            foreach (AssemblyName name in assembly.GetReferencedAssemblies())
            {
                if (!AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName == name.FullName))
                {
                    LoadReferencedAssembly(Assembly.Load(name));
                }
            }
        }

        public static ICollection<string> GetAllAssembliesContainsMappedObjects()
        {
            var assemblies = AssemblyHelper.GetDomainAssemblies();

            var assemblyNames = new HashSet<string>();

            foreach (var assembly in assemblies)
            {
                var haveTypes = assembly.GetTypes().Where(x => x.IsAssignableFrom(typeof(IHaveMap))).Any();

                if (haveTypes)
                {
                    assemblyNames.Add(assembly.GetName().FullName);
                }
            }

            return assemblyNames;
        }
    }
}
