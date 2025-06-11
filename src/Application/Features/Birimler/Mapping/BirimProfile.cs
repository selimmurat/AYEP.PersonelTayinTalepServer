using Application.Features.Birimler.Command.Create;
using Application.Features.Birimler.Command.Update;
using Application.Features.Birimler.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Birimler.Mapping
{
    public class BirimProfile : Profile
    {
        public BirimProfile()
        {
            // Entity <-> Dto
            CreateMap<Birim, BirimDto>()
                .ForMember(dest => dest.AdliyeAd, opt => opt.MapFrom(src => src.Adliye != null ? src.Adliye.Ad : null));

            // Command -> Entity
            CreateMap<CreateBirimCommand, Birim>();
            CreateMap<UpdateBirimCommand, Birim>();

           // Dto'dan Entity'ye map
            CreateMap<BirimDto, Birim>()
                .ForMember(dest => dest.Adliye, opt => opt.Ignore()); 
        }
    }
}
