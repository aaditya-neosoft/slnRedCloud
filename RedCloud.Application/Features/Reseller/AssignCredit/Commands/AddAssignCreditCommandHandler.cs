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

namespace RedCloud.Application.Features.Reseller.AssignCredit.Commands
{
    public class AddAssignCreditCommandHandler : IRequestHandler<AddAssignCreditCommand, Response<int>>
    {
        private readonly IAsyncRepository<AssignCreditByRate> _repository;
        public AddAssignCreditCommandHandler(IAsyncRepository<AssignCreditByRate> repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(AddAssignCreditCommand request, CancellationToken cancellationToken)
        {
            var parameters = new[]
           {
                //new SqlParameter("@AssignCreditByRateId", request.AssignCreditByRateId),
                new SqlParameter("@CreditDate", request.CreditDate),
                new SqlParameter("@TypeId", request.TypeId),
                new SqlParameter("@Amount", request.Amount),
                new SqlParameter("@NoOfCredits", request.NoOfCredits),
                new SqlParameter("@Expiration", request.Expiration),
                new SqlParameter("@Note", request.Note),
                new SqlParameter("@RateAssignCreditId", request.RateAssignCreditId)

                //new SqlParameter("@CreatedBy", request.CreatedBy),
                //new SqlParameter("@CreatedDate", request.CreatedDate),
                //new SqlParameter("@IsDeleted", request.IsDeleted),
                //new SqlParameter("@LastModifiedBy", request.LastModifiedBy),
                //new SqlParameter("@LastModifiedDate",request.LastModifiedDate)
            };

            try
            {
                var Res = await _repository.StoredProcedureCommandAsync("usp_AddAssignCredit", parameters);
                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

                if (Res == null)
                {
                    return new Response<int>("Rate not found");
                }

                return new Response<int>("Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>($"Error retrieving rate by Id: {ex.Message}");
            }

            //var response = new Response<int>(result.ResellerAdminUserId, "Inserted successfully ");
            //return response;
        }
    }
}
