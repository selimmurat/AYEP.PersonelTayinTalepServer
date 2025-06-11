using Application.Features.AdaletKomisyonlari.Dtos;
using Application.Features.Adliyeler.Dtos;
using Application.Features.Adliyeler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Create
{
    public class CreateAdliyeCommandHandler(
        IMapper mapper, 
        AdliyeBusinessRules adliyeBusinessRules, 
        IUnitOfWork unitOfWork) : IRequestHandler<CreateAdliyeCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly AdliyeBusinessRules _adliyeBusinessRules = adliyeBusinessRules;

        public async Task<IResultBase> Handle(CreateAdliyeCommand request, CancellationToken cancellationToken)
        {

            await _adliyeBusinessRules.EnsureAdliyeNameIsUniqueAsync(request.Ad, request.AdaletKomisyonuId, cancellationToken);

            var entity = _mapper.Map<Adliye>(request);

            _unitOfWork.AdliyeRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<AdliyeDto>(entity);
            return Result<AdliyeDto>.SuccessResult(dto, "Adliye başarıyla oluşturuldu");
        }
    }
}
