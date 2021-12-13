using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PriceCalculation.Models;
using PriceCalculation.ViewModels;

namespace PriceCalculation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPositionLogo> OrderPositionLogos { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionLogo> PositionLogos { get; set; }
        public DbSet<Textil> Textils { get; set; }
        public DbSet<TextilColor> TextilColors { get; set; }
    }
}
