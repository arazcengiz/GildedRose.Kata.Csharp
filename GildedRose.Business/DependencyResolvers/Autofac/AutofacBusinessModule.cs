using Autofac;

namespace GildedRose.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Registering create managers
            builder.RegisterType<Concrete.CreateManagers.CreateManager>().As<Abstract.ICreateService>().InstancePerLifetimeScope();

            //Registering Update managers
            builder.RegisterType<Concrete.UpdateManagers.AgedBrieUpdateManager>().As<Abstract.IItemUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<Concrete.UpdateManagers.BackstagePassesUpdateManager>().As<Abstract.IItemUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<Concrete.UpdateManagers.ConjuredUpdateManager>().As<Abstract.IItemUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<Concrete.UpdateManagers.StandardUpdateManager>().As<Abstract.IItemUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<Concrete.UpdateManagers.SulfurasUpdateManager>().As<Abstract.IItemUpdateService>().InstancePerLifetimeScope();
        }
    }
}

