using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreMvvm;

namespace WpfCoreMvvmApp
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<BaseViewModel>()
                       .Configure(x => x.LifestyleTransient())
                );
        }
    }
}