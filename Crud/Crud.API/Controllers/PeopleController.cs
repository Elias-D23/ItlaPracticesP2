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

        [HttpGet("GetPeople")]
        public async Task<ActionResult<List<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        [HttpPost("AddPeople")]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
           
            //var personDb = new Person();

            //personDb.Name = request.Name;
            //personDb.LastName = request.LastName;
            //personDb.Email = request.Email;
            //personDb.Phone = request.Phone;

            List<Person> people = new List<Person>();
            people.Add(person);

            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return people;
        }
    }
}
