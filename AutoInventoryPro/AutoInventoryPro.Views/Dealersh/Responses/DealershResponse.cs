using AutoInventoryPro.Models.Entities;

namespace AutoInventoryPro.Views.Dealersh.Responses;

public class DealershResponse
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int MaximumCapacityVehicles { get; set; }
    public IEnumerable<SaleResponse> Sales { get; set; } 
}
