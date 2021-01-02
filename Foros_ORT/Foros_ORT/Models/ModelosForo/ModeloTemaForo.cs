using Foros_ORT.Models.ModelosPosteo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosForo
{
    public class ModeloTemaForo
    {
        public string PedidoBusqueda { get; set; }
        public ModeloListadoForo Foro { get; set; }
        public IEnumerable<ModeloListadoPosteo> Posteos { get; set; }
    }
}
