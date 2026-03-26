using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace TetPee.Service.JwtOption;

public class JwtOptions
{
    [Required] public string Issuer { get; set; }
    [Required] public string Audience { get; set; }
    [Required] public string SecretKey { get; set; }
    [Required] public int  ExpireMinutes { get; set; }
}