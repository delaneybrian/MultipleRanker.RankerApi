using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IResultRepository
    {
        Task AddResult(Result result);

        Task RemoveResult(Guid resultId);

        Task AddRatingBoardToResult(Guid resultId, Guid ratingBoardId);

        Task RemoveRatingBoardFromResult(Guid resultId, Guid ratingBoardId);

        Task<ICollection<Result>> GetResultsForRatingBoard(Guid ratingBoardId);
    }
}
