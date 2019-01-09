using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class LoginDTOValidator: AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(5, 20);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(5, 20);
        }
    }
}
