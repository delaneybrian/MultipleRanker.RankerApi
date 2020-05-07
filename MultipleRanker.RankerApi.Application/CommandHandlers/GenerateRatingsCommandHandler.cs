using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts.Events;
using MultipleRanker.RankerApi.Definitions.Commands;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class GenerateRatingsCommandHandler : AsyncRequestHandler<GenerateRatingsCommand>
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public GenerateRatingsCommandHandler(
            IMessagePublisher messagePublisher,
            IRatingBoardRepository ratingBoardRepository)
        {
            _messagePublisher = messagePublisher;
            _ratingBoardRepository = ratingBoardRepository;
        }

        protected override async Task Handle(GenerateRatingsCommand request, CancellationToken cancellationToken)
        {
            var ratingBoard = await _ratingBoardRepository.GetRatingBoard(request.RatingBoardId);

            foreach (var ratingList in ratingBoard.RatingLists)
            {
                _messagePublisher.Publish(
                    new GenerateRatings
                    {
                        RatingListId = ratingList.Id
                    }, 
                    request.CorrelationId);
            }
        }
    }
}
