using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddParticipantToRatingBoardCommandHandler : AsyncRequestHandler<AddParticipantToRatingBoardCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public AddParticipantToRatingBoardCommandHandler(
            IRatingBoardRepository ratingBoardRepository)
        {
            _ratingBoardRepository = ratingBoardRepository;
        }

        protected override async Task Handle(AddParticipantToRatingBoardCommand request, CancellationToken cancellationToken)
        {


            await _ratingBoardRepository.AddParticipantToRatingBoard(request.RatingBoardId, request.Participant);
        }
    }
}
