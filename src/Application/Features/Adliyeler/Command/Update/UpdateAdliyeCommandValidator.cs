using FluentValidation;

namespace Application.Features.Adliyeler.Command.Update
{
    public class UpdateAdliyeCommandValidator : AbstractValidator<UpdateAdliyeCommand>
    {
        public UpdateAdliyeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Id belirtilmelidir.");

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
