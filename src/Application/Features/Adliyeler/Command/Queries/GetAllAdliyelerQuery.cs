using Application.Features.Adliyeler.Dtos;
using Domain.Shared.Results;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Adliyeler.Queries
{
    public class GetAllAdliyelerQuery : IRequest<IResult<List<AdliyeDto>>> { }
}
