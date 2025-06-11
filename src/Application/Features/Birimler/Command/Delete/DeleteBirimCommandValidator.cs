using FluentValidation;

namespace Application.Features.Birimler.Command.Delete
{
    public class DeleteBirimCommandValidator : AbstractValidator<DeleteBirimCommand>
    {
        public DeleteBirimCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir Birim Id belirtilmelidir.");
        }
    }
}
