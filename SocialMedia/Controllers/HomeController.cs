using BusinessLayer.Concrate;
using BusinessLayer.Validations;
using DataLayer;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Controllers
{
    public class HomeController : Controller
    {
        UserManager _users = new UserManager();
        User _user;
        Context db = new Context();
        public IActionResult Hatali()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            Context db = new Context();
            var control = db.Users.SingleOrDefault(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre);
            if (control != null)
            {
                return RedirectToAction("Index");
            }
            int hatalimi = 1;
            ViewBag.hatali = hatalimi;
            return View();
        }

        public IActionResult Hakkimda()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(User user)
        {
            UserValidation userValidator = new UserValidation();
            ValidationResult result = userValidator.Validate(user);

            if (result.IsValid)
            {
                _users.Add(user);
                _user = _users.GetById(user.Id);
                if (_user.KullaniciAdi == null)
                {
                    _user.KullaniciAdi = "Oluşturuldu";
                    _users.Update(_user);
                }


                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Login");
            }
    }
}
