using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Models;

namespace PhonebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly TodoContext _context;

        public PhonebookController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Phonebook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phonebook>>> GetPhoneBook()
        {
            return await _context.PhoneBook.ToListAsync();
        }

        // GET: api/Phonebook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phonebook>> GetPhonebook(int id)
        {
            var phonebook = await _context.PhoneBook.FindAsync(id);

            if (phonebook == null)
            {
                return NotFound();
            }

            return phonebook;
        }

        // PUT: api/Phonebook/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhonebook(int id, Phonebook phonebook)
        {
            if (id != phonebook.PhoneBookId)
            {
                return BadRequest();
            }

            _context.Entry(phonebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhonebookExists(id))
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

        // POST: api/Phonebook
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Phonebook>> PostPhonebook(Phonebook phonebook)
        {
            _context.PhoneBook.Add(phonebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhonebook", new { id = phonebook.PhoneBookId }, phonebook);
        }

        // DELETE: api/Phonebook/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phonebook>> DeletePhonebook(int id)
        {
            var phonebook = await _context.PhoneBook.FindAsync(id);
            if (phonebook == null)
            {
                return NotFound();
            }

            _context.PhoneBook.Remove(phonebook);
            await _context.SaveChangesAsync();

            return phonebook;
        }

        private bool PhonebookExists(int id)
        {
            return _context.PhoneBook.Any(e => e.PhoneBookId == id);
        }
    }
}
