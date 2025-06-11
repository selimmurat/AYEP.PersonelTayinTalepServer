using FluentValidation;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Update
{
    public class UpdatePersonelBirimGorevlendirmeCommandValidator :AbstractValidator<UpdatePersonelBirimGorevlendirmeCommand>
    {
        public UpdatePersonelBirimGorevlendirmeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage("PersonelId alanı boş olamaz.");
            RuleFor(x => x.BirimId).NotEmpty().WithMessage("BirimId alanı boş olamaz.");
            RuleFor(x => x.Unvan).NotEmpty().WithMessage("Unvan alanı boş olamaz.");
            RuleFor(x => x.BaslangicTarihi).NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");
            RuleFor(x => x.BitisTarihi).GreaterThanOrEqualTo(x => x.BaslangicTarihi)
                .When(x => x.BitisTarihi.HasValue)
                .WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz.");
        }
    }
}
