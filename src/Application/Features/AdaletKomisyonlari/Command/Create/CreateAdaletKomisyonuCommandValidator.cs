using FluentValidation;

namespace Application.Features.AdaletKomisyonlari.Command.Create
{
    public class CreateAdaletKomisyonuCommandValidator : AbstractValidator<CreateAdaletKomisyonuCommand>
    {
        public CreateAdaletKomisyonuCommandValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Komisyon adı boş olamaz.")
                .MaximumLength(100).WithMessage("Komisyon adı en fazla 120 karakter olmalıdır.");

            RuleFor(x => x.IlId)
                .GreaterThan(0).WithMessage("İl bilgisi zorunludur.");
        }
    }
}
