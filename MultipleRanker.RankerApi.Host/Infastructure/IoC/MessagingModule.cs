using System.Collections.Generic;
using Autofac;
using MultipleRanker.Contracts.Messages;
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
                .WithParameter(
                    "subscribedTo",
                    new List<string>
                    {
                        typeof(RatingsGenerated).FullName
                    }.ToArray())
                .SingleInstance();

            builder
                .RegisterType<MediatRDispatcher>()
                .As<IMessageDispatcher>();

            builder
                .RegisterType<SystemJsonSerializer>()
                .As<ISerializer>();
        }
    }
}
