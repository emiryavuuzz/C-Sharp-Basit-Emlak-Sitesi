using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.FluentValidations
{
    public class ValidationProduct : AbstractValidator<Product>
    {
        public ValidationProduct()
        {


            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Maximum 50 Karakter girebilirsiniz");
            RuleFor(x => x.Name).MinimumLength(0).WithMessage("Bu Alanı Boş Bırakamazsınız");

            RuleFor(x => x.Explanation).MaximumLength(400).WithMessage("Maximum 400 Karakter girebilirsiniz");
            RuleFor(x => x.Explanation).MinimumLength(0).WithMessage("Bu Alanı Boş Bırakamazsınız");


            RuleFor(x => x.FullAdress).MaximumLength(400).WithMessage("Maximum 400 Karakter girebilirsiniz");
            RuleFor(x => x.FullAdress).MinimumLength(0).WithMessage("Bu Alanı Boş Bırakamazsınız");

         
        }
    }
}
