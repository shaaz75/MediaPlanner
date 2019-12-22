using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MediaPlanner.Model;

namespace MediaPlanner.Data
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<AdSet> AdSet { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<MediaChannel> MediaChannel { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER01;Initial Catalog=Demo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.Property(e => e.AdBudget).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AdEndDateTime).HasColumnType("datetime");

                entity.Property(e => e.AdStartDateTime).HasColumnType("datetime");

                entity.Property(e => e.AddName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("CampaignId");
            });

            modelBuilder.Entity<AdSet>(entity =>
            {
                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.AdSet)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("CampaignId_FK");

                entity.HasOne(d => d.MediaChannel)
                    .WithMany(p => p.AdSet)
                    .HasForeignKey(d => d.MediaChannelId)
                    .HasConstraintName("FK_AdSet_MediaChannel");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.AdSet)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("SupplierId_FK");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CampaignName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("ClientId_FK");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("CountryId_FK");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediaChannel>(entity =>
            {
                entity.Property(e => e.MediaChannelName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MediaChannel)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.MediaChannelId)
                    .HasConstraintName("MediaChannelId_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
