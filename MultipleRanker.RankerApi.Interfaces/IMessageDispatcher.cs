using System.Threading.Tasks;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IMessageDispatcher
    {
        Task DispatchMessage<T>(T cmd);
    }
}
