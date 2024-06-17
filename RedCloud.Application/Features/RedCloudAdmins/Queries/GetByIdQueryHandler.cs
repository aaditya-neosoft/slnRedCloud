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

namespace RedCloud.Application.Features.RedCloudAdmins.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<RedCloudAdmin>>
    {
        private readonly IAsyncRepository<RedCloudAdmin> _repository;
        public GetByIdQueryHandler(IAsyncRepository<RedCloudAdmin> repository)
        {
            _repository = repository;
        }
        public async Task<Response<RedCloudAdmin>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            //var Res2 = await _repository.StoredProcedureQueryAsync("usp_GetOrganizationType");
            var parameters = new[]
            {
                new SqlParameter("@RedCloudAdminUserId", request.RedCloudAdminUserId)
            };

            try
            {
                var Res = (await _repository.StoredProcedureQueryAsync("usp_RedCloudAdminsById", parameters)).FirstOrDefault();

                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

                if (Res == null)
                {
                    return new Response<RedCloudAdmin>("Rate not found");
                }

                return new Response<RedCloudAdmin>(Res, "Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<RedCloudAdmin>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
