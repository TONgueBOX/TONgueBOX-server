using Microsoft.EntityFrameworkCore;
using Tongue.Data.Models.Users;

namespace Tongue.Data.DbContexts;

public class TonguePgDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public TonguePgDbContext(DbContextOptions<TonguePgDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TonguePgDbContext).Assembly);
    }
}
