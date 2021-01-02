using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Foros_ORT.Models;
using Foros_ORT.Models.ModelosHome;
using Foros_ORT.Models.ModelosPosteo;
using Foros_ORT.Models.ModelosForo;

namespace Foros_ORT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPosteo _servicioPosteo;

        public HomeController(ILogger<HomeController> logger, IPosteo servicioPosteo)
        {
            _logger = logger;
            _servicioPosteo = servicioPosteo;
        }

        public IActionResult Index()
        {
            var model = ArmarModeloIndiceHome();
            return View(model);
        }

        private ModeloIndiceHome ArmarModeloIndiceHome()
        {
            var ultimosPosteos = _servicioPosteo.ObtenerUltimosPosteos(10);

            var posteos = ultimosPosteos.Select(posteo => new ModeloListadoPosteo
            {
                Id = posteo.Id,
                Titulo = posteo.Titulo,
                IdAutor = posteo.Usuario.Id,
                NombreAutor = posteo.Usuario.UserName,
                Fecha = posteo.Creado.ToString(),
                CantidadRespuestas = posteo.Respuestas.Count(),
                Foro = ObtenerListadoForoParaPosteo(posteo)
            }
            );
            return new ModeloIndiceHome
            {
                UltimosPosteos = posteos,
                PedidoBusqueda = ""
            };
        }

        private ModeloListadoForo ObtenerListadoForoParaPosteo(Posteo posteo)
        {
            var foro = posteo.Foro;
            return new ModeloListadoForo
            {
                Id = foro.Id,
                Nombre = foro.Titulo,
                UrlImagen = foro.UrlImagen 
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
