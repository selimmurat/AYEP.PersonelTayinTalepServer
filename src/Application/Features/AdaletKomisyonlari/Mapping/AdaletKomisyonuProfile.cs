using Application.Features.AdaletKomisyonlari.Command.Create;
using Application.Features.AdaletKomisyonlari.Command.Update;
using Application.Features.AdaletKomisyonlari.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AdaletKomisyonlari.Mapping
{
    public class AdaletKomisyonuProfile : Profile
    {
        public AdaletKomisyonuProfile()
        {
            CreateMap<CreateAdaletKomisyonuCommand, AdaletKomisyonu>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore());

            CreateMap<UpdateAdaletKomisyonuCommand, AdaletKomisyonu>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

            CreateMap<AdaletKomisyonu, AdaletKomisyonuDto>();
        }
    }
}