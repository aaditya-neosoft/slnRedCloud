using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetCreditTypeQueryHandler : IRequestHandler<GetCreditTypeQuery, Response<IEnumerable<CreditsType>>>
    {
        private readonly IAsyncRepository<CreditsType> _repository;
        public GetCreditTypeQueryHandler(IAsyncRepository<CreditsType> repository)
        {
            _repository = repository;
        }
        public async Task<Response<IEnumerable<CreditsType>>> Handle(GetCreditTypeQuery request, CancellationToken cancellationToken)
        {
            var Res = (await _repository.StoredProcedureQueryAsync("usp_GetAssignCreditTypeList")).ToList();
            return new Response<IEnumerable<CreditsType>>(Res, "success");
        }
    }
}
