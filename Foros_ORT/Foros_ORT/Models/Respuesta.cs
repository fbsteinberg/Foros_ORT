using System;

namespace Foros_ORT.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Creado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Posteo Posteo { get; set; }
    }
}