namespace Blog.Data.Base.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    public static class ModuleBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(ModelBuilder modelBuilder, IEntityTypeConfiguration<TEntity> configuration)
        where TEntity : class
        {
            configuration.Configure(modelBuilder.Entity<TEntity>());
        }

        public static void ApplyDbConfiguration(this ModelBuilder modelBuilder)
        {
            Type interfaceType = typeof(IEntityTypeConfiguration<>);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name!.Contains("Blog"));
            var configurationAssembly = Assembly.Load("Blog.Data.Configurations");
            Type[] types = configurationAssembly.GetTypes();

            var typesToRegister = from x in types
                                  from z in x.GetInterfaces()
                                  let y = x.BaseType
                                  where
                                  (y != null
                                  && y.IsGenericType
                                  && interfaceType.IsAssignableFrom(y.GetGenericTypeDefinition()))
                                  || (z.IsGenericType && interfaceType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                                  select x;

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type)!;
                ModuleBuilderExtensions.AddConfiguration(modelBuilder, configurationInstance);
            }

            //Set date time
            //var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            //{
            //    property.SetValueConverter(dateTimeConverter);
            //}
        }

    }
}
