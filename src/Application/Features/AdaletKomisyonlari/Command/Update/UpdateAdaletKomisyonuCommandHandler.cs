using Application.Features.AdaletKomisyonlari.Rules;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Command.Update
{
    public class UpdateAdaletKomisyonuCommandHandler(
        IMapper mapper,
        AdaletKomisyonuBusinessRules adaletKomisyonuBusinessRules,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateAdaletKomisyonuCommand, IResultBase>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly AdaletKomisyonuBusinessRules _adaletKomisyonuBusinessRules = adaletKomisyonuBusinessRules;

        public async Task<IResultBase> Handle(UpdateAdaletKomisyonuCommand request, CancellationToken cancellationToken)
        {
            await _adaletKomisyonuBusinessRules.CheckKomisyonExistsOrThrowAsync(request.Id, cancellationToken);

            var komisyon = await _unitOfWork.AdaletKomisyonuRepository.GetByIdAsync(request.Id, cancellationToken);
            komisyon.Ad = request.Ad;
            komisyon.IlId = request.IlId;
            _unitOfWork.AdaletKomisyonuRepository.Update(komisyon);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<AdaletKomisyonu>.SuccessResult(komisyon, "Günlleme işlemi başarılı");
        }
    }
}
