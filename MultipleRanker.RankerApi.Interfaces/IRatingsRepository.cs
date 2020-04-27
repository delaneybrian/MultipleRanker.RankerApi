using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingsRepository
    {
        Task AddRatingBoard(Guid ratingBoardId);

        Task AddRating(Guid ratingBoardId, Rating rating);

        Task<Rating> GetLatestRating(Guid ratingBoardId);

        Task<Ratings> GetAllRatings(Guid ratingBoardId);
    }
}
