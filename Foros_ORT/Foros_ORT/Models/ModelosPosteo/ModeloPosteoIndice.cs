using Foros_ORT.Models.ModelosRespuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosPosteo
{
    public class ModeloIndicePosteo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string IdAutor { get; set; }
        public string nombreAutor { get; set; }
        public string UrlImagenAutor { get; set; }
        public DateTime Creado { get; set; }
        public string Contenido { get; set; }
        public IEnumerable<ModeloRespuestaPosteo> Respuestas { get; set; }
        public int IdForo { get; set; }
        public string NombreForo { get; set; }
    }
}
