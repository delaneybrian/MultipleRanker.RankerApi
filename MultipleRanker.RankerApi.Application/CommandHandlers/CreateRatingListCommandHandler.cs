using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Contracts.Events;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class CreateRatingListCommandHandler : AsyncRequestHandler<CreateRatingListCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly IMessagePublisher _messagePublisher;
        private readonly ITimeProvider _timeProvider;

        public CreateRatingListCommandHandler(
            IRatingBoardRepository ratingBoardRepository,
            IMessagePublisher messagePublisher,
            ITimeProvider timeProvider)
        {
            _ratingBoardRepository = ratingBoardRepository;
            _messagePublisher = messagePublisher;
            _timeProvider = timeProvider;
        }

        protected override async Task Handle(CreateRatingListCommand request, CancellationToken cancellationToken)
        {
            var createdOnUtc = _timeProvider.GetDateTimeNowUtc();
            var ratingListId = Guid.NewGuid();

            var ratingList = new RatingList
            {
                Id = ratingListId,
                CreatedOnUtc = createdOnUtc,
                RatingAggregation = request.RatingAggregationType,
                RatingType = request.RatingType
            };

            await _ratingBoardRepository.AddRatingList(request.RatingBoardId, ratingList);

            _messagePublisher.Publish(
                new RatingListCreated
                {
                    RatingListId = ratingListId,
                    RatingBoardId = request.RatingBoardId,
                    CreatedOnUtc = createdOnUtc,
                    RatingAggregation = request.RatingAggregationType,
                    RatingType = request.RatingType                 
                },
                request.CorrelationId);
        }
    }
}
