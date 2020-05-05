using System.Reflection;
using Autofac;
using MediatR;
using Module = Autofac.Module;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(Assembly.Load("MultipleRanker.RankerApi.Application"))
                .AsImplementedInterfaces();

        }
    }
}
