using FluentValidation;
using JPSAGE_ERP.Application.Models.SiteReporting;

namespace JPSAGE_ERP.Application.Validators
{
    public class DailyReportFormDTOValidator : AbstractValidator<DailyReportFormDTO>
    {
        public DailyReportFormDTOValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Enter a valid value")
                .GreaterThan(0).WithMessage("ProjectId must be an integer");
            RuleFor(x => x.WFDefId)
                .NotEmpty().WithMessage("Enter a valid value")
                .GreaterThan(0).WithMessage("ProjectId must be an integer");
            RuleFor(x => x.GeneralSummary)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.ConstructionActivities)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.DailyProgress)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.FollowingDayPlan)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.ProgressAt)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.ConstructionActual)
                .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Planned)
                .NotEmpty().WithMessage("Enter a valid value");
            //RuleFor(x => x.DailyReportingProgressMeasurement)
            //    .NotNull().WithMessage("The  Progress measurement report form shouldn't be empty");
        }
    }
}
