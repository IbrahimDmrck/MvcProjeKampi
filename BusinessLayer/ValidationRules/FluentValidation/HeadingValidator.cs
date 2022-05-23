using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık Adı 50 Karakteri Geçemez");
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı Boş Geçilemez");
        }
    }
}
