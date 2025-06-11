using Application.Features.AdaletKomisyonlari.Dtos;
using AutoMapper;
using Domain.Repositories.AdaletKomisyonlari;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Queries
{
    public class GetAdaletKomisyonuByIdQuery : IRequest<IResultBase>
    {
        public int Id { get; set; }
    }

    public class GetAdaletKomisyonuByIdQueryHandler(
        IAdaletKomisyonuRepository repository,
        IMapper mapper) : IRequestHandler<GetAdaletKomisyonuByIdQuery, IResultBase>
    {
        private readonly IAdaletKomisyonuRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IResultBase> Handle(GetAdaletKomisyonuByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return ResultBase.FailureResult("Komisyon bulunamadı");

            var dto = _mapper.Map<AdaletKomisyonuDto>(entity);
            return Result<AdaletKomisyonuDto>.SuccessResult(dto);
        }
    }
}
