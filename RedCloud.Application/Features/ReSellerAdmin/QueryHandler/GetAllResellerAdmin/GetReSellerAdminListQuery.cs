﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedCloud.Application.Responses;

namespace RedCloud.Application.Features.ReSellerAdmin.QueryHandler.GetAllResellerAdmin
{
    public class GetReSellerAdminListQuery: IRequest<BaseResponse<IEnumerable<ReSellerAdminVM>>>
    {
    }
}
