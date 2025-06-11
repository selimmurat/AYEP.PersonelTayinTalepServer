using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonelBirimGorevlendirmeler.Command.Create
{
    public class CreatePersonelBirimGorevlendirmeValidator : AbstractValidator<CreatePersonelBirimGorevlendirmeCommand>
    {
        public CreatePersonelBirimGorevlendirmeValidator()
        {
            RuleFor(x => x.PersonelId)
                .GreaterThan(0).WithMessage("Personel seçilmelidir.");
            RuleFor(x => x.BirimId)
                .GreaterThan(0).WithMessage("Birim seçilmelidir.");
            RuleFor(x => x.BaslangicTarihi)
                .NotEmpty().WithMessage("Görevlendirme tarihi boş olamaz.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Görevlendirme tarihi gelecekte olamaz.");
        }
    }
}
