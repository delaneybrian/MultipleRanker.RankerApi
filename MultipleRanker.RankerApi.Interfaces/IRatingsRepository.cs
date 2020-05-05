using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingsRepository
    {
        Task AddRatingBoard(Guid ratingBoardId);

        Task AddRatingBoard(Guid ratingBoardId, RatingBoard ratingBoard);

        Task<RatingList> GetLatestRating(Guid ratingBoardId);

        Task<RatingList> GetAllRatings(Guid ratingBoardId);
    }
}
