using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure;

public class PetShopDbContext(DbContextOptions<PetShopDbContext> options) : DbContext(options)
{
    public DbSet<Fake> Fakes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }
}
