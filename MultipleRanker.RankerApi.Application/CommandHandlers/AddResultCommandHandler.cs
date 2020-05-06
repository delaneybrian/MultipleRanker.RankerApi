using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions.Commands;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class AddResultCommandHandler : AsyncRequestHandler<AddResultCommand>
    {
        public AddResultCommandHandler()
        {

        }

        protected override async Task Handle(AddResultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
