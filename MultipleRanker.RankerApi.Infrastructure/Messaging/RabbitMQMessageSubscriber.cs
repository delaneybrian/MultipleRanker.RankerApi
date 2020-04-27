﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MultipleRanker.Messaging.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Messaging
{
    public class RabbitMQMessageSubscriber : IMessageSubscriber
    {
        private readonly IConnection _connection;
        private readonly IMessageDispatcher _messageDispatcher;
        private readonly ICollection<string> _subscribedTo;
        private readonly ISerializer _serializer;

        private readonly string ExchangeName = "multipleranker";

        public RabbitMQMessageSubscriber(
            ICollection<string> subscribedTo,
            IMessageDispatcher messageDispatcher,
            ISerializer serializer)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            _connection = factory.CreateConnection();

            _subscribedTo = subscribedTo;

            _messageDispatcher = messageDispatcher;
            _serializer = serializer;
        }

        public void Start(CancellationToken cancellationToken)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ExchangeName,
                    type: "direct");

                var queueName = channel.QueueDeclare().QueueName;

                foreach (var subscribeTo in _subscribedTo)
                {
                    channel.QueueBind(queue: queueName,
                        exchange: ExchangeName,
                        routingKey: subscribeTo);
                }

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var messageString = Encoding.UTF8.GetString(body);

                    var message = _serializer.Deserialize<Message>(messageString);

                    var type = Type.GetType(message.AssemblyQualifiedName);

                    var data = _serializer.Deserialize(type, message.Content);

                    _messageDispatcher.DispatchMessage(data);
                };

                channel.BasicConsume(
                    queue: queueName,
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine("Consuming");
                Console.ReadKey();
            }
        }
    }
}
