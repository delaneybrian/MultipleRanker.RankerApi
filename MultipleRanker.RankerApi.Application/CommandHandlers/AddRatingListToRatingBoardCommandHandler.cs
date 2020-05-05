using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddRatingListToRatingBoardCommandHandler : AsyncRequestHandler<AddRatingListToRatingBoardCommand>
    {
        protected override async Task Handle(AddRatingListToRatingBoardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
