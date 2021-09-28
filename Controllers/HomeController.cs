using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhyndConsumer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;


namespace PhyndConsumer.Controllers
{
    public class HomeController : Controller
    {
        public string name;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            if(_httpContextAccessor.HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //name = HttpContext.Session.GetString("name");
            return View();
        }
    }
}
