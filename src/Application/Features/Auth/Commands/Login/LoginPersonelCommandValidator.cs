using FluentValidation;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginPersonelCommandValidator : AbstractValidator<LoginPersonelCommand>
    {
        public LoginPersonelCommandValidator()
        {
            RuleFor(x => x.SicilNo)
                .NotEmpty().WithMessage("Sicil numarası boş olamaz.")
                .MaximumLength(10).WithMessage("Sicil numarası en fazla 10 karakter olmalı.");

            RuleFor(x => x.Sifre)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı.")
                .MaximumLength(32).WithMessage("Şifre en fazla 32 karakter olabilir.");
        }
    }
}
