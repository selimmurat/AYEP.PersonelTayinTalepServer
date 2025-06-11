namespace Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int personelId, string sicilNo, string ad, string soyad, string rol);
    }
}
