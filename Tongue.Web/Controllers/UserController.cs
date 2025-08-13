using Microsoft.AspNetCore.Mvc;
using Tongue.Users.Services;
using Tongue.Web.Extensions;

namespace Tongue.Web.Controllers;

[ApiController]
public class UserController : ControllerBaseExtended
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<int>> GetCurrentCoins()
    {
        // var coins = await _userService.GetUserFreeCoinsByIdAsync(GetCurrentUserId());
        var coins = await _userService.GetUserFreeCoinsByIdAsync(userId: 0);
        return await Task.Run(() => coins);
    }
}
