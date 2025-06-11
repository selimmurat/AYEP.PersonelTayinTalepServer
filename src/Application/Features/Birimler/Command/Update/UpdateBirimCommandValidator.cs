using FluentValidation;

namespace Application.Features.Birimler.Command.Update
{
    public class UpdateBirimCommandValidator : AbstractValidator<UpdateBirimCommand>
    {
        public UpdateBirimCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Birim Id geçerli olmalı.");
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Birim adı boş olamaz.")
                .MaximumLength(150).WithMessage("Birim adı en fazla 150 karakter olabilir.");
            RuleFor(x => x.AdliyeId).GreaterThan(0).WithMessage("Adliye seçilmelidir.");
        }
    }
}
