using FluentValidation;

namespace Application.Features.Personeller.Command.Delete
{
    public class DeletePersonelCommandValidator : AbstractValidator<DeletePersonelCommand>
    {
        public DeletePersonelCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir personel Id'si girilmelidir.");
        }
    }
}
