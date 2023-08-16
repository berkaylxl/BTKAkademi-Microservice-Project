using BtkAkademi.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BtkAkademi.Services.ShoppingCartAPI.DbContezt
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
