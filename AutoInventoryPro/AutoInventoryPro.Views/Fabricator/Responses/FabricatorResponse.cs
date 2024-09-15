using AutoInventoryPro.Views.Vehicle.Responses;

namespace AutoInventoryPro.Views.Fabricator.Responses;

public class FabricatorResponse
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int YearFoundation { get; set; }
    public string WebSite { get; set; }
    public IEnumerable<VehicleResponse> vehicleResponses { get; set; }
}
