using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.FluentValidations
{ 
    public class ValidationProperties : AbstractValidator<Properties>
    {
      public  ValidationProperties()
        {
            RuleFor(x => x.Name).MaximumLength(60).WithMessage("Max Uzunluk 60 Karakter Olmalıdır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

        }
    }
}
