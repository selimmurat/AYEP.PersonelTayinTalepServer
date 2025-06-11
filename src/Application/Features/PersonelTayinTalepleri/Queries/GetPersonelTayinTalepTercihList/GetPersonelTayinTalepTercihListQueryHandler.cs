using Application.Features.PersonelTayinTalepleri.Dtos;
using AutoMapper;
using Domain.Repositories.Personeller;
using Domain.Repositories.PersonelTayinTalepleri;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries.GetPersonelTayinTalepTercihList
{
    public class GetPersonelTayinTalepTercihListQueryHandler(
        IPersonelTayinTalepRepository personelTayinTalepRepository, 
        IMapper mapper) : IRequestHandler<GetPersonelTayinTalepTercihListQuery, List<PersonelTayinTalepTercihListDto>>
    {
        private readonly IPersonelTayinTalepRepository _personelTayinTalepRepository = personelTayinTalepRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<PersonelTayinTalepTercihListDto>> Handle(GetPersonelTayinTalepTercihListQuery request, CancellationToken cancellationToken)
        {
            var talep = await _personelTayinTalepRepository.GetByIdWithDetailsAsync(request.PersonelTayinTalepId, cancellationToken) 
                                                                             ?? throw new Exception("Tayin talebi bulunamadı.");
            
            var dtoList = talep.Tercihler
                .OrderBy(t => t.TercihSirasi)
                .Select(t => new PersonelTayinTalepTercihListDto
                {
                    Id = t.Id,
                    AdliyeId = t.AdliyeId,
                    AdliyeAdi = t.Adliye?.Ad ?? string.Empty,
                    TercihSirasi = t.TercihSirasi
                }).ToList();

            return dtoList;
        }
    }
}
