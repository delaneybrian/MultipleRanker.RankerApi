using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    public static class Bootstrapper
    {
        public static IContainer Bootstrap(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new MessagingModule());
            builder.RegisterModule(new InfrastructureModule());

            return builder.Build();
        }
    }
}
