using Application.Features.PersonelTayinTalepleri.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelTayinTalepleri.Queries
{
    public class GetPersonelTayinTalepleriByPersonelIdQueryHandler(
        IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPersonelTayinTalepleriByPersonelIdQuery, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<IResultBase> Handle(GetPersonelTayinTalepleriByPersonelIdQuery request, CancellationToken cancellationToken)
        {
            var talepler = await _unitOfWork.PersonelTayinTalepRepository.GetByPersonelIdAsync(request.PersonelId, cancellationToken);
            var dtoList = _mapper.Map<List<PersonelTayinTalepDto>>(talepler);
            return Result<List<PersonelTayinTalepDto>>.SuccessResult(dtoList);
        }
    }
}
