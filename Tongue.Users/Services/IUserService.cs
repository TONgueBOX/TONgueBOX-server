namespace Tongue.Users.Services;

public interface IUserService
{
    /// <param name="userId">Telegram User Id</param>
    Task<int> GetUserFreeCoinsByIdAsync(long userId);
}
