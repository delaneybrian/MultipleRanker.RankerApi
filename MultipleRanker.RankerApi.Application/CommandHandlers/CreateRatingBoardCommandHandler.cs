using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;
using Optional;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class CreateRatingBoardCommandHandler : IRequestHandler<CreateRatingBoardCommand, Option<string>>
    {
        private readonly IRatingBoardValidator _ratingBoardValidator;
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly ITimeProvider _timeProvider;

        public CreateRatingBoardCommandHandler(
            IRatingBoardValidator ratingBoardValidator,
            IRatingBoardRepository ratingBoardRepository,
            ITimeProvider timeProvider)
        {
            _ratingBoardValidator = ratingBoardValidator;
            _ratingBoardRepository = ratingBoardRepository;
            _timeProvider = timeProvider;
        }

        public async Task<Option<string>> Handle(CreateRatingBoardCommand request, CancellationToken cancellationToken)
        {
            var ratingBoard = new RatingBoard
            {
                Id = Guid.NewGuid(),
                CreatedBy = request.CreatedBy,
                CreatedAtUtc = _timeProvider.GetDateTimeNowUtc(),
                Participants = new List<Participant>(),
                RatingLists = new List<RatingList>(),
                SubType = request.SubType,
                Type = request.Type
            };

            await _ratingBoardRepository.AddRatingBoard(ratingBoard);

            return Option.Some("hello");
        }
    }
}
