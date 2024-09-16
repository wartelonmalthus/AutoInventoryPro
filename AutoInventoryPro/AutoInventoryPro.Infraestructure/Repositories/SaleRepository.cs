using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class SaleRepository(AutoInventoryProDbContext context) : BaseRepository<Sale>(context), ISaleRepository
{ 
}
