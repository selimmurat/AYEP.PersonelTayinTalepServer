namespace Application.Features.Adliyeler.Dtos
{
    public class AdliyeDto
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty; 
        public int KomisyonId { get; set; }
        public bool IsMulhakat { get; set; }
        public int HizmetBolgesi { get; set; }
        public int HizmetPuani { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}