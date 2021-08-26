using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi1.Models;

namespace UserApi1.Controllers
{
    public class Input1
    {
        public string UserName { get; set; }
    }
    public class Input2
    {
        public string Email { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class Usertable1Controller : ControllerBase
    {
        private readonly ModelContext _context;

        public Usertable1Controller(ModelContext context)
        {
            _context = context;
        }

        [HttpPost("IsUserNameExists")]
        public async Task<ActionResult> IsExists([FromBody] Input1 input)
        {
            bool isFound = await _context.Usertable1s.AnyAsync(i => i.UserName == input.UserName);

            if (isFound == true)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost("IsEmailExists")]
        public async Task<ActionResult> IsExists([FromBody] Input2 input)
        {
            bool isFound = await _context.Usertable1s.AnyAsync(i => i.UserName == input.Email);

            if (isFound == true)
            {
                return Ok();
            }

            return NotFound();
        }

        // GET: api/Usertable1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usertable1>>> GetUsertable1s()
        {
            return await _context.Usertable1s.ToListAsync();
        }

        // GET: api/Usertable1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usertable1>> GetUsertable1(decimal id)
        {
            var usertable1 = await _context.Usertable1s.FindAsync(id);

            if (usertable1 == null)
            {
                return NotFound();
            }

            return usertable1;
        }

        // PUT: api/Usertable1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsertable1(decimal id, Usertable1 usertable1)
        {
            if (id != usertable1.UserId)
            {
                return BadRequest();
            }

            _context.Entry(usertable1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usertable1Exists(id))
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

        // POST: api/Usertable1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usertable1>> PostUsertable1(Usertable1 usertable1)
        {
            usertable1.UserId = await _context.Usertable1s.MaxAsync(i => i.UserId) + 1;
            _context.Usertable1s.Add(usertable1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Usertable1Exists(usertable1.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsertable1", new { id = usertable1.UserId }, usertable1);
        }

        // DELETE: api/Usertable1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsertable1(decimal id)
        {
            var usertable1 = await _context.Usertable1s.FindAsync(id);
            if (usertable1 == null)
            {
                return NotFound();
            }

            _context.Usertable1s.Remove(usertable1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Usertable1Exists(decimal id)
        {
            return _context.Usertable1s.Any(e => e.UserId == id);
        }
    }
}
