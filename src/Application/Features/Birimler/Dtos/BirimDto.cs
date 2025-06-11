namespace Application.Features.Birimler.Dtos
{
    public class BirimDto
    {
        public int Id { get; set; }
        public string Ad { get; set; } = default!;
        public int AdliyeId { get; set; }
        public string? AdliyeAd { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}