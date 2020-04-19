using System.Threading;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IMessageSubscriber
    {
        void Start(CancellationToken cancellationToken);
    }
}
