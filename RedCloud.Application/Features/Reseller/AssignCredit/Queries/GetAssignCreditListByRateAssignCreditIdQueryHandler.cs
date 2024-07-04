using MediatR;
using Microsoft.Data.SqlClient;
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
    //public class GetAssignCreditListByRateAssignCreditIdQueryHandler : IRequestHandler<GetAssignCreditListByRateAssignCreditIdQuery, Response<AssignCredits>>
    public class GetAssignCreditListByRateAssignCreditIdQueryHandler : IRequestHandler<GetAssignCreditListByRateAssignCreditIdQuery, Response<IEnumerable<AssignCredits>>>
    {
        //AssignCredit
        private readonly IAsyncRepository<AssignCredits> _repository;


        public GetAssignCreditListByRateAssignCreditIdQueryHandler(IAsyncRepository<AssignCredits> repository)
        {
            _repository = repository;

        }

        public async Task<Response<IEnumerable<AssignCredits>>> Handle(GetAssignCreditListByRateAssignCreditIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@AssignCreditByRateId", request.AssignCreditByRateId),
            };

            
            
                var Res = (await _repository.StoredProcedureQueryAsync("usp_GetAssignCreditListByRateAssignCreditId", parameters)).ToList();

                if (Res == null)
                {
                    //return new Response<AssignCredits>("Rate not found");
                    return new Response<IEnumerable<AssignCredits>>(Res, "success");
                }

                //return new Response<AssignCredits>(Res, "Rate retrieved successfully");
                return new Response<IEnumerable<AssignCredits>>(Res, "success");
            
            
        }
    }
}
