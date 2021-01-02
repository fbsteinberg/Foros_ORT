using Foros_ORT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT
{
    public class ServicioForo : IForo
    {
        private readonly ApplicationDbContext _context;
        public ServicioForo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task ActualizarDescripcionForo(int IdForo, string nuevaDescripcion)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarTituloForo(int IdForo, string nuevoTitulo)
        {
            throw new NotImplementedException();
        }

        public Task Crear(Foro Foro)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(int IdForo)
        {
            throw new NotImplementedException();
        }

        public Foro ObtenerPorId(int Id)
        {
            var foro = _context.Foros.Where(f => f.Id == Id)
                .Include(f => f.Posteos)
                    .ThenInclude(p => p.Usuario)
                .Include(f => f.Posteos)
                    .ThenInclude(p => p.Respuestas)
                        .ThenInclude(r => r.Usuario)
                        .FirstOrDefault();
            return foro;
        }

        public IEnumerable<Foro> ObtenerTodos()
        {
            return _context.Foros.Include(Foro => Foro.Posteos);
        }

        public IEnumerable<Usuario> ObtenerUsuariosActivos()
        {
            throw new NotImplementedException();
        }
    }
}
