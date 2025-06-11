using Application.Features.Personeller.Dtos;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Application.Features.Personeller.Mapping
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile()
        {
            // Personel -> PersonelDto
            CreateMap<Personel, PersonelDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Ad))
                .ForMember(dest => dest.Soyad, opt => opt.MapFrom(src => src.Soyad))
                .ForMember(dest => dest.SicilNo, opt => opt.MapFrom(src => src.SicilNo.sicilNo))
                .ForMember(dest => dest.Unvan, opt => opt.MapFrom(src => src.Unvan.ToString()))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber != null ? src.PhoneNumber.Number : ""))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email != null ? src.Email.Value : ""))
                .ForMember(dest => dest.MemuriyetBaslamaTarihi, opt => opt.MapFrom(src => src.MemuriyetBaslamaTarihi))
                .ForMember(dest => dest.AsaletTarihi, opt => opt.MapFrom(src => src.AsaletTarihi))
                .ForMember(dest => dest.AyrilisTarihi, opt => opt.MapFrom(src => src.AyrilisTarihi))
                .ForMember(dest => dest.AyrilisNedeni, opt => opt.MapFrom(src => src.AyrilisNedeni))
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol.ToString()))
                // Hesaplanmış: Aktif mi? (Ayrılış tarihi yoksa aktif)
                .ForMember(dest => dest.AktifMi, opt => opt.MapFrom(src => src.AyrilisTarihi == null))
                // Navigation: Aktif Görevlendirmeler (varsa)
                .ForMember(dest => dest.AktifGorevlendirmeler,
                    opt => opt.MapFrom(src => src.PersonelGorevlendirmeleri
                        .Where(pg => pg.AktifMi)
                        .Select(pg => new PersonelGorevlendirmeShortDto
                        {
                            BirimAd = pg.Birim != null ? pg.Birim.Ad : "",
                            BirimId = pg.BirimId,
                            Unvan = pg.UnvanId.ToString(),
                            BaslangicTarihi = pg.BaslangicTarihi,
                        }).ToList())
                );

            // Personel -> CreatedPersonelDto (ilk create dönüşü için)
            CreateMap<Personel, CreatedPersonelDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Ad))
                .ForMember(dest => dest.Soyad, opt => opt.MapFrom(src => src.Soyad))
                .ForMember(dest => dest.SicilNo, opt => opt.MapFrom(src => src.SicilNo.sicilNo))
                .ForMember(dest => dest.Unvan, opt => opt.MapFrom(src => src.Unvan.ToString()))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber != null ? src.PhoneNumber.Number : ""))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email != null ? src.Email.Value : ""))
                .ForMember(dest => dest.MemuriyetBaslamaTarihi, opt => opt.MapFrom(src => src.MemuriyetBaslamaTarihi))
                .ForMember(dest => dest.AsaletTarihi, opt => opt.MapFrom(src => src.AsaletTarihi))
                .ForMember(dest => dest.AyrilisTarihi, opt => opt.MapFrom(src => src.AyrilisTarihi))
                .ForMember(dest => dest.AyrilisNedeni, opt => opt.MapFrom(src => src.AyrilisNedeni))
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol.ToString())) ;

        }
    }

    
    public class PersonelGorevlendirmeShortDto
    {
        public int BirimId { get; set; }
        public string BirimAd { get; set; } = string.Empty;
        public string Unvan { get; set; } = string.Empty;
        public DateTime BaslangicTarihi { get; set; }
    }
}
