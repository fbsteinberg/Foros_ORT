using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosRespuesta
{
    public class ModeloRespuestaPosteo
    {
        public int Id { get; set; }
        public string IdAutor { get; set; }
        public string NombreAutor { get; set; }
        public string UrlImagenAutor { get; set; }
        public DateTime Creado { get; set; }
        public string Contenido { get; set; }
        public int IdPosteo { get; set; }
        public string TituloPosteo { get; set; }
        public string ContenidoPosteo { get; set; }
        public string NombreForo { get; set; }
        public int IdForo { get; set; }
    }
}
