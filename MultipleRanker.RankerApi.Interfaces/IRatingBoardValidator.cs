using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface IRatingBoardValidator
    {
        bool IsValid(RatingBoard ratingBoard);
    }
}
