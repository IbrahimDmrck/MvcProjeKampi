using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı Mail boş bırakılmaz !");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz !");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz  !");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Göndermek istediğiniz Mesajı Giriniz !");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden az olamaz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu 50 Karakterden Fazla olamaz !");
            RuleFor(x=>x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı en az 3 karakter olmalı !");
        }
    }
}
