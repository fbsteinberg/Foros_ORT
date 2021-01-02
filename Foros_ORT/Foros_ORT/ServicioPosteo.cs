using Foros_ORT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foros_ORT
{
    public class ServicioPosteo : IPosteo
    {
        private readonly ApplicationDbContext _context;

        public ServicioPosteo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Agregar(Posteo posteo)
        {
            _context.Add(posteo);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarRespuesta(Respuesta respuesta)
        {
            _context.Add(respuesta);
            await _context.SaveChangesAsync();
        }

        public async Task EditarRespuesta(int id, string nuevaRespuesta)
        {
            var respuesta = _context.Respuestas.Where(r => r.Id == id).First();
            respuesta.Contenido = nuevaRespuesta;
            await _context.SaveChangesAsync();
        }

        public async Task EditarContenidoPosteo(int id, string nuevoContenido)
        {
            var posteo = _context.Posteos.Where(posteo => posteo.Id == id).First();
            posteo.Contenido = nuevoContenido;
            await _context.SaveChangesAsync();
        }

        public async Task EditarTituloPosteo(int id, string nuevoTitulo)
        {
            var posteo = _context.Posteos.Where(posteo => posteo.Id == id).First();
            posteo.Titulo = nuevoTitulo;
            await _context.SaveChangesAsync();
        }

        public Task Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Posteo ObtenerPorId(int Id)
        {
            return _context.Posteos.Where(posteo => posteo.Id == Id)
                .Include(posteo => posteo.Usuario)
                .Include(posteo => posteo.Foro)
                .Include(posteo => posteo.Respuestas)
                    .ThenInclude(r => r.Usuario)
                .First();
        }

        public IEnumerable<Posteo> ObtenerPosteosFiltrados(Foro foro, string PedidoBusqueda)
        {
            return string.IsNullOrEmpty(PedidoBusqueda) 
                ? 
                    foro.Posteos 
                :
                    foro.Posteos.Where(posteo => posteo.Titulo.Contains(PedidoBusqueda) || posteo.Contenido.Contains(PedidoBusqueda));
        }

        public IEnumerable<Posteo> ObtenerPosteosPorForo(int id)
        {
            return _context.Foros.Where(foro => foro.Id == id).First().Posteos;
        }

        public IEnumerable<Posteo> ObtenerTodo()
        {
            return _context.Posteos
                .Include(posteo => posteo.Usuario)
                .Include(posteo => posteo.Respuestas)
                    .ThenInclude(respuesta => respuesta.Usuario)
                .Include(posteo => posteo.Foro);
        }

        public IEnumerable<Posteo> ObtenerUltimosPosteos(int n)
        {
            return ObtenerTodo().OrderByDescending(posteo => posteo.Creado).Take(n);
        }
    }
}
