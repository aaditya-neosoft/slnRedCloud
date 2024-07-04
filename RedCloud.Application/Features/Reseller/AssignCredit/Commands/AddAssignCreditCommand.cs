using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Commands
{
    public class AddAssignCreditCommand : IRequest<Response<int>>
    {
        public int AssignCreditByRateId { get; set; }
        //[JsonIgnore]
        public DateOnly CreditDate { get; set; }
        public int TypeId { get; set; }
        public int Amount { get; set; }
        public int NoOfCredits { get; set; }
        public int Expiration { get; set; }
        public string Note { get; set; }
        public int RateAssignCreditId { get; set; }
    }
}
