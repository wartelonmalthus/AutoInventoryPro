using AutoInventoryPro.Models.Enums;
using AutoInventoryPro.Views.Fabricator.Responses;

namespace AutoInventoryPro.Views.Vehicle.Responses;

public class VehicleResponse
{
    public int IdVehicle { get; set; }
    public string VehicleModel { get; set; }
    public int YearManufacture { get; set; }
    public decimal Price { get; set; }
    public EVehicleType VehicleType { get; set; }
    public string? Description { get; set; }
    public FabricatorInfo? FabricatorInfo { get; set; }
}
