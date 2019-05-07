using Acosta.AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acosta.AssetTracking.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;
                                          Database=AssetTracking;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            // asset type
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Desktop Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            // asset
            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "100a",
                    AssetTypeId = 2,
                    Manufacturer = "Dell",
                    Model = "XPS",
                    Description = "24 inch monitor",
                    SerialNumber = "123JDH1"

                },

                new Asset
                {
                    Id = 2,
                    TagNumber = "200a",
                    AssetTypeId = 2,
                    Manufacturer = "HP",
                    Model = "Omen",
                    Description = "32 inch curved monitor",
                    SerialNumber = "HDU2830"

                },

                new Asset
                {
                    Id = 3,
                    TagNumber = "300SE8",
                    AssetTypeId = 3,
                    Manufacturer = "Acer",
                    Model = "XPHONE",
                    Description = "10inch smartphone",
                    SerialNumber = "93CFHS9"

                },
                
                new Asset
                {
                    Id = 4,
                    TagNumber = "KSIV8",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "Monster",
                    Description = "Best destop computer yet",
                    SerialNumber = "927CNE9"

                },
                
                new Asset
                {
                    Id = 5,
                    TagNumber = "KDIC7",
                    AssetTypeId = 1,
                    Manufacturer = "Acer",
                    Model = "Core Pro",
                    Description = "Best selling computer",
                    SerialNumber = "93CFHS9"

                }

                );
        }
    }
}
