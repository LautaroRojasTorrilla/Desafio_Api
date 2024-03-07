using DesafioApi.DTO;
using DesafioApi.Models;
using DesafioApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoService productoService;

        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet("listado")]
        public IActionResult ObtenerListadoDeProductos()
        {
            List<Producto> productos = this.productoService.ObtenerTodosLosProductos();

            if (productos is not null && productos.Any())
            {
                return Ok(productos);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost("crearProducto")]

        //dto para tener objetos simples que tengan los campos de datos.
        //Sin logica o comportamiento asoc.
        public IActionResult AgregarProducto([FromBody] ProductoDTO producto)
        {

            if (this.productoService.AgregarProducto(producto))
            {
                return Ok(new { mensaje = "Se agrego el producto", producto });

            }
            else
            {
                return Conflict(new { mensaje = "No se pudo agregar el producto" });
            }
        }

        [HttpDelete("{id}")]

        public IActionResult BorrarProducto (int id)
        {
            if (id > 0)
            {
                if(this.productoService.EliminarProductoPorID(id))
                {
                    return Ok(new { mensaje = "Producto eliminado", status = 200 });
                }
                else
                {
                    return Conflict(new { mensaje = "No se pudo borrar el producto" });
                }
            }
            return BadRequest(new { status = 400, mensaje = "el id no puede ser negativo" });
        }

    }
}
