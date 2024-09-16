using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class FabricatorRepository(AutoInventoryProDbContext context) : BaseRepository<Fabricator>(context), IFabricatorRepository
{
 
}
