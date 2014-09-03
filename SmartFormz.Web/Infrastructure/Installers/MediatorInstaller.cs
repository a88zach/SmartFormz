using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter.Unofficial;
using MediatR;
using Microsoft.Practices.ServiceLocation;
using SmartFormz.Web.Infrastructure.Filters;

namespace SmartFormz.Web.Infrastructure.Installers
{
    public class MediatorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IMediator>().Pick().WithServiceAllInterfaces());
            container.Register(Classes.FromAssemblyNamed("SmartFormz.Services").Pick().WithServiceAllInterfaces());
            container.Kernel.AddHandlersFilter(new ContravariantFilter());

            var serviceLocator = new WindsorServiceLocator(container);
            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);
            container.Register(Component.For<ServiceLocatorProvider>().Instance(serviceLocatorProvider));
        }
    }
}