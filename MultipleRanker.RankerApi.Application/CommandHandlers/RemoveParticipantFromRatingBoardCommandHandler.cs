using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions.Commands;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class RemoveParticipantFromRatingBoardCommandHandler : AsyncRequestHandler<RemoveParticipantFromRatingBoardCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly IMessagePublisher _messagePublisher;

        public RemoveParticipantFromRatingBoardCommandHandler(
            IRatingBoardRepository ratingBoardRepository,
            IMessagePublisher messagePublisher)
        {
            _ratingBoardRepository = ratingBoardRepository;
            _messagePublisher = messagePublisher;
        }

        protected override async Task Handle(RemoveParticipantFromRatingBoardCommand request, CancellationToken cancellationToken)
        {
            await _ratingBoardRepository.RemoveParticipant(request.RatingBoardId, request.ParticipantId);

           // _messagePublisher.Publish(new ParticipantRemovedFromRatingList { }, request.CorrelationId);
        }
    }
}
