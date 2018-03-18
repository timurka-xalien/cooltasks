using Autofac;
using Autofac.Integration.Mvc;
using CoolTasks.ServiceLayer;
using System.Web.Mvc;

namespace CoolTasks
{
    public class DependencyInjectionConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Enable Property Injection for Action Filters
            builder.RegisterFilterProvider();

            RegisterComponents(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Class1>().AsSelf();
        }
    }
}