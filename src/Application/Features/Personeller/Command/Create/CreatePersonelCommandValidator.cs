using FluentValidation;

namespace Application.Features.Personeller.Command.Create
{
    public class CreatePersonelCommandValidator : AbstractValidator<CreatePersonelCommand>
    {
        public CreatePersonelCommandValidator()
        {
            RuleFor(x => x.SicilNo)
           .NotEmpty().WithMessage("Sicil No boş olamaz.")
           .Length(1, 50).WithMessage("Sicil No 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.TCKimlikNo)
                .NotEmpty().WithMessage("T.C. Kimlik No boş olamaz.")
                .Length(11).WithMessage("T.C. Kimlik No 11 karakter olmalıdır.");

            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .Length(1, 50).WithMessage("Ad 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Soyad)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .Length(1, 50).WithMessage("Soyad 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Cinsiyet)
                .InclusiveBetween(1, 3).WithMessage("Cinsiyet alanını doğru girmelisiniz.");

            RuleFor(x => x.Unvan)
                .NotEmpty().WithMessage("Unvan boş olamaz.")
                .Length(1, 50).WithMessage("Unvan 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(x=>x.IlkGirisTarihi)
                .NotEmpty().WithMessage("İlk giriş tarihi boş olamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("İlk giriş tarihi bugünün tarihinden büyük olamaz.");

        }
    }
}
