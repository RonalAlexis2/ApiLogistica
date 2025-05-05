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
    public class EnvioTerrestresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnvioTerrestresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EnvioTerrestres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvioTerrestre>>> GetEnviosTerrestres()
        {
            return await _context.EnviosTerrestres.ToListAsync();
        }

        // GET: api/EnvioTerrestres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioTerrestre>> GetEnvioTerrestre(int id)
        {
            var envioTerrestre = await _context.EnviosTerrestres.FindAsync(id);

            if (envioTerrestre == null)
            {
                return NotFound();
            }

            return envioTerrestre;
        }

        // PUT: api/EnvioTerrestres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvioTerrestre(int id, EnvioTerrestre envioTerrestre)
        {
            if (id != envioTerrestre.Id)
            {
                return BadRequest();
            }

            _context.Entry(envioTerrestre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvioTerrestreExists(id))
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

        // POST: api/EnvioTerrestres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvioTerrestre>> PostEnvioTerrestre(EnvioTerrestre envioTerrestre)
        {
            // Llamar a la función que calcula el descuento
            envioTerrestre.CalcularDescuento();

            _context.EnviosTerrestres.Add(envioTerrestre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvioTerrestre", new { id = envioTerrestre.Id }, envioTerrestre);
        }


        // DELETE: api/EnvioTerrestres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvioTerrestre(int id)
        {
            var envioTerrestre = await _context.EnviosTerrestres.FindAsync(id);
            if (envioTerrestre == null)
            {
                return NotFound();
            }

            _context.EnviosTerrestres.Remove(envioTerrestre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvioTerrestreExists(int id)
        {
            return _context.EnviosTerrestres.Any(e => e.Id == id);
        }
    }
}
