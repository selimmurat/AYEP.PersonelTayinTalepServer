using Application.Features.Adliyeler.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.Adliyeler.Command.Update
{
    public class UpdateAdliyeCommandHandler(
        IMapper mapper,
        AdliyeBusinessRules adliyeBusinessRules,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateAdliyeCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly AdliyeBusinessRules _adliyeBusinessRules = adliyeBusinessRules;

        public async Task<IResultBase> Handle(UpdateAdliyeCommand request, CancellationToken cancellationToken)
        {
            var adliye = await _adliyeBusinessRules.GetAdliyeOrThrowAsync(request.Id, cancellationToken);

            _mapper.Map(request, adliye);

            _unitOfWork.AdliyeRepository.Update(adliye);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Adliye>.SuccessResult(adliye, "İlgili Adliye Güllendi");
        }
    }
}
