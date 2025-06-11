using Application.Features.AdaletKomisyonlari.Dtos;
using AutoMapper;
using Domain.Repositories.AdaletKomisyonlari;
using Domain.Shared.Results;
using MediatR;

namespace Application.Features.AdaletKomisyonlari.Queries
{
    public class GetAllAdaletKomisyonuQuery : IRequest<IResultBase> { }

    public class GetAllAdaletKomisyonuQueryHandler(
        IAdaletKomisyonuRepository repository,
        IMapper mapper) : IRequestHandler<GetAllAdaletKomisyonuQuery, IResultBase>
    {
        private readonly IAdaletKomisyonuRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IResultBase> Handle(GetAllAdaletKomisyonuQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            var dtos = _mapper.Map<List<AdaletKomisyonuDto>>(entities);
            return Result<List<AdaletKomisyonuDto>>.SuccessResult(dtos);
        }
    }
}