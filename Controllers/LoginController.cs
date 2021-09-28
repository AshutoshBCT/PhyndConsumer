using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhyndConsumer.Models;
using System.Net.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;


namespace PhyndConsumer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            //var users = GetProductsFromAPI();

            //return View(users);
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Models.User user) {
            var resultList = new List<User>();
            var client = new HttpClient();
            var getData = client.GetAsync("https://localhost:5001/users").ContinueWith(
                    respnse =>
                    {
                        var result = respnse.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<User>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    }
                );
            getData.Wait();

            var userDetails = resultList.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            try
            {
                _httpContextAccessor.HttpContext.Session.SetString("name", userDetails.FirstName);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
