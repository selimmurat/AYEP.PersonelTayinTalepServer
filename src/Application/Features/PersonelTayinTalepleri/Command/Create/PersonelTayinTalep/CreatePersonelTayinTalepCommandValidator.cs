using Application.Features.PersonelTayinTalepleri.Command.Create.PersonelTayinTalepTercih;
using Application.Features.PersonelTayinTalepleri.Dtos;
using Domain.Repositories.PersonelTayinTalepleri;
using FluentValidation;

namespace Application.Features.PersonelTayinTalepleri.Command.Create.CreatePersonelTayinTalep
{
    public class CreatePersonelTayinTalepCommandValidator : AbstractValidator<CreatePersonelTayinTalepCommand>
    {
        private readonly IPersonelTayinTalepRepository _repo;

        public CreatePersonelTayinTalepCommandValidator(IPersonelTayinTalepRepository repo)
        {
            _repo = repo;

            RuleFor(x => x.Model.PersonelId)
                .GreaterThan(0).WithMessage("Personel zorunludur.");

            RuleFor(x => x.Model.TalepTuru)
                .IsInEnum().WithMessage("Talep türü hatalı.");

            RuleFor(x => x.Model.TalepNedeni)
                .IsInEnum().WithMessage("Talep nedeni hatalı.");

            RuleFor(x => x.Model.Tercihler)
                .NotNull()
                .Must(list => list.Count > 0 && list.Count <= 5)
                .WithMessage("En fazla 5, en az 1 tercih girilmelidir.");

            RuleForEach(x => x.Model.Tercihler)
                .SetValidator(new CreatePersonelTayinTalepTercihCommandValidator());

            RuleFor(x => x.Model)
                .MustAsync(NotExistsActiveTayinTalep)
                .WithMessage("Personelin zaten aktif bir tayin talebi bulunmakta.");
        }

        private async Task<bool> NotExistsActiveTayinTalep(
            CreatePersonelTayinTalepDto dto,
            CancellationToken cancellationToken)
        {
            // Yalnızca iptal edilmemiş, kapatılmamış bir talep varsa false döner!
            return !await _repo.ExistsActiveByPersonelIdAsync(dto.PersonelId, cancellationToken);
        }
    }
}
