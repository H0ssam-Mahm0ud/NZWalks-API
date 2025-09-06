using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("fc472633-3da0-4844-945d-ae2b1fb7d6d8"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a93ff308-a1a5-43b5-8aa1-bffff3ddd44b"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("678c41a8-3df5-4b23-8f3e-194ff06b2056"),
                    Name = "Hard",
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("53012cc3-2f72-445e-9133-f5cce605ebdd"),
                    Name = "Russia",
                    Code = "Rus",
                    RegionImageUrl = "https://penntoday.upenn.edu/sites/default/files/2022-02/Russian-Disinformation-PWH.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("11f3fc30-888f-4de6-a13c-dfe84c19a281"),
                    Name = "Paris",
                    Code = "Par",
                    RegionImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8cGFyaXN8ZW58MHx8MHx8fDA%3D"
                },
                new Region()
                {
                    Id = Guid.Parse("c0652939-bf95-4cf1-a40f-3d6e998638b9"),
                    Name = "Germany",
                    Code = "Gem",
                    RegionImageUrl = "https://etimg.etb2bimg.com/photo/93896068.cms"
                },
                new Region()
                {
                    Id = Guid.Parse("06874890-fb2c-48ba-aae3-3a5d228ff446"),
                    Name = "Sutherland",
                    Code = "Sul",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRJeZ2Kjks3UVg6A6_hfkx2N7ApDtF7esuIWkTfe3_jPMsOO8NJm2tWEL4nGbr870GpTY&usqp=CAU"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
