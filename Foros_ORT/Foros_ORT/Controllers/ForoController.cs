using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foros_ORT.Models;
using Foros_ORT.Models.ModelosForo;
using Foros_ORT.Models.ModelosPosteo;
using Microsoft.AspNetCore.Mvc;

namespace Foros_ORT.Controllers
{
    public class ForoController : Controller
    {
        private readonly IPosteo _servicioPosteo;
        private readonly IForo _servicioForo;
        public ForoController(IForo servicioForo, IPosteo servicioPosteo)
        {
            _servicioForo = servicioForo;
            _servicioPosteo = servicioPosteo;
        }
        public IActionResult Index()
        {
            var foros = _servicioForo.ObtenerTodos()
                .Select(foro => new ModeloListadoForo
            {
                    Id = foro.Id,
                    Nombre = foro.Titulo,
                    Descripcion = foro.Descripcion,
                    UrlImagen = foro.UrlImagen
                    
            }
            );
            var model = new ModeloIndiceForo
            {
                ListaForo = foros
            };
            return View(model);
        }
        
        public IActionResult Tema(int id, string PedidoBusqueda)
        {
            var foro = _servicioForo.ObtenerPorId(id);
            var posteos = new List<Posteo>();

            posteos = _servicioPosteo.ObtenerPosteosFiltrados(foro, PedidoBusqueda).ToList();

            var listadoPosteo = posteos.Select(posteo => new ModeloListadoPosteo
            {
                Id = posteo.Id,
                Titulo = posteo.Titulo, 
                IdAutor = posteo.Usuario.Id,
                NombreAutor = posteo.Usuario.UserName,
                CantidadRespuestas = posteo.Respuestas.Count(),
                Fecha = posteo.Creado.ToString(),
                Foro = PasarForoAModeloListadoForo(posteo)
            }
            );
            
            var model = new ModeloTemaForo
            {
                Posteos = listadoPosteo,
                Foro = PasarForoAModeloListadoForo(foro)
            };
            
            return View(model);
        }
        
        private ModeloListadoForo PasarForoAModeloListadoForo(Posteo posteo)
        {
            var foro = posteo.Foro;
            return PasarForoAModeloListadoForo(foro);
        }

        private ModeloListadoForo PasarForoAModeloListadoForo(Foro foro)
        {
            return new ModeloListadoForo
            {
                Id = foro.Id,
                Nombre = foro.Titulo,
                Descripcion = foro.Descripcion,
                UrlImagen = foro.UrlImagen
            };
        }
        
        [HttpPost]
        public IActionResult Buscar(int id, string PedidoBusqueda)
        {
            return RedirectToAction("Tema", new { id, PedidoBusqueda });
        }
    }
}
 
