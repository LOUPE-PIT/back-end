﻿using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.API.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
