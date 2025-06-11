using Domain.Entities;
using Domain.Shared.Enums;
using Domain.Shared.Results;
using Domain.Shared.ValueObjects;
using MediatR;

namespace Application.Features.Personeller.Command.Update
{
    public class UpdatePersonelCommand : IRequest<IResultBase>
    {
        public int id { get; set; } = default!;
        public string Ad { get; set; } = default!;
        public string Soyad { get; set; } = default!;
        public SicilNo SicilNo { get; set; } = default!;
        public Unvan Unvan { get; set; } = default!;
        public PhoneNumber? PhoneNumber { get; set; }
        public Email? Email { get; set; }
        public DateTime MemuriyetBaslamaTarihi { get; set; } = default!;
        public DateTime AsaletTarihi { get; set; }
        public DateTime AyrilisTarihi { get; set; }
        public string AyrilisNedeni { get; set; } = string.Empty;
        public KullaniciSifre KullaniciSifre { get; set; } = null!;
        public Rol Rol { get; private set; }
    }
}
