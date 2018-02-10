using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyGallery.Data.Entities;

namespace MyGallery.Data
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _dbContext;
        private readonly UserManager<User> _userManager;

        public DatabaseSeeder(DatabaseContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _dbContext.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("alpialoglou@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Alex",
                    LastName = "Pialoglou",
                    UserName = "al.pialoglou",
                    Email = "alpialoglou@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "alex");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user!");
                }
            }

            if (!_dbContext.Products.Any())
            {
                //Add sample data
                var newProduct = new Product
                {
                    Description = "sample product description",
                    Title = "Product title",
                    Price = 15,
                    Created = DateTime.UtcNow,
                    Category = "Home Furniture",
                    User = user
                };

                _dbContext.Add(newProduct);
                _dbContext.SaveChanges();
            }

        }
    }
}
