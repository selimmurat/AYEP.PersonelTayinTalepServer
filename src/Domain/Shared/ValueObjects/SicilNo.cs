namespace Domain.Shared.ValueObjects
{
    public sealed record SicilNo(string sicilNo)
    {
       public static SicilNo Create(string sicilNo)
        {
            if (string.IsNullOrWhiteSpace(sicilNo))
            {
                throw new ArgumentException("Sicil numarası boş olamaz!", nameof(sicilNo));
            }
            if (sicilNo.Length != 11)
            {
                throw new ArgumentException("Sicil numarası çok uzun en fazla 11 karakter olabilir.", nameof(sicilNo));
            }
            return new SicilNo(sicilNo);
        }
        public override string ToString() => sicilNo;
    }
}
