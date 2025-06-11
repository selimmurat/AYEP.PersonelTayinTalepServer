using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    // Kullanıcıdan gelen giriş isteğini temsil eden command
    public class LoginPersonelCommand : IRequest<IResultBase>
    {
        public string SicilNo { get; set; } = default!;
        public string Sifre { get; set; } = default!;
    }
}
