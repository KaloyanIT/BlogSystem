using System;
using System.Linq;
using System.Reflection;

namespace Blog.Infrastructure
{
    public static class AssemblyHelper
    {
        public static Assembly[] GetDomainAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

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
    }
}
