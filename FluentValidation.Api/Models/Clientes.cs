using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.Api.Models
{
    public class Clientes
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Key]
        public int Identificacion { get; set; }
        public string Direccion { get; set; }
    }
}
