using Application.Features.Birimler.Dtos;
using Application.Features.Birimler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Birimler.Command.Update
{
    public class UpdateBirimCommandHandler(
        IMapper mapper,
        BirimBusinessRules birimBusinessRules,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateBirimCommand, IResultBase>
    {
        private readonly IMapper _mapper = mapper;
        private readonly BirimBusinessRules _birimBusinessRules = birimBusinessRules;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IResultBase> Handle(UpdateBirimCommand request, CancellationToken cancellationToken)
        {
            var birim = await _birimBusinessRules.GetBirimOrThrowAsync(request.Id, cancellationToken);

            // Aynı adliye altında aynı isimde ikinci birim olmasın:
            await _birimBusinessRules.EnsureBirimNameIsUniqueAsync(request.Ad, request.AdliyeId, cancellationToken);

            _mapper.Map(request, birim);

            _unitOfWork.BirimRepository.Update(birim);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<BirimDto>(birim);
            return Result<BirimDto>.SuccessResult(dto, "Birim güncellendi.");
        }
    }
}
