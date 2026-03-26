namespace TetPee.Service.Identity;

public interface IService
{
    public Task<Response.LoginResponse> Login(Request.LoginRequest request);
}