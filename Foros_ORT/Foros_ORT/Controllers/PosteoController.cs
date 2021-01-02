using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foros_ORT.Models;
using Foros_ORT.Models.ModelosPosteo;
using Foros_ORT.Models.ModelosRespuesta;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foros_ORT.Controllers
{
    public class PosteoController : Controller
    {
        private readonly IForo _servicioForo;
        private readonly IPosteo _servicioPosteo;
        private static UserManager<Usuario> _administradorUsuario;
        public PosteoController(IPosteo servicioPosteo, IForo servicioForo, UserManager<Usuario> administradorUsuario)
        {
            _servicioPosteo = servicioPosteo;
            _servicioForo = servicioForo;
            _administradorUsuario = administradorUsuario;
        }
        public IActionResult Index(int id)
        {
            var posteo = _servicioPosteo.ObtenerPorId(id);
            var respuestas = ArmarRespuestas(posteo.Respuestas);
            var model = new ModeloIndicePosteo
            {
                Id = posteo.Id,
                Titulo = posteo.Titulo,
                IdAutor = posteo.Usuario.Id,
                nombreAutor = posteo.Usuario.UserName,
                UrlImagenAutor = posteo.Usuario.UrlImagen,
                Creado = posteo.Creado,
                Contenido = posteo.Contenido,
                Respuestas = respuestas,
                IdForo = posteo.Foro.Id,
                NombreForo = posteo.Foro.Titulo
            };
            return View(model);
        }
        public IActionResult Crear(int id)
        {
            var foro = _servicioForo.ObtenerPorId(id);
            var model = new ModeloNuevoPosteo
            {
                NombreForo = foro.Titulo,
                IdForo = foro.Id,
                UrlImagenForo = foro.UrlImagen,
                NombreAutor = User.Identity.Name
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AgregarPosteo(ModeloNuevoPosteo model)
        {
            var idUsuario = _administradorUsuario.GetUserId(User);
            var usuario = await _administradorUsuario.FindByIdAsync(idUsuario);
            var posteo = armarPosteo(model, usuario);

             _servicioPosteo.Agregar(posteo).Wait();
            return RedirectToAction("Index", "Posteo", new { id = posteo.Id });
        }

        private Posteo armarPosteo(ModeloNuevoPosteo model, Usuario usuario)
        {
            var foro = _servicioForo.ObtenerPorId(model.IdForo);
            return new Posteo
            {
                Titulo = model.Titulo,
                Creado = DateTime.Now,
                Contenido = model.Contenido,
                Usuario = usuario,
                Foro = foro
            };
        }
        private IEnumerable<ModeloRespuestaPosteo> ArmarRespuestas(IEnumerable<Models.Respuesta> respuestas)
        {
            return respuestas.Select
            (r => new ModeloRespuestaPosteo
            {
                Id = r.Id,
                NombreAutor = r.Usuario.UserName,
                IdAutor = r.Usuario.Id,
                UrlImagenAutor = r.Usuario.UrlImagen,
                Creado = r.Creado,
                Contenido = r.Contenido
            }
            );
        }
        public IActionResult Editar(int id, int idForo)
        {
            var foro = _servicioForo.ObtenerPorId(idForo);
            var posteo = _servicioPosteo.ObtenerPorId(id);
            ViewData["idPosteo"] = id;
            var model = new ModeloNuevoPosteo
            {
                NombreForo = foro.Titulo,
                IdForo = foro.Id,
                UrlImagenForo = foro.UrlImagen,
                NombreAutor = User.Identity.Name,
                Contenido = posteo.Contenido,
                Titulo = posteo.Titulo
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarPosteo(ModeloNuevoPosteo model, int idPosteo)
        {
            _servicioPosteo.EditarTituloPosteo(idPosteo, model.Titulo).Wait();
            _servicioPosteo.EditarContenidoPosteo(idPosteo, model.Contenido).Wait();
            return RedirectToAction("Index", "Posteo", new { id = idPosteo });
        }
    }
}
