using FluentValidation.Api.Context;
using FluentValidation.Api.Models;
using FluentValidation.Api.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IValidator<Clientes> validators;

        public ClientesController(AppDbContext context, IValidator<Clientes> validators)
        {
            this.context = context;
            this.validators = validators;
        }

        [HttpPost]
        public string CreateClientes(Clientes clientes)
        {
            //Clientes cliente = new Clientes();
            //ClienteValidator validator = new ClienteValidator();
            ValidationResult result = validators.Validate(clientes);
            string allMessages = result.ToString("~");

            Console.WriteLine(allMessages);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    var resultado = "Propiedad: " + failure.PropertyName + " falló la validación. El error fue: " + failure.ErrorMessage;
                    resultado = "Propiedad " + failure.PropertyName + " falló la validación. El error fue " + failure.ErrorMessage;

                    return resultado.ToString();
                }
            }

            context.Clientes.Add(clientes);
            context.SaveChanges();

            string message = "Se guardó correctamente.";
            return message;
        }
    }
}
