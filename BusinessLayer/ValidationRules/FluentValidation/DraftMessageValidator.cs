using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class DraftMessageValidator: AbstractValidator<Message>
    {
        public DraftMessageValidator()
        {
         
        }
    }
}
