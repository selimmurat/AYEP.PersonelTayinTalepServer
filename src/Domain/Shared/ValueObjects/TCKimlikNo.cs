using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.ValueObjects
{
    public sealed record TCKimlikNo(string TcKimlikNo)
    {
        public static TCKimlikNo Create(string TcKimlikNo)
        {
            if (string.IsNullOrWhiteSpace(TcKimlikNo))
            {
                throw new ArgumentException("TC Kimlik numarası boş olamaz!", nameof(TcKimlikNo));
            }
            if (TcKimlikNo.Length != 11)
            {
                throw new ArgumentException("TC Kimlik numarası çok uzun, en fazla 11 karakter olabilir.", nameof(TcKimlikNo));
            }
            return new TCKimlikNo(TcKimlikNo);
        }
        public override string ToString() => TcKimlikNo;
    }

}
