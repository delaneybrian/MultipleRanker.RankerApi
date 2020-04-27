using System.Threading.Tasks;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application
{
    public class CreateRatingBoardHandler : IHandler<CreateRatingBoard>
    {
        private readonly IRatingsRepository _ratingsRepository;

        public CreateRatingBoardHandler(IRatingsRepository ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }

        public async Task HandleAsync(CreateRatingBoard evt)
        {
            await _ratingsRepository.AddRatingBoard(evt.Id);
        }
    }
}
