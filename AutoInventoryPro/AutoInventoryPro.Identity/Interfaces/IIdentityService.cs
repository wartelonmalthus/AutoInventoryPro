
using AutoInventoryPro.Identity.Requests;
using AutoInventoryPro.Identity.Responses;


namespace AutoInventoryPro.Identity.Interfaces;

public interface IIdentityService
{
    Task<LoginResponse> Login(LoginRequestIdentity request);
}
