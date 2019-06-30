using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Database.Entities;

namespace ShallowLibAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesControllerItem : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LibrariesControllerItem(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LibrariesControllerItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibrarys()
        {
            return await _context.Librarys.ToListAsync();
        }

        // GET: api/LibrariesControllerItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            var library = await _context.Librarys.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        // PUT: api/LibrariesControllerItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary([FromQuery]int id, [FromBody]Library library)
        {
            if (id != library.ID)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
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

        // POST: api/LibrariesControllerItem
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            _context.Librarys.Add(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.ID }, library);
        }

        // DELETE: api/LibrariesControllerItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Library>> DeleteLibrary(int id)
        {
            var library = await _context.Librarys.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Librarys.Remove(library);
            await _context.SaveChangesAsync();

            return library;
        }

        private bool LibraryExists(int id)
        {
            return _context.Librarys.Any(e => e.ID == id);
        }
    }
}
