using AlumnosApi.Data;
using AlumnosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumnosApi.Controllers
{
    [Route("AlumnosApi/[controller]")]
    [ApiController]

    public class AlumnosController : ControllerBase
    {
        private readonly AlumnosContext _context;

        public AlumnosController(AlumnosContext context)
        {
            _context = context;
        }

        //GET xd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumno", new { id = alumno.Id }, alumno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>PutAlumno(int id, Alumno alumno) 
        {
            if (id!=alumno.Id)
            {
                return BadRequest();
            }
            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alumnos.Any(e=>e.Id==id))
                {
                    return NotFound();
                }
                else { throw; }
            }
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAlumno(int id) 
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) 
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
