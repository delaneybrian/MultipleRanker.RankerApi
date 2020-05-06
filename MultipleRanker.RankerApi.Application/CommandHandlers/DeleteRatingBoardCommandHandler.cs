using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class DeleteRatingBoardCommandHandler : AsyncRequestHandler<DeleteRatingBoardCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public DeleteRatingBoardCommandHandler(
            IRatingBoardRepository ratingBoardRepository)
        {
            _ratingBoardRepository = ratingBoardRepository;
        }

        protected override async Task Handle(DeleteRatingBoardCommand request, CancellationToken cancellationToken)
        {
            await _ratingBoardRepository.DeleteRatingBoard(request.RatingBoardId);
        }
    }
}
