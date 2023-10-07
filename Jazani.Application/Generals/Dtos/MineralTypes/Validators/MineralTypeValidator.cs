using FluentValidation;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Validators
{
    public class MineralTypeValidator :AbstractValidator<MineralTypeSavaDto>
    {
        public MineralTypeValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }

    }
}
