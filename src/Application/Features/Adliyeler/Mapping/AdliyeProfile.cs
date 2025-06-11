using Application.Features.Adliyeler.Command.Create;
using Application.Features.Adliyeler.Command.Update;
using Application.Features.Adliyeler.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Adliyeler.Mapping
{
    public class AdliyeProfile : Profile
    {
        public AdliyeProfile()
        {
          
            CreateMap<CreateAdliyeCommand, Adliye>()
                .ForMember(dest => dest.KomisyonId, opt => opt.MapFrom(src => src.AdaletKomisyonuId));          
            CreateMap<UpdateAdliyeCommand, Adliye>()
                .ForMember(dest => dest.KomisyonId, opt => opt.MapFrom(src => src.AdaletKomisyonuId));
            
            CreateMap<Adliye, AdliyeDto>();            
            CreateMap<AdliyeDto, Adliye>();
        }
    }
}