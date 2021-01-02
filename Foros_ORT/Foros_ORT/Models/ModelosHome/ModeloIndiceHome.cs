using Foros_ORT.Models.ModelosPosteo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT.Models.ModelosHome
{
    public class ModeloIndiceHome
    {
        public string PedidoBusqueda { get; set; }
        public IEnumerable<ModeloListadoPosteo> UltimosPosteos { get; set; }
    }
}
