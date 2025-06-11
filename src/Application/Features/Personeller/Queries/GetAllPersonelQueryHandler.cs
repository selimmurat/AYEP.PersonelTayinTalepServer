using Application.Features.Personeller.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Queries
{
    public class GetAllPersonelQueryHandler : IRequestHandler<GetAllPersonelQuery, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPersonelQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResultBase> Handle(GetAllPersonelQuery request, CancellationToken cancellationToken)
        {
            var personeller = await _unitOfWork.PersonelRepository.GetAllAsync(cancellationToken);
            var dtoList = _mapper.Map<List<PersonelDto>>(personeller);
            return Result<List<PersonelDto>>.SuccessResult(dtoList, "Tüm personeller listelendi.");
        }
    }
}
