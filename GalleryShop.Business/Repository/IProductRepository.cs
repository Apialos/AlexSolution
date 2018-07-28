using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryShop.Domain;

namespace GalleryShop.Business.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SelectAsync();
    }
}