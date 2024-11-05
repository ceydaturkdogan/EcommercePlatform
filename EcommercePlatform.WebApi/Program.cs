using ECommercePlatform.Business.Data_Protection;
using ECommercePlatform.Business.Operations.User;
using ECommercePlatform.Data.Context;
using ECommercePlatform.Data.Repositories;
using ECommercePlatform.Data.UnitOfWork;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IDataProtection, DataProtection>();

var keysDirectory = new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_data", "Keys"));

builder.Services.AddDataProtection()
    .SetApplicationName("ECommercePlatform")
    .PersistKeysToFileSystem(keysDirectory);




builder.Services.AddDbContext<ECommerceDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));//=> becauseof generics 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();



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
