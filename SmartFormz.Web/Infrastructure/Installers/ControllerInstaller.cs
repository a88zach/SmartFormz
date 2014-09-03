using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SmartFormz.Web.Controllers;

namespace SmartFormz.Web.Infrastructure.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorActionInvoker>().LifeStyle.Transient);

            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<SmartFormzController>(true)
                .Configure(c => c.LifestyleTransient()));
        }
    }
}