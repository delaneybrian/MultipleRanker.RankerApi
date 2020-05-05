using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class CreateParticipantCommandHandler : AsyncRequestHandler<CreateParticipantCommand>
    {
        private readonly IParticipantRepository _participantRepository;

        public CreateParticipantCommandHandler(
            IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        protected override async Task Handle(
            CreateParticipantCommand request, 
            CancellationToken cancellationToken)
        {
            await _participantRepository.AddParticipant(request.Participant);
        }
    }
}
