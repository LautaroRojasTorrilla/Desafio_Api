using DesafioApi.Database;
using DesafioApi.DTO;
using DesafioApi.Models;
using DesafioApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService) 
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("listado")]
        public IActionResult ObtenerListadoDeUsuarios()
        {
            List <Usuario> usuarios = this.usuarioService.ObtenerTodosLosUsuarios();

            if (usuarios != null && usuarios.Any())
            {
                return Ok(usuarios);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
