namespace AutoInventoryPro.Identity.Responses;

public class LoginResponse
{
    public bool Sucess { get; set; }
    public string Token { get; set; }
    public DateTime ExpireAt { get; set; }
}
