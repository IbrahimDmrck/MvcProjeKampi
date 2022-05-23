using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılmaz !");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar adı en az 3 karakter olabilir !");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Yazar adı en fazla 50 karakter olabilir  !");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar açıklaması  boş bırakılmaz !");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Email  boş bırakılmaz !");
            RuleFor(x => x.writerPassword).NotEmpty().WithMessage("Şifre  boş bırakılmaz !");
            RuleFor(x => x.writerPassword).MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır!");
            RuleFor(x => x.writerPassword).MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır  !");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkımda Alanı Boş Bırakılamaz --Kendinizi Tanıtan Birkaç Cümle Yazınız--");
            RuleFor(x => x.writerTitle).NotEmpty().WithMessage("Lütfen Ünvanınız Belirtiniz");
        }
    }
}
