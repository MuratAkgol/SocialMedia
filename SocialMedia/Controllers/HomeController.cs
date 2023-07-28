using BusinessLayer.Concrate;
using BusinessLayer.Validations;
using DataLayer;
using DataLayer.Migrations;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Controllers
{
    public class HomeController : Controller
    {
        UserManager _users = new UserManager();
        User _user;

        SocialsManager _socials = new SocialsManager();
        Social _social;

        Context db = new Context();

        public class GlobalDegiskenler
        {
            public static int Id { get; set; }
        }

        public IActionResult Hatali()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            ViewBag.nickName = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).NickName;
            ViewBag.profilAdi = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).KullaniciAdi;
            
            var socials = _socials.List();
            return View(socials);
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
                GlobalDegiskenler.Id = db.Users.FirstOrDefault(x => x.KullaniciAdi == user.KullaniciAdi).Id;
                return RedirectToAction("Index");
            }
            int hatalimi = 1;
            ViewBag.hatali = hatalimi;
            return View();
        }

        public IActionResult Hakkimizda()
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

        public IActionResult Profil()
        {
            ViewBag.profilAdi = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).KullaniciAdi;
            ViewBag.nickName = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).NickName;


            var socials = db.Socials.Where(x=>x.AtanKulId == GlobalDegiskenler.Id).ToList();            

            return View(socials);
        }
    }
}
