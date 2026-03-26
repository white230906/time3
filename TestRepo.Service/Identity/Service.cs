using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TetPee.Repository;
using TetPee.Service.JwtOption;

namespace TetPee.Service.Identity;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtOption.IService _jwtService;
    private readonly JwtOptions _jwtOptions;

    public Service(AppDbContext dbContext, JwtOption.IService jwtService, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);
    }
    
    public async Task<Response.LoginResponse> Login(Request.LoginRequest request)
    {
        var user = _dbContext.Users.FirstOrDefault(x=> x.Email == request.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (user.Password != request.Password)
        {
            throw new Exception("Wrong password");
        }

        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Role", user.Role),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var token = _jwtService.GenerateAccessToken(claims);
        return new Response.LoginResponse()
        {
            AccessToken = token,
        };
    }
}