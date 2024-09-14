using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Repositories;
using AutoInventoryPro.Models.Interfaces.Repositorires;
using AutoInventoryPro.Models.Interfaces.Services;
using AutoInventoryPro.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<AutoInventoryProDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoInventoryDatabase"))
);

//repository
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDealershRepository, DealershRepository>();
builder.Services.AddScoped<IFabricatorRepository, FabricatorRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

//service
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDealershService, DealershService>();
builder.Services.AddScoped<IFabricatorService, FabricatorService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
