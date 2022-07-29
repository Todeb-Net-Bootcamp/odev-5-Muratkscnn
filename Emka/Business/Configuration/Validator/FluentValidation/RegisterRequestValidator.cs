using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Personel Kodu Giriniz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Personel İsmi Giriniz.");
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifre Giriniz");
            RuleFor(x => x.Password).Equal(x => x.RePassword).When(x => !string.IsNullOrWhiteSpace(x.Password)).WithMessage("Şifreler Uyuşmuyor..");
            
        }
    }
}
