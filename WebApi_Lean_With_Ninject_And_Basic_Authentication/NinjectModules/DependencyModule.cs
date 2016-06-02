using Ninject.Modules;
using WebApi_Lean_With_Ninject_And_Basic_Authentication.Services;

namespace WebApi_Lean_With_Ninject_And_Basic_Authentication.NinjectModules
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProvideSomeDependency>().To<ProvideSomeDependency>().InSingletonScope();
        }
    }
}