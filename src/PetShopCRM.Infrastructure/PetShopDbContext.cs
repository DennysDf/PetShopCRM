using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System.Reflection;

namespace PetShopCRM.Infrastructure;

public class PetShopDbContext(DbContextOptions<PetShopDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Clinica> Clinicas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i =>
                i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) && 
                typeof(EntityBase).IsAssignableFrom(i.GenericTypeArguments[0])));
    }
}
