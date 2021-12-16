using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksApi.Models;
using BooksApi.Data;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book_api_Controller : ControllerBase
    {
        private readonly Book_api_context _context;

        public Book_api_Controller(Book_api_context context)
        {
            _context = context;
        }

        // GET: api/Bapis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book_api>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Bapis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book_api>> GetBapi(long id)
        {
            var bapi = await _context.Books.FindAsync(id);

            if (bapi == null)
            {
                return NotFound();
            }

            return bapi;
        }

        // PUT: api/Bapis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBapi(long id, Book_api bapi)
        {
            if (id != bapi.Id)
            {
                return BadRequest();
            }

            _context.Entry(bapi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BapiExists(id))
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

        // POST: api/Bapis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book_api>> PostBapi(Book_api bapi)
        {
            _context.Books.Add(bapi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBapi", new { id = bapi.Id }, bapi);
        }

        // DELETE: api/Bapis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBapi(long id)
        {
            var bapi = await _context.Books.FindAsync(id);
            if (bapi == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bapi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BapiExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
