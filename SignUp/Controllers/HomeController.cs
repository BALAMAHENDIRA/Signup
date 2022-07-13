using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 

namespace SignUp.Controllers
{
    
    public class HomeController : Controller


       
    {
        private readonly ILogger<HomeController> _logger;
        signUpContext context = new signUpContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Index(User cus)
        {

            var user = context.Users.Where(x => x.UserName == cus.UserName).SingleOrDefault();
            if (user != null)
            {
                ViewBag.Notification = "This User Name is already taken";
                return View();
            }
            else
            {
                context.Add(cus);
                context.SaveChanges();

               
                return RedirectToAction("create");
            }
        }


        public IActionResult Create()
        {

            /*  var user = context.Users.Where(x => x.UserName == cus.UserName).SingleOrDefault();
              if (user != null)
              {
                  ViewBag.Notification = "This account has already existed ";
                  return View(Index);
              }
              else
              {
                  context.Add(cus);
                  context.SaveChanges();
                  return View();
              }*/
            return View();

        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Login2(string UName, string PWord)
        {
            var U = context.Users.Where(x => x.UserName == UName).SingleOrDefault();
            if(U!=null)
            {
                if(U.Password == PWord)
                {
                    

                    ViewData["UserName"] = U.UserName;
                    ViewData["Id"] = U.UserId;
                    return View();
                }
            }
            else 
            {
                return RedirectToAction("PassError");
            }

            return RedirectToAction("PassError");
        }

        public IActionResult PassError()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            ViewData.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
