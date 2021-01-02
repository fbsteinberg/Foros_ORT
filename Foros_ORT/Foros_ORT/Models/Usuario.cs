using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models
{
    public class Usuario : IdentityUser
    {
        public string UrlImagen { get; set; }
        public DateTime Creado { get; set; }
        public bool estaActivo { get; set; }
    }
}
