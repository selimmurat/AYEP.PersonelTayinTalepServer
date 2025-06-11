using Application.Features.Adliyeler.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAdliyeByIdQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : IRequestHandler<GetAdliyeByIdQuery, IResult<AdliyeDto>>
    {
        public async Task<IResult<AdliyeDto>> Handle(GetAdliyeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.AdliyeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result<AdliyeDto>.FailureResult("Adliye bulunamadı.");

            var dto = mapper.Map<AdliyeDto>(entity);
            return Result<AdliyeDto>.SuccessResult(dto, "Adliye bulundu.");
        }
    }
}