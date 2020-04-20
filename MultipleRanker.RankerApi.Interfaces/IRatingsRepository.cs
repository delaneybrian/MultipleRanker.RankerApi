using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingsRepository
    {
        Task AddRating(Guid id, Rating rating);

        Task<Rating> GetLatestRating(Guid id);

        Task<Ratings> GetAllRatings(Guid id);
    }
}
