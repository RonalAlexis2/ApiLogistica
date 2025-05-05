using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaApi.Data;
using LogisticaApi.Models;

namespace LogisticaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioMaritimosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnvioMaritimosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvioMaritimos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvioMaritimo>>> GetEnviosMaritimos()
        {
            return await _context.EnviosMaritimos.ToListAsync();
        }

        // GET: api/EnvioMaritimos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioMaritimo>> GetEnvioMaritimo(int id)
        {
            var envioMaritimo = await _context.EnviosMaritimos.FindAsync(id);

            if (envioMaritimo == null)
            {
                return NotFound();
            }

            return envioMaritimo;
        }

        // PUT: api/EnvioMaritimos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvioMaritimo(int id, EnvioMaritimo envioMaritimo)
        {
            if (id != envioMaritimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(envioMaritimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvioMaritimoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EnvioMaritimos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvioMaritimo>> PostEnvioMaritimo(EnvioMaritimo envioMaritimo)
        {
            // Llamar a la función que calcula el descuento
            envioMaritimo.CalcularDescuento();

            _context.EnviosMaritimos.Add(envioMaritimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvioMaritimo", new { id = envioMaritimo.Id }, envioMaritimo);
        }


        // DELETE: api/EnvioMaritimos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvioMaritimo(int id)
        {
            var envioMaritimo = await _context.EnviosMaritimos.FindAsync(id);
            if (envioMaritimo == null)
            {
                return NotFound();
            }

            _context.EnviosMaritimos.Remove(envioMaritimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvioMaritimoExists(int id)
        {
            return _context.EnviosMaritimos.Any(e => e.Id == id);
        }
    }
}
