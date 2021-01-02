using System;
using System.Collections.Generic;

namespace Foros_ORT.Models
{
    public class Posteo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime Creado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Foro Foro { get; set; }
        public virtual IEnumerable<Respuesta> Respuestas { get; set; }
    }
}