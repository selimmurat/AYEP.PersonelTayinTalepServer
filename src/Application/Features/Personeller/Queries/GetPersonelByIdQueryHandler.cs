using Application.Features.Personeller.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Personeller.Queries
{
    public class GetPersonelByIdQueryHandler : IRequestHandler<GetPersonelByIdQuery, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonelByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResultBase> Handle(GetPersonelByIdQuery request, CancellationToken cancellationToken)
        {
            var personel = await _unitOfWork.PersonelRepository.GetByIdAsync(request.Id, cancellationToken);
            if (personel == null)
                return ResultBase.FailureResult("Personel bulunamadı.");
            var dto = _mapper.Map<PersonelDto>(personel);
            return Result<PersonelDto>.SuccessResult(dto, "Personel bulundu.");
        }
    }
}
