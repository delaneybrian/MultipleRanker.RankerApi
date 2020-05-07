using System;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Definitions;

namespace MultipleRanker.RankerApi.Host
{
    internal static class CreateRatingBoardDtoEx
    {
        public static CreateRatingBoardCommand ToCommand(
            this CreateRatingBoardDto createRatingBoardDto,
            Guid correlationId)
        {
            return new CreateRatingBoardCommand(
                createRatingBoardDto.Name,
                createRatingBoardDto.Type,
                createRatingBoardDto.SubType,
                createRatingBoardDto.CreatedBy,
                correlationId);
        }
    }
}
