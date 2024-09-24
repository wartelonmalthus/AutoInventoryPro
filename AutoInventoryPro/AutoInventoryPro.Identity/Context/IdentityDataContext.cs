using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Identity.Context;

public class IdentityDataContext(DbContextOptions<IdentityDataContext> options) : IdentityDbContext(options)
{
}
