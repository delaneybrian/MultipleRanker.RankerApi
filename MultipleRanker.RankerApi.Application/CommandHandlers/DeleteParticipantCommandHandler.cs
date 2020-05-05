using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MultipleRanker.RankerApi.Definitions;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.CommandHandlers
{
    public class DeleteParticipantCommandHandler : AsyncRequestHandler<DeleteParticipantCommand>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IParticipantValidator _participantValidator;

        public DeleteParticipantCommandHandler(
            IParticipantRepository participantRepository,
            IParticipantValidator participantValidator)
        {
            _participantRepository = participantRepository;
            _participantValidator = participantValidator;
        }

        protected override async Task Handle(
            DeleteParticipantCommand request, 
            CancellationToken cancellationToken)
        {
            var participant = await _participantRepository.GetParticipant(request.ParticipantId);

            if(_participantValidator.CanBeDeleted(participant))
                await _participantRepository.DeleteParticipant(request.ParticipantId);
        }
    }
}
