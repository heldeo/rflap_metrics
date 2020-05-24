using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rflap_metrics.Models;

namespace rflap_metrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly ExportContext _context;

        public ExportController(ExportContext context)
        {
            _context = context;
        }

        // GET: api/Export
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Export>>> GetExport()
        {
            return await _context.Export.ToListAsync();
        }

        // GET: api/Export/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Export>> GetExport(int id)
        {
            var export = await _context.Export.FindAsync(id);

            if (export == null)
            {
                return NotFound();
            }

            return export;
        }

        // PUT: api/Export/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExport(int id, Export export)
        {
            if (id != export.dataID)
            {
                return BadRequest();
            }

            _context.Entry(export).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportExists(id))
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

        // POST: api/Export
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Export>> PostExport(Export export)
        {
            _context.Export.Add(export);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExport", new { id = export.dataID }, export);
        }

        // DELETE: api/Export/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Export>> DeleteExport(int id)
        {
            var export = await _context.Export.FindAsync(id);
            if (export == null)
            {
                return NotFound();
            }

            _context.Export.Remove(export);
            await _context.SaveChangesAsync();

            return export;
        }

        private bool ExportExists(int id)
        {
            return _context.Export.Any(e => e.dataID == id);
        }
    }
}
