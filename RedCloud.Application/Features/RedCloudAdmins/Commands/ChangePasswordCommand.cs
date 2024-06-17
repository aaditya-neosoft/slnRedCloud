using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Commands
{
    public class ChangePasswordCommand : IRequest<Response<Unit>>
    {
        //[Required(ErrorMessage = "User is required")]
        public int RedCloudAdminUserId { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
