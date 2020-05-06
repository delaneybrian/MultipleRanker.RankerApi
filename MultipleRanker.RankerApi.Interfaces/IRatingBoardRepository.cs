using System;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingBoardRepository
    {
        Task AddRatingBoard(RatingBoard ratingBoard);

        Task AddParticipant(Guid ratingBoardId, Participant participant);

        Task AddRatingList(Guid ratingBoardId, RatingList ratingList);

        Task<RatingBoard> GetRatingBoard(Guid ratingBoardId);

        Task RemoveRatingList(Guid ratingBoardId, Guid ratingListId);

        Task RemoveParticipant(Guid ratingBoardId, Guid participantId);

        Task DeleteRatingBoard(Guid ratingBoardId);
    }
}
