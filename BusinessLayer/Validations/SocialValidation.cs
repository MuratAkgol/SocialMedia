using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class SocialValidation: AbstractValidator<Social>
    {
        public SocialValidation() {
            RuleFor(x => x.Icerik).NotEmpty().WithMessage("İçerik boş olamaz");
        }
    }
}
