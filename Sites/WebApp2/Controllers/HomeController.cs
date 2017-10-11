﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController(IConfigurationRoot configuration)
        //{
        //    DefaultDB = configuration["ConnectionStrings:DefaultConnection"];
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //Configuration.GetConnectionString("defaultDb");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}