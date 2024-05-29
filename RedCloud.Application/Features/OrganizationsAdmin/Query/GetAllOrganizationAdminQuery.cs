﻿using MediatR;
using RedCloud.Application.Responses;
using RedCloud.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationsAdmin.Query
{
    public class GetAllOrganizationAdminQuery : IRequest<BaseResponse<IEnumerable<AllOrganizationAdminVM>>>
    {

    }
}
