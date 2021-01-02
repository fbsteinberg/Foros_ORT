using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosPosteo
{
    public class ModeloNuevoPosteo
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string NombreForo { get; set; }
        public int IdForo { get; set; }
        public string NombreAutor { get; set; }
        public string UrlImagenForo { get; set; }
    }
}
