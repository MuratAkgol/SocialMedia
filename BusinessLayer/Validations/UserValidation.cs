using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidation: AbstractValidator<User>
    {
        public UserValidation() {
            RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(x => x.NickName).NotEmpty().WithMessage("NickName boş olamaz");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre boş olamaz");
        } 
    }
}
