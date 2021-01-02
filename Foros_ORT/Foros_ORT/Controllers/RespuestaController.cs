using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foros_ORT.Models;
using Foros_ORT.Models.ModelosRespuesta;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foros_ORT.Controllers
{
    public class RespuestaController : Controller
    {
        private readonly UserManager<Usuario> _administradorUsuario;
        private readonly IPosteo _servicioPosteo;
        public RespuestaController(IPosteo servicioPosteo, UserManager<Usuario> administradorUsuario)
        {
            _servicioPosteo = servicioPosteo;
            _administradorUsuario = administradorUsuario;
        }
        public async Task<IActionResult> Crear(int id)
        {
            var posteo = _servicioPosteo.ObtenerPorId(id);
            var usuario = await _administradorUsuario.FindByNameAsync(User.Identity.Name);

            var model = new ModeloRespuestaPosteo
            {
                ContenidoPosteo = posteo.Contenido,
                TituloPosteo = posteo.Titulo,
                IdPosteo = posteo.Id,
                NombreAutor = User.Identity.Name,
                IdAutor = usuario.Id,
                Creado = DateTime.Now,
                NombreForo = posteo.Foro.Titulo,
                IdForo = posteo.Foro.Id
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarRespuesta(ModeloRespuestaPosteo model)
        {
            var idUsuario = _administradorUsuario.GetUserId(User);
            var usuario = await _administradorUsuario.FindByIdAsync(idUsuario);

            var respuesta = ArmarRespuesta(model, usuario);

            await _servicioPosteo.AgregarRespuesta(respuesta);

            return RedirectToAction("Index", "Posteo", new { id = model.IdPosteo });
        }

        private Respuesta ArmarRespuesta(ModeloRespuestaPosteo model, Usuario usuario)
        {
            var posteo = _servicioPosteo.ObtenerPorId(model.IdPosteo);

            return new Respuesta
            {
                Posteo = posteo,
                Contenido = model.Contenido,
                Creado = DateTime.Now,
                Usuario = usuario
            };
        }

        public IActionResult Editar(int id, int idPosteo, string contenido)
        {
            var posteo = _servicioPosteo.ObtenerPorId(idPosteo);
            var model = new ModeloRespuestaPosteo
            {
                ContenidoPosteo = posteo.Contenido,
                TituloPosteo = posteo.Titulo,
                IdPosteo = posteo.Id,
                NombreAutor = User.Identity.Name,
                Creado = DateTime.Now,
                NombreForo = posteo.Foro.Titulo,
                IdForo = posteo.Foro.Id,
                Contenido = contenido,
                Id = id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarRespuesta(ModeloRespuestaPosteo model, int idPosteo)
        {
            _servicioPosteo.EditarRespuesta(model.Id, model.Contenido).Wait();
            return RedirectToAction("Index", "Posteo", new { id = idPosteo });
        }
    }
}
