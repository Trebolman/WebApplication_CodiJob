using Application.DTOs;
using FluentValidation;


namespace Infraestructure.Transversal.FluentValidations
{
    public class UsuarioPerfilDTOValidator: AbstractValidator<UsuarioPerfilDTO>
    {
        public UsuarioPerfilDTOValidator()
        {
            RuleFor(x => x.UsuperDesc).NotEmpty();
            RuleFor(x => x.UsuperDesc).Length(10, 100);
            RuleFor(x => x.UsuperGit).NotEmpty();
            RuleFor(x => x.UsuperBlog).NotEmpty();
            RuleFor(x => x.UsuperWeb).NotEmpty();
        }
    }
}
