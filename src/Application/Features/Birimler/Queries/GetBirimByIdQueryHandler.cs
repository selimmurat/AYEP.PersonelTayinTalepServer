using Application.Features.Birimler.Dtos;
using AutoMapper;
using Domain.Repositories.Birimler;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Queries
{
    public class GetBirimByIdQueryHandler(
        IBirimRepository birimRepository,
        IMapper mapper) : IRequestHandler<GetBirimByIdQuery, IResultBase>
    {
        public async Task<IResultBase> Handle(GetBirimByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await birimRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result<BirimDto>.FailureResult("Birim bulunamadı.");
            var dto = mapper.Map<BirimDto>(entity);
            return Result<BirimDto>.SuccessResult(dto);
        }
    }
}
