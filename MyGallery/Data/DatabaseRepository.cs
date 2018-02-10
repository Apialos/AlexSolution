using System.Collections.Generic;
using System.Linq;
using MyGallery.Data.Entities;

namespace MyGallery.Data
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly DatabaseContext _dbContext;

        public DatabaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.OrderBy(p => p.Title).ToList();
        }

        public Product GetProductById(int id)
        {
            return null;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
