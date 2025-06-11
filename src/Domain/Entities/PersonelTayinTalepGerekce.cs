using Domain.Shared.Enums;

namespace Domain.Entities
{
    public class PersonelTayinTalepGerekce
    {
        public int Id { get; set; }

        public int PersonelTayinTalepId { get; set; }
        public PersonelTayinTalep PersonelTayinTalep { get; set; } = default!;
        public TayinTalepGerekce Gerekce { get; set; }
    }
}