using Microsoft.EntityFrameworkCore;
using RedCloud.Application;
using RedCloud.Persistenence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RedCloudPortal")));


//SERILOG IMPLEMENTATION

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistenceServices(Configuration);

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
