using FluentValidation;

namespace Application.Features.PersonelTayinTalepleri.Command.Create.PersonelTayinTalepTercih
{
    public class CreatePersonelTayinTalepTercihCommandValidator : AbstractValidator<CreatePersonelTayinTalepTercihCommand>
    {
        public CreatePersonelTayinTalepTercihCommandValidator()
        {
            RuleFor(x => x.AdliyeId).GreaterThan(0);
            RuleFor(x => x.TercihSirasi).InclusiveBetween(1, 5);
        }
    }
}
