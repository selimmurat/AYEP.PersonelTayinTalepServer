using Application.Features.Adliyeler.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAdliyelerByKomisyonIdQueryHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : IRequestHandler<GetAdliyelerByKomisyonIdQuery, IResult<List<AdliyeDto>>>
    {
        public async Task<IResult<List<AdliyeDto>>> Handle(GetAdliyelerByKomisyonIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await unitOfWork.AdliyeRepository.GetAllAsync(cancellationToken);
            var filtered = entities.Where(x => x.KomisyonId == request.KomisyonId).ToList();
            var dtos = mapper.Map<List<AdliyeDto>>(filtered);
            return Result<List<AdliyeDto>>.SuccessResult(dtos, "Komisyona bağlı adliyeler getirildi.");
        }
    }
}
