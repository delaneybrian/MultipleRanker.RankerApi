using Autofac;
using MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    internal class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MongoRatingsRepository>()
                .As<IRatingsRepository>()
                .SingleInstance();
        }
    }
}
