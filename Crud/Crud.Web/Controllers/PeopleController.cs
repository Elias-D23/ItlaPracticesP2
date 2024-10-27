using Crud.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud.Domain.Entities;

namespace Crud.Web.Controllers
{

    public class PeopleController : Controller
    {

        private readonly CrudDbContext _Dbcontext;

        public PeopleController(CrudDbContext context)
        {
            _Dbcontext = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            await _Dbcontext.People.AddAsync(person);
            await _Dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async  Task<IActionResult> List()
        {
            List<Person> listPersons = await _Dbcontext.People.ToListAsync();
            return View(listPersons);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Person person = await _Dbcontext.People.FirstAsync(e => e.Id == id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            _Dbcontext.People.Update(person);
            await _Dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Person person = await _Dbcontext.People.FirstAsync(e => e.Id == id);

            _Dbcontext.People.Remove(person);
            await _Dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
