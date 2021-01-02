using Foros_ORT.Models.ModelosForo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosPosteo
{
    public class ModeloListadoPosteo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NombreAutor { get; set; }
        public string IdAutor { get; set; }
        public string Fecha { get; set; }
        public ModeloListadoForo Foro { get; set; }
        public int CantidadRespuestas { get; set; }
    }
}
