using Foros_ORT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT
{
    public interface IForo
    {
        Foro ObtenerPorId(int Id);
        IEnumerable<Foro> ObtenerTodos();
        IEnumerable<Usuario> ObtenerUsuariosActivos();

        Task Crear(Foro Foro);

        Task Eliminar(int IdForo);

        Task ActualizarTituloForo(int IdForo, string nuevoTitulo);
        Task ActualizarDescripcionForo(int IdForo, string nuevaDescripcion);
    }
}
