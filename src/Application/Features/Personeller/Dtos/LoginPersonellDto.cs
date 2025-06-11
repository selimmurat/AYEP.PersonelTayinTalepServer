using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Personeller.Dtos
{
    public class LoginPersonellDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string SicilNo { get; set; } = default!;
        public string AdSoyad { get; set; } = default!;
    }
}
