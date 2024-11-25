using Microsoft.EntityFrameworkCore;
using Parking.DataAccess.Entities;

namespace Parking.DataAccess;

public class ParkingDbContext : DbContext
{
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<RegistrationPlate> RegistrationPlates { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<ZoneMove> ZoneMoves { get; set; }
    public DbSet<ZoneTariff> ZoneTariffs { get; set; }
    
    public ParkingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<User>().HasMany(x => x.CreditCards)
            .WithMany(x => x.Users)
            .UsingEntity(x => x.ToTable("UserCreditCard"));

        modelBuilder.Entity<CreditCard>().HasKey(x => x.Id);
        modelBuilder.Entity<CreditCard>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<RegistrationPlate>().HasKey(x => x.Id);
        modelBuilder.Entity<RegistrationPlate>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<Session>().HasKey(x => x.Id);
        modelBuilder.Entity<Session>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<Session>().HasOne(x => x.Vehicle)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.VehicleId);
        modelBuilder.Entity<Session>().HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<VehicleEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VehicleEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<VehicleEntity>().HasOne(x => x.VehicleType)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.VehicleTypeId);
        modelBuilder.Entity<VehicleEntity>().HasOne(x => x.RegistrationPlate)
            .WithOne(x => x.Vehicle);
        
        modelBuilder.Entity<VehicleType>().HasKey(x => x.Id);
        modelBuilder.Entity<VehicleType>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<ZoneMove>().HasKey(x => x.Id);
        modelBuilder.Entity<ZoneMove>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ZoneMove>().HasOne(x => x.ZoneTariff)
            .WithMany(x => x.ZoneMoves)
            .HasForeignKey(x => x.ZoneTariffId);
        modelBuilder.Entity<ZoneMove>().HasOne(x => x.Session)
            .WithMany(x => x.ZoneMoves)
            .HasForeignKey(x => x.SessionId);
        
        modelBuilder.Entity<ZoneTariff>().HasKey(x => x.Id);
        modelBuilder.Entity<ZoneTariff>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ZoneTariff>().HasOne(x => x.VehicleType)
            .WithMany(x => x.ZoneTariffs)
            .HasForeignKey(x => x.VehicleTypeId);
    }
}