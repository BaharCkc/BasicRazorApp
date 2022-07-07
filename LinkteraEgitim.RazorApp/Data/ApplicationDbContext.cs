using LinkteraEgitim.RazorApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LinkteraEgitim.RazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }
    
}
