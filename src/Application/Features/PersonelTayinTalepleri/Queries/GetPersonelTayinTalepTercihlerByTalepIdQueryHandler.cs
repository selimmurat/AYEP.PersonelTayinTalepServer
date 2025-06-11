using Application.Features.PersonelTayinTalepleri.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries.PersonelTayinTalepTercih
{
    public class GetPersonelTayinTalepTercihlerByTalepIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPersonelTayinTalepTercihlerByTalepIdQuery, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IResultBase> Handle(GetPersonelTayinTalepTercihlerByTalepIdQuery request, CancellationToken cancellationToken)
        {            
            var talep = await _unitOfWork.PersonelTayinTalepRepository
                .GetByIdWithDetailsAsync(request.TalepId, cancellationToken);

            if (talep == null)
                return ResultBase.FailureResult("Tayin talebi bulunamadı.");

            var tercihler = talep.Tercihler.ToList();
            var dtoList = _mapper.Map<List<PersonelTayinTalepTercihDto>>(tercihler);

            return Result<List<PersonelTayinTalepTercihDto>>.SuccessResult(dtoList);
        }
    }
}
