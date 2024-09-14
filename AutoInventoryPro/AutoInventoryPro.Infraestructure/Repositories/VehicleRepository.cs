using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class VehicleRepository(AutoInventoryProDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
}
