﻿
using MediatR;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public  class UpdateAssignedNumberCommand  : IRequest<Response<Unit>>
    {
        public int NumberId { get; set; }
        public string PhoneNumber { get; set; }
        public string RateCenter { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string CountryName { get; set; }
         public int CarrierId {  get; set; }
        public int CountryId { get; set; }
        public string LATA { get; set; }
        public string StateName { get; set; }
         public int StateId { get; set; }
        public string CarrierName { get; set; }

        public int? ResellerAdminUserId { get; set; }

        public string ResellerName { get; set; }
        public int? OrgID { get; set; }

        public string OrgName { get; set; }
        public int? AssignmentTypeId { get; set; }

        public string AssignmentTypeName { get; set; }

        public int? CampaignId { get; set; }
        public string StartDate { get; set; }

        public string EndDate { get; set; }

    }
}

