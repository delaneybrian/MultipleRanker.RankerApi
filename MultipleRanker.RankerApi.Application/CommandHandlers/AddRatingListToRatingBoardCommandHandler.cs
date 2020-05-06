using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddRatingListToRatingBoardCommandHandler : AsyncRequestHandler<AddRatingListToRatingBoardCommand>
    {
        private readonly IRatingBoardRepository _ratingBoardRepository;
        private readonly IMessagePublisher _messagePublisher;
        public AddRatingListToRatingBoardCommandHandler(
            IRatingBoardRepository ratingBoardRepository,
            IMessagePublisher messagePublisher)
        {
            _ratingBoardRepository = ratingBoardRepository;
            _messagePublisher = messagePublisher;
        }

        protected override async Task Handle(AddRatingListToRatingBoardCommand request, CancellationToken cancellationToken)
        {
            await _ratingBoardRepository.AddRatingList(request.RatingBoardId, request.RatingList);

            //_messagePublisher.Publish(
            //    new RatingListCreated
            //    {

            //    },
            //    request.CorrelationId);
        }
    }
}
