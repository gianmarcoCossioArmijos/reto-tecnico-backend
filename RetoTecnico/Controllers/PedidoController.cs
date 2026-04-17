using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetoTecnico.Data;
using RetoTecnico.Domain;

namespace RetoTecnico.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext cont;

        public PedidoController(AppDbContext context)
        {
            cont = context;
        }

        [HttpGet("pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPedidos()
        {
            var pedidos = await cont.Pedidos.ToListAsync();
            return Ok(pedidos);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Pedido>> GuardarPedido(Pedido pedido)
        {
            pedido.Fecha = DateTime.UtcNow;
            cont.Pedidos.Add(pedido);
            await cont.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, pedido);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Pedido>> BuscarPedido(int id)
        {
            var pedido = await cont.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPut("modificar/{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, Pedido pedido)
        {
            var pedidoEncontrado = await cont.Pedidos.FindAsync(id);
            if (pedidoEncontrado == null)
            {
                return NotFound();
            }

            pedidoEncontrado.NumeroPedido = pedido.NumeroPedido;
            pedidoEncontrado.DniCliente = pedido.DniCliente;
            pedidoEncontrado.Cliente = pedido.Cliente;
            pedidoEncontrado.Fecha = DateTime.UtcNow;
            pedidoEncontrado.Estado = pedido.Estado;
            await cont.SaveChangesAsync();
            return Ok(pedidoEncontrado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarPedido(int id)
        {
            var pedido = await cont.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            cont.Pedidos.Remove(pedido);
            await cont.SaveChangesAsync();
            return NoContent();
        }
    }
}
