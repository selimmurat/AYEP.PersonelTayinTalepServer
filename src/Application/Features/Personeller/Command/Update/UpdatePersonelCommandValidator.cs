using FluentValidation;

namespace Application.Features.Personeller.Command.Update
{
    public class UpdatePersonelCommandValidator : AbstractValidator<UpdatePersonelCommand>
    {
        public UpdatePersonelCommandValidator()
        {
            RuleFor(x => x.SicilNo.sicilNo)
          .NotEmpty().WithMessage("Sicil No boş olamaz.")
          .Length(1, 50).WithMessage("Sicil No 1 ile 50 karakter arasında olmalıdır.");

        }

    }
}
