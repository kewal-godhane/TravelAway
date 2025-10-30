using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infosys.TravelAwayDAL.Models
{
    public partial class TravelAwayDBContext : DbContext
    {
        public TravelAwayDBContext()
        {
        }

        public TravelAwayDBContext(DbContextOptions<TravelAwayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accomodation> Accomodations { get; set; } = null!;
        public virtual DbSet<BookPackage> BookPackages { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageCategory> PackageCategories { get; set; } = null!;
        public virtual DbSet<PackageDetail> PackageDetails { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("TravelAwayDBConnectionString"));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.ToTable("Accomodation");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Accomodations)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("fk_BookingId");
            });

            modelBuilder.Entity<BookPackage>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("pk_BookingId");

                entity.ToTable("BookPackage");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DateOfTravel).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.BookPackages)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("fk_EmailId");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.BookPackages)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_packId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("pk_EmailId");

                entity.ToTable("Customer");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_RoleId");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeluxeeRoomPrice).HasColumnType("money");

                entity.Property(e => e.DoubleRoomPrice).HasColumnType("money");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SingleRoomPrice).HasColumnType("money");

                entity.Property(e => e.SuiteRoomPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.HasIndex(e => e.PackageName, "UQ__Package__73856F7A729B1FEC")
                    .IsUnique();

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfPackage)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.PackageCategory)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.PackageCategoryId)
                    .HasConstraintName("fk_PackageCategoryId");
            });

            modelBuilder.Entity<PackageCategory>(entity =>
            {
                entity.ToTable("PackageCategory");

                entity.HasIndex(e => e.PackageCategoryName, "UQ__PackageC__DD8EB4747B95D367")
                    .IsUnique();

                entity.Property(e => e.PackageCategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageDetail>(entity =>
            {
                entity.HasKey(e => e.PackageDetailsId)
                    .HasName("pk_PaclageDetailsId");

                entity.Property(e => e.Accomodation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PlacesToVisit)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerAdult).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_PackageId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "uq_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
