using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryShop.Domain;
using Microsoft.Extensions.Configuration;

namespace GalleryShop.Business.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) 
            : base(configuration.GetConnectionString(Known.DbName))
        {
        }

        public async Task<IEnumerable<Product>> SelectAsync()
        {
            return await QueryItemsSimpleAsync<Product>("[dbo].[Products_Select]");
        }
    }
}
