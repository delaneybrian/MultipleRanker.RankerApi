using System.Threading.Tasks;
using MediatR;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IMessageDispatcher
    {
        Task DispatchMessage(IRequest cmd);
    }
}
