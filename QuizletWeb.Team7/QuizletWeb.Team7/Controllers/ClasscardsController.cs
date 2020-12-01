using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizletWeb.Team7.Models;

namespace QuizletWeb.Team7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasscardsController : ControllerBase
    {
        private readonly quizletDBContext _context;

        public ClasscardsController(quizletDBContext context)
        {
            _context = context;
        }

        // GET: api/Classcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classcard>>> GetClasscard()
        {
            return await _context.Classcard.ToListAsync();
        }

        // GET: api/Classcards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classcard>> GetClasscard(string id)
        {
            var classcard = await _context.Classcard.FindAsync(id);

            if (classcard == null)
            {
                return NotFound();
            }

            return classcard;
        }

        // PUT: api/Classcards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasscard(string id, Classcard classcard)
        {
            if (id != classcard.Classid)
            {
                return BadRequest();
            }

            _context.Entry(classcard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasscardExists(id))
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

        // POST: api/Classcards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Classcard>> PostClasscard(Classcard classcard)
        {
            _context.Classcard.Add(classcard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClasscardExists(classcard.Classid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClasscard", new { id = classcard.Classid }, classcard);
        }

        // DELETE: api/Classcards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Classcard>> DeleteClasscard(string id)
        {
            var classcard = await _context.Classcard.FindAsync(id);
            if (classcard == null)
            {
                return NotFound();
            }

            _context.Classcard.Remove(classcard);
            await _context.SaveChangesAsync();

            return classcard;
        }

        private bool ClasscardExists(string id)
        {
            return _context.Classcard.Any(e => e.Classid == id);
        }
    }
}
