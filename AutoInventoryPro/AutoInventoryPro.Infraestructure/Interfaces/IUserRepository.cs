using AutoInventoryPro.Models.Entities;

namespace AutoInventoryPro.Infraestructure.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User>Login(string email, string password);
}
