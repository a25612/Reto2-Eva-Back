using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using DTOs;


namespace Piscina_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _servicePago;

        public PagoController(IPagoService service)
        {
            _servicePago = service;
        }

        // Obtener todos los Pagos
        [HttpGet]
        public async Task<ActionResult<List<Pago>>> GetPagos()
        {
            var pago = await _servicePago.GetAllAsync();
            return Ok(pago);
        }

        // Obtener un anuncio por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
            var pago = await _servicePago.GetByIdAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        // Crear un nuevo anuncio
        [HttpPost]
        public async Task<ActionResult<Pago>> CreatePago([FromBody] CrearPagoDTO pagoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pago = new Pago
            {
                ID_USUARIO = pagoDTO.ID_USUARIO,
                ID_SESION = pagoDTO.ID_SESION,
                Monto = pagoDTO.Monto,
                Metodo_Pago = pagoDTO.Metodo_Pago,
                Fecha_Pago = pagoDTO.Fecha_Pago,
                Estado = pagoDTO.Estado
            };

            await _servicePago.AddAsync(pago);

            return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, pago);
        }


        // Actualizar un anuncio existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePago(int id, Pago pago)
        {
            var existingPago = await _servicePago.GetByIdAsync(id);
            if (existingPago == null)
            {
                return NotFound();
            }

            existingPago.ID_USUARIO = pago.ID_USUARIO;
            existingPago.ID_SESION = pago.ID_SESION;
            existingPago.Monto = pago.Monto;
            existingPago.Metodo_Pago = pago.Metodo_Pago;
            existingPago.Fecha_Pago = pago.Fecha_Pago;
            existingPago.Estado = pago.Estado;

            await _servicePago.UpdateAsync(existingPago);
            return NoContent();
        }

        // Eliminar un anuncio por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var pago = await _servicePago.GetByIdAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            await _servicePago.DeleteAsync(id);
            return NoContent();
        }
    }
}
