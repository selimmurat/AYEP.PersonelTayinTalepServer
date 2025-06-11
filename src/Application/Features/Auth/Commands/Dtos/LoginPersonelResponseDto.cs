using Application.Features.PersonelBirimGorevlendirmeler.Dtos;

namespace Application.Features.Auth.Commands.Dtos
{
    public class LoginPersonelSuccesResponseDto
    {
        public string Token { get; set; } = default!;
        public int PersonelId { get; set; }
        public string SicilNo { get; set; } = default!;
        public string Ad { get; set; } = default!;
        public string Soyad { get; set; } = default!;
        public List<PersonelBirimGorevlendirmeDto> AktifGorevlendirmeler { get; set; } = [];

        public bool SifreDegistirZorunlu { get; set; } = false;
    }
}