using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using System.Reflection;

namespace PetShopCRM.Infrastructure;

public class PetShopDbContext(DbContextOptions<PetShopDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<HealthPlan> HealthPlans { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<PaymentHistory> PaymentHistories { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Benefit> Benefits { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<BenefitHealthPlan> BenefitsHealthPlans { get; set; }

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
