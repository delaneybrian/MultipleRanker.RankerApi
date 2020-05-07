using System;
using MediatR;
using MultipleRanker.RankerApi.Contracts;
using Optional;

namespace MultipleRanker.RankerApi.Definitions
{
    public class CreateRatingBoardCommand : IRequest<Option<string>>
    {
        public CreateRatingBoardCommand(
            string name,
            RatingBoardType type,
            RatingBoardSubType subType,
            Guid createdBy,
            Guid correlationId)
        {
            Name = name;
            Type = type;
            SubType = subType;
            CreatedBy = createdBy;
            CorrelationId = correlationId;
        }

        public string Name { get; }

        public RatingBoardType Type { get; set; }

        public RatingBoardSubType SubType { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid CorrelationId { get; }

    }
}
