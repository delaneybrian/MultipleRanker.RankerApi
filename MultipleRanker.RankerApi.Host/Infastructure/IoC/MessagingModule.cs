using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Infrastructure.Messaging;
using MultipleRanker.RankerApi.Interfaces;
using Module = Autofac.Module;

namespace MultipleRanker.RankerApi.Host.Infastructure.IoC
{
    internal class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = Assembly.Load("MultipleRanker.RankerApi.Application");

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
                        typeof(RatingsGenerated).FullName,
                        typeof(CreateRatingBoard).FullName
                    }.ToArray())
                .SingleInstance();

            builder
                .RegisterType<MessageDispatcher>()
                .As<IMessageDispatcher>();

            builder
                .RegisterAssemblyTypes(applicationAssembly)
                .Where(t => typeof(IHandler).IsAssignableFrom(t))
                .As<IHandler>();

            builder
                .RegisterType<SystemJsonSerializer>()
                .As<ISerializer>();
        }
    }
}
