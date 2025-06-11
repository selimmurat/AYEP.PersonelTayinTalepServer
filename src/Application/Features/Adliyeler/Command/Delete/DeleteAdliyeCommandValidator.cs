using FluentValidation;

namespace Application.Features.Adliyeler.Command.Delete
{
    public class DeleteAdliyeCommandValidator : AbstractValidator<DeleteAdliyeCommand>
    {
        public DeleteAdliyeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Id belirtilmelidir.");
        }
    }
}
