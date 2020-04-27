using System.Threading.Tasks;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IHandler
    {
    }

    public interface IHandler<in T> : IHandler
    {
        Task HandleAsync(T evt);
    }
}
