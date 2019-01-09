using Application.DTOs;
using FluentValidation;

namespace Infraestructure.Transversal.FluentValidations
{
    public class GrupoDTOValidator: AbstractValidator<GrupoDTO>
    {
        public GrupoDTOValidator()
        {
            RuleFor(x => x.GrupoNom).NotEmpty();
            RuleFor(x => x.GrupoNom).Length(10, 100);
            RuleFor(x => x.GrupoProm).NotEmpty();
        }
    }
}
