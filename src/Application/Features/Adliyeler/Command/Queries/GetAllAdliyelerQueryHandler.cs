using Application.Features.Adliyeler.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAllAdliyelerQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : IRequestHandler<GetAllAdliyelerQuery, IResult<List<AdliyeDto>>>
    {
        public async Task<IResult<List<AdliyeDto>>> Handle(GetAllAdliyelerQuery request, CancellationToken cancellationToken)
        {
            var entities = await unitOfWork.AdliyeRepository.GetAllAsync(cancellationToken);
            var dtos = mapper.Map<List<AdliyeDto>>(entities);
            return Result<List<AdliyeDto>>.SuccessResult(dtos, "Tüm adliyeler listelendi.");
        }
    }
}
