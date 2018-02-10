using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Data;
using WebAppExample.Models;

namespace MyGallery.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDatabaseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
