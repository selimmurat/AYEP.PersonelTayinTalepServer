using Application.Features.Birimler.Dtos;
using AutoMapper;
using Domain.Repositories.Birimler;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Queries
{
    public class GetBirimlerByAdliyeIdQueryHandler(
        IBirimRepository birimRepository,
        IMapper mapper) : IRequestHandler<GetBirimlerByAdliyeIdQuery, IResultBase>
    {
        public async Task<IResultBase> Handle(GetBirimlerByAdliyeIdQuery request, CancellationToken cancellationToken)
        {
            var birimler = await birimRepository.GetAllAsync(cancellationToken);
            var filtered = birimler.Where(b => b.AdliyeId == request.AdliyeId).ToList();
            var dtos = mapper.Map<List<BirimDto>>(filtered);
            return Result<List<BirimDto>>.SuccessResult(dtos, "İlgili adliyeye bağlı birimler listelendi.");
        }
    }
}
