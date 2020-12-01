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
    public class FlashcardsController : ControllerBase
    {
        private readonly quizletDBContext _context;

        public FlashcardsController(quizletDBContext context)
        {
            _context = context;
        }

        // GET: api/Flashcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetFlashcard()
        {
            return await _context.Flashcard.ToListAsync();
        }

        // GET: api/Flashcards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flashcard>> GetFlashcard(string id)
        {
            var flashcard = await _context.Flashcard.FindAsync(id);

            if (flashcard == null)
            {
                return NotFound();
            }

            return flashcard;
        }

        // PUT: api/Flashcards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashcard(string id, Flashcard flashcard)
        {
            if (id != flashcard.Flashcardid)
            {
                return BadRequest();
            }

            _context.Entry(flashcard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashcardExists(id))
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

        // POST: api/Flashcards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flashcard>> PostFlashcard(Flashcard flashcard)
        {
            _context.Flashcard.Add(flashcard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlashcardExists(flashcard.Flashcardid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlashcard", new { id = flashcard.Flashcardid }, flashcard);
        }

        // DELETE: api/Flashcards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flashcard>> DeleteFlashcard(string id)
        {
            var flashcard = await _context.Flashcard.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }

            _context.Flashcard.Remove(flashcard);
            await _context.SaveChangesAsync();

            return flashcard;
        }

        private bool FlashcardExists(string id)
        {
            return _context.Flashcard.Any(e => e.Flashcardid == id);
        }
    }
}
