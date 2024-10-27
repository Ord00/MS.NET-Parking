using Microsoft.EntityFrameworkCore;
using Parking.DataAccess.Entities;

namespace Parking.DataAccess;

public class ParkingDbContext : DbContext
{
    public DbSet<CreditCardEntity> CreditCards { get; set; }
    public DbSet<RegistrationPlateEntity> RegistrationPlates { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<VehicleTypeEntity> VehicleTypes { get; set; }
    public DbSet<ZoneMoveEntity> ZoneMoves { get; set; }
    public DbSet<ZoneTariffEntity> ZoneTariffs { get; set; }
    
    public ParkingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasMany(x => x.CreditCards)
            .WithMany(x => x.Users)
            .UsingEntity(x => x.ToTable("UserCreditCard"));

        modelBuilder.Entity<CreditCardEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CreditCardEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<RegistrationPlateEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<RegistrationPlateEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<SessionEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SessionEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<SessionEntity>().HasOne(x => x.Vehicle)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.VehicleId);
        modelBuilder.Entity<SessionEntity>().HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<VehicleEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VehicleEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<VehicleEntity>().HasOne(x => x.VehicleType)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.VehicleTypeId);
        modelBuilder.Entity<VehicleEntity>().HasOne(x => x.RegistrationPlate)
            .WithOne(x => x.Vehicle);
        
        modelBuilder.Entity<VehicleTypeEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VehicleTypeEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<ZoneMoveEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ZoneMoveEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ZoneMoveEntity>().HasOne(x => x.ZoneTariff)
            .WithMany(x => x.ZoneMoves)
            .HasForeignKey(x => x.ZoneTariffId);
        modelBuilder.Entity<ZoneMoveEntity>().HasOne(x => x.Session)
            .WithMany(x => x.ZoneMoves)
            .HasForeignKey(x => x.SessionId);
        
        modelBuilder.Entity<ZoneTariffEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ZoneTariffEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ZoneTariffEntity>().HasOne(x => x.VehicleType)
            .WithMany(x => x.ZoneTariffs)
            .HasForeignKey(x => x.VehicleTypeId);
    }
}