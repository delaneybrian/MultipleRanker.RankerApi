using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Contracts.Events;
using MultipleRanker.RankerApi.Definitions.Commands;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddResultsCommandHandler : AsyncRequestHandler<AddResultsCommand>
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IResultRepository _resultRepository;
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public AddResultsCommandHandler(
            IMessagePublisher messagePublisher,
            IResultRepository resultRepository,
            IRatingBoardRepository ratingBoardRepository)
        {
            _messagePublisher = messagePublisher;
            _resultRepository = resultRepository;
            _ratingBoardRepository = ratingBoardRepository;
        }

        protected override async Task Handle(AddResultsCommand request, CancellationToken cancellationToken)
        {
            var resultId = Guid.NewGuid();

            await _resultRepository.AddResult(new Result
            {
                Id = resultId,
                ParticipantResults = request.ParticipantResults,
                RatingBoardIdsAppliedTo = request.RatingBoardIdsToApply
            });

            foreach (var ratingBoardId in request.RatingBoardIdsToApply)
            {
                var ratingBoard = await _ratingBoardRepository.GetRatingBoard(ratingBoardId);

                foreach (var ratingList in ratingBoard.RatingLists)
                {
                    _messagePublisher.Publish(
                        new ResultAdded
                        {
                            RatingListId = ratingList.Id,
                            ResultId = resultId,
                            ResultTimeUtc = request.ResultTimeUtc,
                            ParticipantResults = request.ParticipantResults
                        },
                        request.CorrelationId);
                }
            }
        }
    }
}