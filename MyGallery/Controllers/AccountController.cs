using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Data;
using MyGallery.Data.Entities;
using MyGallery.ViewModels;

namespace MyGallery.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<User> _signInManager;

        public AccountController(IDatabaseRepository repository, IMapper mapper, SignInManager<User> signInManager) : base(repository, mapper)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (Request.Query.Keys.Contains("ReturnUrl"))
                {
                    Redirect(Request.Query["RetutnUrl"].FirstOrDefault());
                }
                RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Failed to login");
            return View();
        }

        public IActionResult Logout()
        {
            return null;
        }
    }
}