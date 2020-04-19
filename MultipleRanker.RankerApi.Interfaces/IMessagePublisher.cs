using System;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IMessagePublisher
    {
        void Publish<T>(T content, Guid correlationId) where T : class;
    }
}
