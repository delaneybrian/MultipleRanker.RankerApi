using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;
using Optional;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class CreateRatingBoardCommandHandler : IRequestHandler<CreateRatingBoardCommand, Option<string>>
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IRatingBoardValidator _ratingBoardValidator;
        private readonly IRatingBoardRepository _ratingBoardRepository;

        public CreateRatingBoardCommandHandler(
            IMessagePublisher messagePublisher,
            IRatingBoardValidator ratingBoardValidator,
            IRatingBoardRepository ratingBoardRepository)
        {
            _messagePublisher = messagePublisher;
            _ratingBoardValidator = ratingBoardValidator;
            _ratingBoardRepository = ratingBoardRepository;
        }

        public async Task<Option<string>> Handle(CreateRatingBoardCommand request, CancellationToken cancellationToken)
        {
            await _ratingBoardRepository.AddRatingBoard(request.RatingBoard);

            return Option.Some("hello");
        }
    }
}
