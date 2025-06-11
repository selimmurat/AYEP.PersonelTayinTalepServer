using Application.Features.PersonelBirimGorevlendirmeler.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.PersonelBirimGorevlendirmeler.Queries
{
    public class GetPersonelBirimGorevlendirmeByIdQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRequestHandler<GetPersonelBirimGorevlendirmeByIdQuery, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IResultBase> Handle(GetPersonelBirimGorevlendirmeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PersonelBirimGorevlendirmeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return ResultBase.FailureResult("Kayıt bulunamadı");

            var dto = _mapper.Map<PersonelBirimGorevlendirmeDto>(entity);
            return Result<PersonelBirimGorevlendirmeDto>.SuccessResult(dto,"Görev kaydı başarılı şekilde çekildi");
        }
    }
}