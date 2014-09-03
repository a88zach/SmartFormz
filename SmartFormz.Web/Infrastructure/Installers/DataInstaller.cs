using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SmartFormz.Data.Repositories;

namespace SmartFormz.Web.Infrastructure.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("SmartFormz.Data")
                .InNamespace("SmartFormz.Data.Repositories")
                .WithService.DefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }
    }
}