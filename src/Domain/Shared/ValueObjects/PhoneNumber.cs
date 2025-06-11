using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.ValueObjects
{
    public sealed record PhoneNumber(string Number)
    {
        public static PhoneNumber Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Telefon numarası boş olamaz.", nameof(number));
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(number, @"^[0-9+]{10,15}$"))
                throw new ArgumentException("Geçersiz telefon numarası.");
            return new PhoneNumber(number);
        }
        public override string ToString() => Number;
    }
}
