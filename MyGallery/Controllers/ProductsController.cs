using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Data;
using MyGallery.Data.Entities;
using MyGallery.ViewModels;

namespace MyGallery.Controllers
{
    //[Route("api/[Controller]")]
    [Authorize]
    public class ProductsController : BaseController
    {
        public ProductsController(IDatabaseRepository repository, IMapper mapper): base(repository, mapper)
        {
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> Index()
        {
            var results = _repository.GetAllProducts();

            var products = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(results);
            return products;
        }

        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return null;
        }
    }
}
