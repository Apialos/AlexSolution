using Microsoft.EntityFrameworkCore;
using MyGallery.Data.Entities;

namespace MyGallery.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products{ get; set; }
    }
}
