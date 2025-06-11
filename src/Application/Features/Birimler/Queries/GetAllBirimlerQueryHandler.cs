using Application.Features.Birimler.Dtos;
using AutoMapper;
using Domain.Repositories.Birimler;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Queries
{
    public class GetAllBirimlerQueryHandler(
        IBirimRepository birimRepository,
        IMapper mapper) : IRequestHandler<GetAllBirimlerQuery, IResultBase>
    {
        public async Task<IResultBase> Handle(GetAllBirimlerQuery request, CancellationToken cancellationToken)
        {
            var birimler = await birimRepository.GetAllAsync(cancellationToken);
            var dtos = mapper.Map<List<BirimDto>>(birimler);
            return Result<List<BirimDto>>.SuccessResult(dtos, "Tüm birimler listelendi.");
        }
    }
}
