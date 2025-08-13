using Microsoft.AspNetCore.Mvc;

namespace Tongue.Web.Extensions;

[ApiController]
[Route("[controller]/[action]")]
public class ControllerBaseExtended : ControllerBase
{
    protected long GetCurrentUserId()
    {
        return this.GetUserIdFromHttpContext();
    }
    protected long? GetCurrentUserIOrDefault()
    {
        return this.GetUserIdOrDefaultFromHttpContext();
    }
}

public static class ControllerUtil
{
    public static long GetUserIdFromHttpContext(this ControllerBase controller)
    {
        throw new NotImplementedException();
    }
    public static long? GetUserIdOrDefaultFromHttpContext(this ControllerBase controller)
    {
        throw new NotImplementedException();
    }
}