using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientesAPI.Models;

namespace ClientesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound(new { mensaje = "Cliente no encontrado" });

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente clienteActualizado)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound(new { mensaje = "Cliente no encontrado" });

            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Correo = clienteActualizado.Correo;
            cliente.Telefono = clienteActualizado.Telefono;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound(new { mensaje = "Cliente no encontrado" });

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Cliente eliminado correctamente" });
        }
    }
}