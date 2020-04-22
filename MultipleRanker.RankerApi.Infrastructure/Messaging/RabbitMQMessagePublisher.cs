﻿using System;
using System.Text;
using MultipleRanker.Contracts;
using MultipleRanker.RankerApi.Interfaces;
using RabbitMQ.Client;

namespace MultipleRanker.RankerApi.Infrastructure.Messaging
{
    public class RabbitMQMessagePublisher : IMessagePublisher
    {
        private readonly IConnection _connection;
        private readonly ISerializer _serializer;

        private readonly string ExchangeName = "multipleranker";

        public RabbitMQMessagePublisher(ISerializer serializer)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();

            _serializer = serializer;
        }

        public void Publish<T>(T content, Guid correlationId) where T : class
        {
            var message = new Message()
            {
                Content = Encoding.UTF8.GetBytes(_serializer.Serialize(content)),
                RoutingKey = typeof(T).FullName,
                CorrelationId = correlationId,
                AssemblyQualifiedName = typeof(T).AssemblyQualifiedName
            };

            using (var channel = _connection.CreateModel())
            {
                channel.ExchangeDeclare(
                    exchange: ExchangeName,
                    type: "direct");

                var jsonMessage = _serializer.Serialize(message);

                var body = Encoding.UTF8.GetBytes(jsonMessage);

                channel.BasicPublish(ExchangeName, message.RoutingKey, null, body);
            }
        }
    }
}
