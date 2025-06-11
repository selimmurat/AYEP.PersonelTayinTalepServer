namespace Domain.Shared.ValueObjects
{
    public sealed record Email(string Value)
    {
        public static Email Create(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentException("Email boş olamaz!.", nameof(Value));
            }
            if (!Value.Contains('@') || !Value.Contains('.'))
            {
                throw new ArgumentException("Geçersiz e-mail adresi!", nameof(Value));
            }
            return new Email(Value);
        }
        public override string ToString() => Value;
    }
}
