using Tongue.Constants.Static;

namespace Tongue.Users.Services;

public class UserService : IUserService
{
    public UserService()
    {
        
    }

    public async Task<int> GetUserFreeCoinsByIdAsync(long userId)
    {
        return await Task.Run(() => UserDefaultSettings.DefaultFreeCoins);
    }
}
