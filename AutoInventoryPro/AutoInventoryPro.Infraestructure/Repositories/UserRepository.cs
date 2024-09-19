using AutoInventoryPro.Infraestructure.Context;
using AutoInventoryPro.Infraestructure.Interfaces;
using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoInventoryPro.Infraestructure.Repositories;

public class UserRepository(AutoInventoryProDbContext context) : BaseRepository<User>(context), IUserRepository
{
    private readonly AutoInventoryProDbContext context = context;

    public Task<User> Login(string email, string password)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}
