using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure;

public class PetShopDbContext(DbContextOptions<PetShopDbContext> options) : DbContext(options)
{
    public DbSet<Fake> Fakes { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Clinica> Clinicas { get; set; }    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }
}
