using Foros_ORT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT
{
    public interface IPosteo
    {
        Posteo ObtenerPorId(int Id);
        IEnumerable<Posteo> ObtenerTodo();
        IEnumerable<Posteo> ObtenerPosteosFiltrados(Foro foro, string PedidoBusqueda);
        IEnumerable<Posteo> ObtenerPosteosPorForo(int id);
        Task Agregar(Posteo posteo);
        Task Eliminar(int Id);
        Task EditarRespuesta(int id, string nuevaRespuesta);
        Task EditarContenidoPosteo(int id, string nuevoContenido);
        Task EditarTituloPosteo(int id, string nuevoTitulo);
        Task AgregarRespuesta(Respuesta respuesta);
        IEnumerable<Posteo> ObtenerUltimosPosteos(int n);

    }
}
