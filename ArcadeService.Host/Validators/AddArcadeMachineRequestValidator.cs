using ArcadeService.Models.Requests;
using FluentValidation;

namespace ArcadeService.Host.Validators
{
    public class AddArcadeMachineRequestValidator
        : AbstractValidator<AddArcadeMachineRequest>
    {
        public AddArcadeMachineRequestValidator()
        {
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Year).GreaterThan(1970);
            RuleFor(x => x.BasePrice).GreaterThan(0);
        }
    }
}
