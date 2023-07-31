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
            if (GlobalDegiskenler.Id == 0)
            {
                return RedirectToAction("Login");
                
            }

            ViewBag.nickName = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).NickName;
            ViewBag.profilAdi = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).KullaniciAdi;

            var result = (from u in db.Users
                          join s in db.Socials
                          on u.Id equals s.AtanKulId
                          orderby s.Id descending
                          select new UserSocialData
                          {
                              KullaniciAdi = u.KullaniciAdi,
                              Icerik = s.Icerik
                          }).ToList();


            var socials = _socials.List();
            return View(result);
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
                var control = db.Users.FirstOrDefault(x => x.KullaniciAdi == user.KullaniciAdi);
                if (control == null)
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
                    return RedirectToAction("KayitOl");
                }
                
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
            if (GlobalDegiskenler.Id == 0)
            {
                return RedirectToAction("Login");

            }

            ViewBag.profilAdi = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).KullaniciAdi;
            ViewBag.nickName = db.Users.FirstOrDefault(x => x.Id == GlobalDegiskenler.Id).NickName;


            var socials = db.Socials.Where(x=>x.AtanKulId == GlobalDegiskenler.Id).ToList();            

            return View(socials);
        }

        [HttpPost]
        public IActionResult SocailAt(Social social)
        {
            ViewBag.atankulId = GlobalDegiskenler.Id;
            SocialValidation socialValidator = new SocialValidation();
            ValidationResult result = socialValidator.Validate(social);

            if (result.IsValid)
            {
                var control = db.Socials.FirstOrDefault(x=>x.Icerik == social.Icerik);

                if (control == null) {
                    _socials.Add(social);
                    _social = _socials.GetById(social.Id);

                    if (_social.AtanKulId == 0)
                    {
                        _social.AtanKulId = GlobalDegiskenler.Id;
                        _socials.Update(_social);
                    }
                }
                return RedirectToAction("Index");
            }

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
    }
}
