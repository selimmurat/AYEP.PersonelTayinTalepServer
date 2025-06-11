using Application.Interfaces;
using Domain.Repositories.Personeller;

namespace Application.Features.Auth.Rules
{
    public class PersonelLoginBusinessRules(IAuthRepository repo, IPasswordHasher passwordHasher)
    {
        private readonly IAuthRepository _repo = repo;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<bool> CheckPassword(string sicilNo, string inputPassword)
        {
            var personel = await _repo.GetBySicilNoWithSifreAndGorevlendirmelerAsync(sicilNo);
            if (personel == null)
                return false;
            return _passwordHasher.VerifyPassword(inputPassword, personel.KullaniciSifre.SifreHash, personel.KullaniciSifre.SifreSalt);
        }
    }
}
