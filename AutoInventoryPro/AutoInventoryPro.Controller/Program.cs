using AutoInventoryPro.Identity.Context;
using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Infraestructure.Repositories;
using AutoInventoryPro.Models.Utils;
using AutoInventoryPro.Services.Cache;
using AutoInventoryPro.Services.Interfaces;
using AutoInventoryPro.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AutoInventoryProDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("AutoInventoryDatabase"))
        );

        builder.Services.AddDbContext<IdentityDataContext>(options =>
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
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IDealershService, DealershService>();
        builder.Services.AddScoped<IFabricatorService, FabricatorService>();
        builder.Services.AddScoped<ISaleService, SaleService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IVehicleService, VehicleService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        //cache
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));
        builder.Services.AddSingleton<CacheOptionsProvider>();
        builder.Services.AddMemoryCache();



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAny",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        var app = builder.Build();

        app.UseCors("AllowAny");

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
    }
}