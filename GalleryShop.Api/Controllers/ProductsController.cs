﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GalleryShop.Business.Repository;
using GalleryShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GalleryShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _productRepository.SelectAsync();
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
