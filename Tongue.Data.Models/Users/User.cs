namespace Tongue.Data.Models.Users;

public class User
{
    public long Id { get; set; }
    public int FreeCoins { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Disabled { get; set; }
    public DateTime? DisabledAt { get; set; }
}