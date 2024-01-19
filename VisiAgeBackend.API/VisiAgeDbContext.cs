using Microsoft.EntityFrameworkCore;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API
{
    public class VisiAgeDbContext : DbContext
    {
        public VisiAgeDbContext()
        {

        }

        public VisiAgeDbContext(DbContextOptions<VisiAgeDbContext> options) : base(options)
        {
        }
        public DbSet<Alert> Alerts => Set<Alert>();
        public DbSet<AlertStatus> AlertStatuses => Set<AlertStatus>();
        public DbSet<AlertStatusType> AlertStatusTypes => Set<AlertStatusType>();
        public DbSet<CameraRoom> CameraRooms => Set<CameraRoom>();
        public DbSet<Cough> Coughs => Set<Cough>();
        public DbSet<IncidentType> IncidentTypes => Set<IncidentType>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Role);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Dependent)
                .WithMany(e => e.Confidants)
                .HasForeignKey(e => e.DependentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Confidants)
                .WithOne(e => e.Dependent);

            modelBuilder.Entity<Cough>()
                .HasOne(e => e.Dependent)
                .WithMany(e => e.Coughs)
                .HasForeignKey(e => e.DependentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Coughs)
                .WithOne(e => e.Dependent);

            modelBuilder.Entity<CameraRoom>()
                .HasOne(e => e.Dependent)
                .WithMany(e => e.CameraRooms)
                .HasForeignKey(e => e.DependentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CameraRooms)
                .WithOne(e => e.Dependent);

            modelBuilder.Entity<Alert>()
                .HasOne(e => e.Dependent)
                .WithMany(e => e.Alerts)
                .HasForeignKey(e => e.DependentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Alerts)
                .WithOne(e => e.Dependent);

            modelBuilder.Entity<AlertStatus>()
                .HasOne(e => e.Resolver)
                .WithOne(e => e.AlertStatus)
                .HasForeignKey<AlertStatus>("ResolverId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(e => e.AlertStatus)
                .WithOne(e => e.Resolver);

            modelBuilder.Entity<Alert>()
                .HasOne(e => e.CameraRoom)
                .WithMany(e => e.Alerts)
                .HasForeignKey(e => e.CameraRoomId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CameraRoom>()
                .HasMany(e => e.Alerts)
                .WithOne(e => e.CameraRoom);

            modelBuilder.Entity<Alert>()
                .HasOne(e => e.IncidentType)
                .WithMany(e => e.Alerts)
                .HasForeignKey(e => e.IncidentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncidentType>()
                .HasMany(e => e.Alerts)
                .WithOne(e => e.IncidentType);

            modelBuilder.Entity<AlertStatus>()
                .HasOne(e => e.Alert)
                .WithOne(e => e.AlertStatus)
                .HasForeignKey<AlertStatus>("AlertId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alert>()
                .HasOne(e => e.AlertStatus)
                .WithOne(e => e.Alert);

            modelBuilder.Entity<AlertStatus>()
                .HasOne(e => e.AlertStatusType)
                .WithMany(e => e.AlertStatuses)
                .HasForeignKey(e => e.AlertStatusTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Alert>().ToTable("Alert");
            modelBuilder.Entity<AlertStatus>().ToTable("AlertStatus");
            modelBuilder.Entity<AlertStatusType>().ToTable("AlertStatusType");
            modelBuilder.Entity<CameraRoom>().ToTable("CameraRoom");
            modelBuilder.Entity<Cough>().ToTable("Cough");
            modelBuilder.Entity<IncidentType>().ToTable("IncidentType");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}