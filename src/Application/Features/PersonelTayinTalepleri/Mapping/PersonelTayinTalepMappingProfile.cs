using Application.Features.PersonelTayinTalepleri.Command.Create.PersonelTayinTalepTercih;
using Application.Features.PersonelTayinTalepleri.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PersonelTayinTalepleri.Mapping
{
    public class PersonelTayinTalepMappingProfile : Profile
    {
        public PersonelTayinTalepMappingProfile()
        {
            // Create işlemi
            CreateMap<CreatePersonelTayinTalepDto, PersonelTayinTalep>()
                .ForMember(dest => dest.Tercihler, opt => opt.MapFrom(src => src.Tercihler))
                .ForMember(dest => dest.Gerekceler, opt => opt.MapFrom(src => src.Gerekceler.Select(x => new PersonelTayinTalepGerekce { Gerekce = (Domain.Shared.Enums.TayinTalepGerekce)x })));

            CreateMap<CreatePersonelTayinTalepTercihCommand, PersonelTayinTalepTercih>();

            // Tercih listeleme işlemi için
            CreateMap<PersonelTayinTalepTercih, PersonelTayinTalepTercihListDto>()
                .ForMember(dest => dest.AdliyeAdi, opt => opt.MapFrom(src => src.Adliye.Ad));

            CreateMap<PersonelTayinTalepTercih, PersonelTayinTalepTercihDto>();
        }
    }
}
