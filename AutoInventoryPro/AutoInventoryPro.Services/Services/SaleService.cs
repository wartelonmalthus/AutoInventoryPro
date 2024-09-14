using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;
using AutoInventoryPro.Models.Interfaces.Services;

namespace AutoInventoryPro.Services.Services;

public class SaleService(ISaleRepository saleRepository) : BaseService<Sale>(saleRepository), ISaleService
{
}
