using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Enums;

namespace Application.Features.PersonelBirimGorevlendirmeler.Mapping
{
    public class PersonelBirimGorevlendirmeProfile : Profile
    {
        public PersonelBirimGorevlendirmeProfile()
        {
            CreateMap<PersonelBirimGorevlendirme, PersonelBirimGorevlendirmeDto>()
                .ForMember(dest => dest.BirimAd,
                    opt => opt.MapFrom(src => src.Birim != null ? src.Birim.Ad : ""))
                .ForMember(dest => dest.AdliyeId,
                    opt => opt.MapFrom(src => src.Birim != null ? src.Birim.AdliyeId : 0))
                .ForMember(dest => dest.AdliyeAd,
                    opt => opt.MapFrom(src => src.Birim != null && src.Birim.Adliye != null ? src.Birim.Adliye.Ad : ""))
                .ForMember(dest => dest.KomisyonId,
                    opt => opt.MapFrom(src => src.Birim != null && src.Birim.Adliye != null ? src.Birim.Adliye.KomisyonId : 0))
                .ForMember(dest => dest.KomisyonAd,
                    opt => opt.MapFrom(src => src.Birim != null && src.Birim.Adliye != null && src.Birim.Adliye.Komisyon != null ? src.Birim.Adliye.Komisyon.Ad : ""))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PersonelId, opt => opt.MapFrom(src => src.PersonelId))
                .ForMember(dest => dest.BirimId, opt => opt.MapFrom(src => src.BirimId))
                .ForMember(dest => dest.BaslangicTarihi, opt => opt.MapFrom(src => src.BaslangicTarihi))
                .ForMember(dest => dest.BitisTarihi, opt => opt.MapFrom(src => src.BitisTarihi))
                .ForMember(dest => dest.Unvan, opt => opt.MapFrom(src =>
                    Enum.IsDefined(typeof(Unvan), src.UnvanId) ? (Unvan)src.UnvanId : Unvan.None))
                .ForMember(dest => dest.AktifMi, opt => opt.MapFrom(src => src.AktifMi))
                .ForMember(dest => dest.GorevAciklama, opt => opt.MapFrom(src => src.GorevAciklama));
        }
    }
}
