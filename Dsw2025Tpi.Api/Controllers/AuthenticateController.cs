using Azure.Core;
using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Application.Services;
using Dsw2025Tpi.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dsw2025Ej15.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtTokenService _jwtTokenService;

    public AuthenticateController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        JwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return Unauthorized("Usuario o contraseña incorrectos");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized("Usuario o contraseña incorrectos");
        }

        var token = _jwtTokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {

        if (!Enum.TryParse<ValidRoles>(model.Role, true, out var parsedRole))
        {
            return BadRequest("Rol invalido");
        }

        if(model.Username == "lucasCliente")
        {
            var userprop = await _userManager.FindByNameAsync(model.Username);
            if (!Enum.TryParse<ValidRoles>("Client", true, out var parsedRole1))
            {
                return BadRequest("Rol invalido");
            }
            var assignRoleResultprop = await _userManager.AddToRoleAsync(userprop, parsedRole1.ToString());
            if (!assignRoleResultprop.Succeeded)
                return BadRequest(assignRoleResultprop.Errors);
            return Ok(new
            {
                message = "Cambiamos bien el rol wacho",
                role = parsedRole
            });
        }

        var user = new IdentityUser { UserName = model.Username, Email = model.Email };
        
        var assignRoleResult = await _userManager.AddToRoleAsync(user, parsedRole.ToString());

        if (!assignRoleResult.Succeeded)
            return BadRequest(assignRoleResult.Errors);

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new
        {
            message = "Usuario registrado correctamente",
            role = parsedRole
        });
    }
}
