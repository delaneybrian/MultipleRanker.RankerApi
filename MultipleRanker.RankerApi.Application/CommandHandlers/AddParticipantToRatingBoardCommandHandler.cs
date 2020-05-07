using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Contracts.Dto;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddParticipantToRatingBoardCommandHandler : AsyncRequestHandler<AddParticipantToRatingBoardCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMessagePublisher _messagePublisher;

        public AddParticipantToRatingBoardCommandHandler(
            IRatingBoardRepository ratingBoardRepository,
            IParticipantRepository participantRepository,
            IMessagePublisher messagePublisher)
        {
            _ratingBoardRepository = ratingBoardRepository;
            _participantRepository = participantRepository;
            _messagePublisher = messagePublisher;
        }

        protected override async Task Handle(AddParticipantToRatingBoardCommand request, CancellationToken cancellationToken)
        {
            var participant = await _participantRepository.GetParticipant(request.ParticipantId);

            await _ratingBoardRepository.AddParticipant(request.RatingBoardId, participant);

            var ratingBoard = await _ratingBoardRepository.GetRatingBoard(request.RatingBoardId);

            foreach(var ratingList in ratingBoard.RatingLists)
            {
                _messagePublisher.Publish(new ParticipantAddedToRatingList 
                {
                    RatingListId = ratingList.Id,
                    ParticipantId = request.ParticipantId
                },
                request.CorrelationId);
            }
        }
    }
}
