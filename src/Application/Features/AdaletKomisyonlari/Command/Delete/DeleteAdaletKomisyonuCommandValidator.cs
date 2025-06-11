using FluentValidation;

namespace Application.Features.AdaletKomisyonlari.Command.Delete
{
    public class DeleteAdaletKomisyonuCommandValidator : AbstractValidator<DeleteAdaletKomisyonuCommand>
    {
        public DeleteAdaletKomisyonuCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Adalet Komisyonu Id belirtilmelidir.");
        }
    }
}
