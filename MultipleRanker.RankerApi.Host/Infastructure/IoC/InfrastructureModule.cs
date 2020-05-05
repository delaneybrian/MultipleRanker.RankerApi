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
                .RegisterType<MongoRatingBoardRepository>()
                .As<IRatingBoardRepository>()
                .SingleInstance();

            builder
                .RegisterType<MongoHistoricalRatingRepository>()
                .As<IHistoricalRatingsRepository>()
                .SingleInstance();

            builder
                .RegisterType<MongoParticipantRepository>()
                .As<IParticipantRepository>()
                .SingleInstance();
        }
    }
}
