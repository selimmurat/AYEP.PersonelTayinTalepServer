using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.Enums
{
    public enum TayinTalepNedeni
    {
        DegisiklikTalebi = 1, // Değişiklik talebi
        OncelikliKalmak = 2, // Öncelikle kalmak istiyorum yoksa taleplerimden birine atanmak istiyorum
        TaleplerOlmazsaYerimdeKalmak = 3, // Taleplerim olmazsa yerimde kalmak istiyorum
        YerimdeKalmak = 4 // Yerimde kalmak istiyorum
    }
}
