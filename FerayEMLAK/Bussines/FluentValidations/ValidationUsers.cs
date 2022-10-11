using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.FluentValidations
{
    public class ValidationUsers : AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Max Uzunluk 50 Karakter Olmalıdır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Max Uzunluk 50 Karakter Olmalıdır");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

            RuleFor(x => x.PhoneNumber).MaximumLength(14).WithMessage("Karakter Sınırını aştınız");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Mail Adresi Giriniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");

            RuleFor(x => x.Password).MaximumLength(30).WithMessage("Max Uzunluk 30 Karakter Olmalıdır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");


        }
    }
}

