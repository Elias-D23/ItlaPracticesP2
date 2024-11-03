using Azure.Core;
using Crud.API.Dtos;
using Crud.Domain.Entities;
using Crud.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Controllers
{
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly CrudDbContext _context;

        public PeopleController(CrudDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetPerson")]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            return await _context.People.ToListAsync();
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult<List<Person>>> AddPerson(NewPersonRequest request)
        {

            var personDb = new Person();

            personDb.Name = request.Name;
            personDb.LastName = request.LastName;
            personDb.Email = request.Email;
            personDb.Phone = request.Phone;

            _context.People.Add(personDb);
            await _context.SaveChangesAsync();
            return Ok(personDb);
        }

        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] NewPersonRequest request)
        {
            var personDb = await _context.People.FindAsync(id);
            if (personDb == null)
            {
                return NotFound();
            }

            personDb.Name = request.Name;
            personDb.LastName = request.LastName;
            personDb.Email = request.Email;
            personDb.Phone = request.Phone;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
