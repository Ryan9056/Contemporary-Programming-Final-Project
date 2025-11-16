using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contemporary_Programming_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        // Retrieves the first 5 team members or a specific team member by id if specified
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses(int? id)
        {
            if (id == null || id == 0)
            {
                // Take the first 5 team members from the database
                return await _context.Classes.Take(5).ToListAsync();
            }

            var Class = await _context.Classes.FindAsync(id);

            if (Class == null)
            {
                return NotFound();
            }

            return new List<Class> { Class }; // Return the specific team member
        }

        // GET: api/Classes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var Class = await _context.Classes.FindAsync(id);

            if (Class == null)
            {
                return NotFound();
            }

            return Class;
        }

        // POST: api/Classes
        // Only basic fields are required here
        [HttpPost]
        public async Task<ActionResult<Class>> PostClasses(Class Class)
        {
            // Ensure that non-required fields are not null
            if (Class.FullName == null)
            {
                return BadRequest("Name is required");
            }

            _context.Classes.Add(Class);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassById), new { id = Class.Id }, Class);
        }

        // PUT: api/Classes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class Class)
        {
            if (id != Class.Id)
            {
                return BadRequest();
            }

            _context.Entry(Class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // DELETE: api/Classes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var Class = await _context.Classes.FindAsync(id);
            if (Class == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(Class);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}