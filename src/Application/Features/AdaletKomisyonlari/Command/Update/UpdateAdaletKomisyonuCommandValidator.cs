using FluentValidation;

namespace Application.Features.AdaletKomisyonlari.Command.Update
{
    public class UpdateAdaletKomisyonuCommandValidator : AbstractValidator<UpdateAdaletKomisyonuCommand>
    {
        public UpdateAdaletKomisyonuCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Adalet Komisyonu Id belirtilmelidir.");

            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Ad alanı boş olamaz.")
                .MaximumLength(200).WithMessage("Komisyon adı en fazla 120 karakter olmalıdır.");

            RuleFor(x => x.IlId)
                .GreaterThan(0).WithMessage("İl seçilmelidir.");
        }
    }
}
