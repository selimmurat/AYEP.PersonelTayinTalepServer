using Application.Features.Birimler.Dtos;
using Application.Features.Birimler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;


namespace Application.Features.Birimler.Command.Create
{
    public class CreateBirimCommandHandler(
         IMapper mapper,
         BirimBusinessRules birimBusinessRules,
         IUnitOfWork unitOfWork) : IRequestHandler<CreateBirimCommand, IResultBase>
    {
        private readonly IMapper _mapper = mapper;
        private readonly BirimBusinessRules _birimBusinessRules = birimBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(CreateBirimCommand request, CancellationToken cancellationToken)
        {
            await _birimBusinessRules.EnsureBirimNameIsUniqueAsync(request.Ad, request.AdliyeId, cancellationToken);

            var entity = _mapper.Map<Birim>(request);

            _unitOfWork.BirimRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<BirimDto>(entity);
            return Result<BirimDto>.SuccessResult(dto, "Birim başarıyla oluşturuldu.");
        }
    }
}
