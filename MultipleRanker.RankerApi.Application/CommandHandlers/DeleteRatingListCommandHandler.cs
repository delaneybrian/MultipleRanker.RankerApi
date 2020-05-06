using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts.Events;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class DeleteRatingListCommandHandler : AsyncRequestHandler<DeleteRatingListCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly IMessagePublisher _messagePublisher;

        public DeleteRatingListCommandHandler(
            IRatingBoardRepository ratingBoardRepository,
            IMessagePublisher messagePublisher)
        {
            _ratingBoardRepository = ratingBoardRepository;
            _messagePublisher = messagePublisher;
        }

        protected override async Task Handle(DeleteRatingListCommand request, CancellationToken cancellationToken)
        {
            await _ratingBoardRepository.RemoveRatingList(request.RatingBoardId, request.RatingListId);

            _messagePublisher.Publish(
                new RatingListDeleted
                {
                    RatingListId = request.RatingListId,
                    RatingBoardId = request.RatingBoardId
                },
                request.CorrelationId);
        }
    }
}
