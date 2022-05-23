using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Hakkımda alanları boş bırakılamaz !");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Hakkımda alanları boş bırakılamaz !");
        }
    }
}
