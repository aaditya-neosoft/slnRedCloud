﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApiCallingService.Helpers.ApiHelper;

using RedCloud.Domain.Entities;
using RedCloud.Interface;
using RedCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Service
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IApiClient<AdminUser> _client;
        public readonly ILogger<AdminUserService> _logger;

        public AdminUserService(IApiClient<AdminUser> client, ILogger<AdminUserService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<int> CreateAdminUser(AdminUser adminUser)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("AdminUser/AddAdminUser", adminUser);
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }


      //  [HttpGet]
        //public async Task<IEnumerable<AdminUser>> GetAllRedCloudAdmin()
        //{
        //    _logger.LogInformation("GetAllRedCloudAdmin Service initiated");
        //    var reSelleradmin = await _client.GetAllAsync("");//add api link hehe
        //    _logger.LogInformation("GetAllRedCloudAdmin Service conpleted");
        //    return reSelleradmin.Data;
        //}
       
    }
}
