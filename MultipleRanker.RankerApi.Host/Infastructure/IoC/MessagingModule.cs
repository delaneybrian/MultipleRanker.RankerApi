using Autofac;
using MultipleRanker.RankerApi.Infrastructure.Messaging;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    internal class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RabbitMQMessagePublisher>()
                .As<IMessagePublisher>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQMessageSubscriber>()
                .As<IMessageSubscriber>()
                .SingleInstance();

            builder
                .RegisterType<MediatRDispatcher>()
                .As<IMessageDispatcher>()
                .SingleInstance();
        }
    }
}
