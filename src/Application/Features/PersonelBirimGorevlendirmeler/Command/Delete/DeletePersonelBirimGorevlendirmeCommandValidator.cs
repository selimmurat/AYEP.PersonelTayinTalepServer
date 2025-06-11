using FluentValidation;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Delete
{
    public class DeletePersonelBirimGorevlendirmeCommandValidator : AbstractValidator<DeletePersonelBirimGorevlendirmeCommand>
    {
        public DeletePersonelBirimGorevlendirmeCommandValidator()
        {
            RuleFor(x => x.PersonelId).NotEmpty().WithMessage("Personel ID boş olamaz.");
            RuleFor(x => x.BirimId).NotEmpty().WithMessage("Birim ID boş olamaz.");
            RuleFor(x => x.Unvan).NotEmpty().WithMessage("Unvan boş olamaz.");
        }
    }
}
