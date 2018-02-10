using System.Collections.Generic;
using MyGallery.Data.Entities;

namespace MyGallery.Data
{
    public interface IDatabaseRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        bool SaveChanges();
    }
}