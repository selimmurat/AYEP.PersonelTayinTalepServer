using Application.Features.PersonelTayinTalepleri.Dtos;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Command.Create.CreatePersonelTayinTalep
{
    public class CreatePersonelTayinTalepCommand(CreatePersonelTayinTalepDto model) : IRequest<IResultBase>
    {
        public CreatePersonelTayinTalepDto Model { get; set; } = model;
    }
}