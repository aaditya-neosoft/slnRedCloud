﻿using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Persistenence
{
    //public static class PersistenceServiceRegistration
    //{
    //    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    //    {
    //        services.AddDbContext<ApplicationDbContext>(options =>
    //        options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
    //        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
    //        services.AddScoped<ICategoryRepository, CategoryRepository>();
    //        services.AddScoped<IEventRepository, EventRepository>();
    //        services.AddScoped<IOrderRepository, OrderRepository>();
    //        services.AddScoped<IMessageRepository, MessageRepository>();

    //        return services;
    //    }
    //}
}
