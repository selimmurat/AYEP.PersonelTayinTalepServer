using FluentValidation;

namespace Application.Features.PersonelTayinTalepleri.Command.Delete.PersonelTayinTalepTercih
{
    public class DeletePersonelTayinTalepTercihCommandValidator : AbstractValidator<DeletePersonelTayinTalepTercihCommand>
    {
        public DeletePersonelTayinTalepTercihCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçersiz tercih ID");
        }
    }
}
