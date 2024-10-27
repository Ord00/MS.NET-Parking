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
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Club)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ClubId);

        modelBuilder.Entity<ClubEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ClubEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<TrainerEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TrainerEntity>().HasIndex(x => x.ExternalId).IsUnique();
    }
}