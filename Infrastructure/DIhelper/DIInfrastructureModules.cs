using Autofac;
using System.Linq;
using System.Reflection;


namespace Infrastructure.DIhelper
{
    public class DIInfrastructureModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("EFAddressBook"))
                      .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("AddressBookService"))
                         .Where(t => t.Namespace.EndsWith("Application"))
                         .AsImplementedInterfaces()
                         .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("AddressBookService"))
                .Where(t => t.Namespace.EndsWith("Model"))
                     .InstancePerLifetimeScope();
        }
    }
}
