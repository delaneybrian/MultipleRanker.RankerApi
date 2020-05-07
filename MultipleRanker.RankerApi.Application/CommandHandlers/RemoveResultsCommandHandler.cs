using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts.Events;
using MultipleRanker.RankerApi.Definitions.Commands;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class RemoveResultsCommandHandler : AsyncRequestHandler<RemoveResultsCommand>
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public RemoveResultsCommandHandler(
            IResultRepository resultRepository,
            IMessagePublisher messagePublisher,
            IRatingBoardRepository ratingBoardRepository)
        {
            _resultRepository = resultRepository;
            _messagePublisher = messagePublisher;
            _ratingBoardRepository = ratingBoardRepository;
        }

        protected override async Task Handle(RemoveResultsCommand request, CancellationToken cancellationToken)
        {
            foreach (var ratingBoardId in request.RatingBoardIdsToRemoveFrom)
            {
                await _resultRepository.RemoveRatingBoardFromResult(request.ResultId, ratingBoardId);

                var ratingBoard = await _ratingBoardRepository.GetRatingBoard(ratingBoardId);

                foreach (var ratingList in ratingBoard.RatingLists)
                {
                    _messagePublisher.Publish(
                        new ResultRemoved
                        {
                            RatingListId = ratingList.Id,
                            ResultId = request.ResultId
                        },
                        request.CorrelationId);
                }
            }
        }
    }
}