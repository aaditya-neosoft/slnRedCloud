using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Account.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Commands
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<User> _repository;
        public ChangePasswordCommandHandler(IAsyncRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Unit>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var parameters = new[]
           {
                new SqlParameter("@RedCloudAdminUserId", request.RedCloudAdminUserId),
                new SqlParameter("@Password", request.Password)
            };
            try
            {
                var Res = await _repository.StoredProcedureCommandAsync("usp_RedCloudAdminsChangePasswordById", parameters);

                if (Res == null)
                {
                    return new Response<Unit>("Rate not found");
                }

                return new Response<Unit>("Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<Unit>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
