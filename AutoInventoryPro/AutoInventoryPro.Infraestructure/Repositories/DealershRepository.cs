using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class DealershRepository(AutoInventoryProDbContext context) : BaseRepository<Dealersh>(context), IDealershRepository
{
}
