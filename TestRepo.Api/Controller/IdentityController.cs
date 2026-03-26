using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly IService _identityService;
    public IdentityController(IService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Login(Request.LoginRequest request)
    {
        var login = await _identityService.Login(request);
        return Ok(login);
    }
}