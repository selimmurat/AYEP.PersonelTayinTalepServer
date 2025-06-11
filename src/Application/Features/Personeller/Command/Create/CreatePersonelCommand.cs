using Domain.Shared.Results;
using MediatR;

public class CreatePersonelCommand : IRequest<IResultBase>
{
    public string SicilNo { get; set; } = default!;
    public string TCKimlikNo { get; set; } = default!;
    public string Ad { get; set; } = default!;
    public string Soyad { get; set; } = default!;
    public int Cinsiyet { get; set; } = default!;
    public string Telefon { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
    public string Unvan { get; set; } = default!;
    public int? BirimId { get; set; } 
    public int? UnvanId { get; set; }
    public DateTime? GorevlendirmeBaslangicTarihi { get; set; }
    public string GorevAciklama { get; set; } = string.Empty;
    public DateTime IlkGirisTarihi { get; set; } = default!;
    public DateTime? KurumaBaslamaTarihi { get; set; }
    public DateTime? AsaletTarihi { get; set; }
    public DateTime? AyrilisTarihi { get; set; }
    public string AyrilisNedeni { get; set; } = string.Empty;
}
