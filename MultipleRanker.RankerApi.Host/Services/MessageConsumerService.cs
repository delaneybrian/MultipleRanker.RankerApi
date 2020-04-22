using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Services
{
    internal class MessageConsumerService : BackgroundService
    {
        private readonly IMessageSubscriber _messageSubscriber;

        public MessageConsumerService(IMessageSubscriber messageSubscriber)
        {
            _messageSubscriber = messageSubscriber;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Task.Run(
                    () => _messageSubscriber.Start(stoppingToken));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
            return Task.CompletedTask;
        }
    }
}
