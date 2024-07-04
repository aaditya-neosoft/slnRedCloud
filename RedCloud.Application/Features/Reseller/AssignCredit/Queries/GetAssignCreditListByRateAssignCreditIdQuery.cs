using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    //public class GetAssignCreditListByRateAssignCreditIdQuery : IRequest<Response<AssignCredits>>
    public class GetAssignCreditListByRateAssignCreditIdQuery : IRequest<Response<IEnumerable<AssignCredits>>>
    {
        public int AssignCreditByRateId { get; set; }
    }
}
