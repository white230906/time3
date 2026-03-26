using System.Security.Claims;

namespace TetPee.Service.JwtOption;

public interface IService
{
    public string GenerateAccessToken(IEnumerable<Claim> claims);
}