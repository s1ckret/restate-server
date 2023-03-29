using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace restate_server_core_1.Models
{
    public partial class adsContext : DbContext
    {
        public adsContext()
        {
        }

        public adsContext(DbContextOptions<adsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ads { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Origin> Origins { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<PhotoFeature> PhotoFeatures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Ad>(entity =>
            {
                entity.ToTable("ad");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BuildingId, "ad_buildingId_idx");

                entity.HasIndex(e => e.TheirId, "theirId")
                    .IsUnique();

                entity.HasIndex(e => e.Url, "url")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AtFloor).HasColumnName("atFloor");

                entity.Property(e => e.BuildingId).HasColumnName("buildingId");

                entity.Property(e => e.Currency)
                    .HasColumnType("enum('UAH','USD','EUR')")
                    .HasColumnName("currency");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FoundAtSec).HasColumnName("foundAtSec");

                entity.Property(e => e.OriginId).HasColumnName("originId");

                entity.Property(e => e.PostedAtSec).HasColumnName("postedAtSec");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReadyForLiving).HasColumnName("readyForLiving");

                entity.Property(e => e.RoomQty).HasColumnName("roomQty");

                entity.Property(e => e.TheirId).HasColumnName("theirId");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.TotalArea).HasColumnName("totalArea");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne<Building>(e => e.Building)
                      .WithMany(e => e.Ads)
                      .HasForeignKey(e => e.BuildingId);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.OsmId, "osmId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Geojson)
                    .HasColumnType("json")
                    .HasColumnName("geojson");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(255)
                    .HasColumnName("houseNumber");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.MaxFloors).HasColumnName("maxFloors");

                entity.Property(e => e.OsmId).HasColumnName("osmId");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("origin");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.HasIndex(e => e.Url, "url")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photo");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Key, "key")
                    .IsUnique();

                entity.HasIndex(e => e.AdId, "photo_adId_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdId).HasColumnName("adId");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.HasOne<Ad>(e => e.Ad)
                      .WithMany(e => e.Photos)
                      .HasForeignKey(e => e.AdId);
            });

            modelBuilder.Entity<PhotoFeature>(entity =>
            {
                entity.HasKey(e => new { e.PhotoId, e.ModelId, e.Version })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("photoFeature");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ModelId, "photoFeature_modelId_idx");

                entity.HasIndex(e => e.PhotoId, "photoFeature_photoId_idx");

                entity.Property(e => e.PhotoId).HasColumnName("photoId");

                entity.Property(e => e.ModelId).HasColumnName("modelId");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.Property(e => e.Features)
                    .HasColumnType("json")
                    .HasColumnName("features");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
