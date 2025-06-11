using Domain.Shared.Enums;
using System;

namespace Application.Features.PersonelBirimGorevlendirmeler.Dtos
{
    public class PersonelBirimGorevlendirmeDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }

        public int KomisyonId { get; set; }
        public string KomisyonAd { get; set; } = string.Empty;

        public int AdliyeId { get; set; }
        public string AdliyeAd { get; set; } = string.Empty;

        public int BirimId { get; set; }
        public string BirimAd { get; set; } = string.Empty;

        public Unvan Unvan { get; set; }
        public string GorevAciklama { get; set; } = string.Empty;

        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

        public bool AktifMi { get; set; }
    }
}
