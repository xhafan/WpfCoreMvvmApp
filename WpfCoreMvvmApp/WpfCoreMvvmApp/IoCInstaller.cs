using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoreMvvm;
using WpfCoreMvvmApp.Services;

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
            container.Register(
                Component.For<IRecordImagesService>()
                         .ImplementedBy<RecordImagesService>()
                         .LifestyleSingleton()
                         );
        }
    }
}