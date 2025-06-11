using Application.Features.AdaletKomisyonlari.Dtos;
using Application.Features.AdaletKomisyonlari.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Create
{
    public class CreateAdaletKomisyonuCommandHandler(IMapper mapper, AdaletKomisyonuBusinessRules adaletKomisyonuBusinessRules, IUnitOfWork unitOfWork) : IRequestHandler<CreateAdaletKomisyonuCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly AdaletKomisyonuBusinessRules _adaletKomisyonuBusinessRules = adaletKomisyonuBusinessRules;


        public async Task<IResultBase> Handle(CreateAdaletKomisyonuCommand request, CancellationToken cancellationToken)
        {
            
            await _adaletKomisyonuBusinessRules.ExistsByNameAsync(request.Ad, request.IlId, cancellationToken);

            var entity = _mapper.Map<AdaletKomisyonu>(request);
          
            _unitOfWork.AdaletKomisyonuRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<AdaletKomisyonuDto>(entity);

            return Result<AdaletKomisyonuDto>.SuccessResult(dto, "Komisyon başarıyla oluşturuldu");
        }
    }
}
