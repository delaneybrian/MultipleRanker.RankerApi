using System;
using FluentValidation;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Application.Validation
{
    public class RatingBoardFluentValidator : AbstractValidator<RatingBoard>, IRatingBoardValidator
    {
        public RatingBoardFluentValidator()
        {
            RuleFor(ratingBoard => ratingBoard.Id != Guid.NewGuid());
            RuleFor(ratingBoard => ratingBoard.SubType != RatingBoardSubType.Unset);
            RuleFor(ratingBoard => ratingBoard.Type != RatingBoardType.Unset);
        }

        public bool IsValid(RatingBoard ratingBoard)
        {
            var validationResult = this.Validate(ratingBoard);

            return validationResult.IsValid;
        }
    }
}
