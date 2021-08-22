using FluentValidation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.Api.Validators
{
    public class ClienteValidator : AbstractValidator<Clientes>
    {
        public ClienteValidator()
        {
            //RuleFor(c => c.IdCliente)
            //    .NotEmpty().WithMessage("Debe contener un valor")
            //    .When(c => c.IdCliente == 0).WithMessage("Cero no es valor válido.");

            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("Debe ingresar su nombre.")
                .Length(1, 250).WithMessage($"El nombre debe contener entre 1 y 250 caracteres.");

            RuleFor(c => c.Apellido)
                .NotEmpty().WithMessage("Debe ingresar su apellido.")
                .Length(1, 250).WithMessage("El apellido puede contener entre 1 y 250 caracteres.");

            RuleFor(c => c.Identificacion)
                .NotEmpty().WithMessage("Debe ingresar su identificación")
                .When(c => c.Identificacion == 0).WithMessage("Cero no es valor válido.");

            RuleFor(c => c.Direccion)
                .NotEmpty().WithMessage("Debe ingresar la dirección")
                .Length(1, 250).WithMessage("La dirección debe contener hasta 250 caracteres");
        }
    }
}
