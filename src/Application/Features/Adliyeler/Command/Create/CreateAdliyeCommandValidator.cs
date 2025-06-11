using FluentValidation;

namespace Application.Features.Adliyeler.Command.Create
{
    public class CreateAdliyeCommandValidator : AbstractValidator<CreateAdliyeCommand>
    {
        public CreateAdliyeCommandValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.")
                .MaximumLength(200).WithMessage("Ad alanı en fazla 200 karakter olabilir.");

            RuleFor(x => x.AdaletKomisyonuId)
                .GreaterThan(0).WithMessage("Adalet Komisyonu seçilmelidir.");

            RuleFor(x => x.IlId)
                .GreaterThan(0).WithMessage("İl seçilmelidir.");
        }
    }
}
