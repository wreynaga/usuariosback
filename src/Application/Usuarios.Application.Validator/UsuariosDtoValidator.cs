using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.DTO;

namespace Usuarios.Application.Validator
{
    public class UsuariosDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuariosDtoValidator()
        {
            RuleFor(u => u.Nombre).NotNull().NotEmpty();
            RuleFor(u => u.Correo).NotNull().NotEmpty().EmailAddress().WithMessage("Se debe ingresar un correo valido!");
            RuleFor(u => u.Edad).NotNull().NotEmpty();
        }
    }
}
