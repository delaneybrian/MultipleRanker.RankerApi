using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingBoardRepository
    {
        Task AddRatingBoard(RatingBoard ratingBoard);

        Task AddParticipantToRatingBoard(Guid ratingBoardId, Participant participant);

        Task AddRatingListToRatingBoard(Guid ratingBoardId, RatingList ratingList);

        Task<RatingBoard> GetRatingBoard(Guid ratingBoardId);
    }
}
