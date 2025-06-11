using FluentValidation;

namespace Application.Features.Birimler.Command.Create
{
    public class CreateBirimCommandValidator : AbstractValidator<CreateBirimCommand>
    {
        public CreateBirimCommandValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Birim adı boş olamaz.")
                .MaximumLength(150).WithMessage("Birim adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.AdliyeId)
                .GreaterThan(0).WithMessage("Adliye seçilmelidir.");
        }
    }
}
