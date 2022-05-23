using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Göndermek İstediğiniz Mesajı Giriniz !");
            RuleFor(X => X.ReceiverMail).NotEmpty().WithMessage("Lütfen Bir Alıcı Mail Adresi Girin !");
          //  RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Lütfen Gönderici Maili Girin ! ");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("İletmek istediğiniz Konuyu Girinn");
            RuleFor(X => X.Subject).MinimumLength(5).WithMessage("İletmek istediğiniz Konu En az 5 karakter olmalıdır");
            
        }
    }
}
