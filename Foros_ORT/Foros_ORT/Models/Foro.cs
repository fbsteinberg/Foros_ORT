using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models
{
    public class Foro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Creado { get; set; }
        public string UrlImagen { get; set; }
        public virtual IEnumerable<Posteo> Posteos { get; set; }
    }
}
