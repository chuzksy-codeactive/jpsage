using FluentValidation;
using JPSAGE_ERP.Application.Models.SiteReporting;
using System;

namespace JPSAGE_ERP.Application.Validators
{
    public class TechnicalQueriesFormDtoValidator : AbstractValidator<TechnicalQueriesFormDto>
    {
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        public TechnicalQueriesFormDtoValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.CtqTitle)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.StateId)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.CtqNumber)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.QueryDate)
                .NotEmpty()
                .WithMessage("Enter a valid value")
                .Must(BeAValidDate).WithMessage("Enter a valid date");
            RuleFor(x => x.CtqDescription)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.AttendeeId)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.Priority)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Enter a valid value");
        }
    }

    public class AttiontionReplyFormDtoValidator : AbstractValidator<AttentionReplyFormDto>
    {
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        public AttiontionReplyFormDtoValidator()
        {
            RuleFor(x => x.AttentionReply)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.AttentionDate)
                .NotEmpty()
                .WithMessage("Enter a valid date")
                .Must(BeAValidDate).WithMessage("Enter a valid date");
        }
    }

    public class InitiatorReplyFormDtoValidator : AbstractValidator<InitiatorReplyFormDto>
    {
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        public InitiatorReplyFormDtoValidator()
        {
            RuleFor(x => x.InitiatorReply)
                .NotEmpty()
                .WithMessage("Enter a valid value");
            RuleFor(x => x.InitiatorReplyDate)
                .NotEmpty()
                .WithMessage("Enter a valid date")
                .Must(BeAValidDate).WithMessage("Enter a valid date");
            RuleFor(x => x.InitiatorAcceptance)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Enter a valid value");
        }
    }
}
