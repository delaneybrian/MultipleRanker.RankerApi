using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IHistoricalRatingsRepository
    {
        Task AddHistoricalRating(HistoricalRating historicalRating);

        Task<IEnumerable<HistoricalRating>> GetAllHistoricalRatingsForRatingList(Guid ratingListId);
    }
}
