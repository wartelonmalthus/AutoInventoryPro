using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.Dealersh.Requests;
using AutoInventoryPro.Views.Dealersh.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class DealershMapper
{
    public static Dealersh ToEntity(this DealershCreateRequest request) => new()
    {
        Address = request.Address,
        City = request.City,
        Email = request.Email,
        MaximumCapacityVehicles= request.MaximumCapacityVehicles,
        Phone= request.Phone,
        Name = request.Name,
        Region = request.Region,
        PostalCode = request.PostalCode,
    };

    public static DealershResponse ToResponse(this Dealersh dealersh) => new() 
    {
        Address = dealersh.Address,
        Email = dealersh.Email, 
        PostalCode= dealersh.PostalCode,
        Region= dealersh.Region,    
        City= dealersh.City,
        MaximumCapacityVehicles = dealersh.MaximumCapacityVehicles,
        Name= dealersh.Name,
        Phone= dealersh.Phone
    };
}
