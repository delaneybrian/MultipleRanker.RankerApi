using System;
using System.Collections.Generic;
using MediatR;
using MultipleRanker.RankerApi.Contracts;

namespace MultipleRanker.RankerApi.Definitions.Commands
{
    public class AddResultCommand : IRequest
    {
        public Guid RatingBoardId { get; }

        public ICollection<ParticipantResult> ParticipantResults { get; }
    }
}
