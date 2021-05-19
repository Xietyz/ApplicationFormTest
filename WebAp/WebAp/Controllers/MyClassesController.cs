using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAp.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace WebAp.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class MyClassesController : ControllerBase
    {
        private readonly MyClassContext _context;

        public MyClassesController(MyClassContext context)
        {
            _context = context;
        }

        // GET: api/MyClasses
        //[HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyClass>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/MyClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyClass>> GetMyClass(long id)
        {
            var myClass = await _context.TodoItems.FindAsync(id);

            if (myClass == null)
            {
                return NotFound();
            }

            return myClass;
        }

        // PUT: api/MyClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyClass(long id, MyClass myClass)
        {
            if (id != myClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(myClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyClassExists(id))
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

        // POST: api/MyClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Route("user")]
        [HttpPost]
        [Route("/")]
        public MyClass PostUser(MyClass newUser)
        {
            //creating new user
            return newUser;
        }

        // DELETE: api/MyClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyClass>> DeleteMyClass(long id)
        {
            var myClass = await _context.TodoItems.FindAsync(id);
            if (myClass == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(myClass);
            await _context.SaveChangesAsync();

            return myClass;
        }

        private bool MyClassExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }

    //public class MyClass
    //{
    //    public string OrgName { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Position { get; set; }
    //    public string Website { get; set; }
    //    public string FCANo { get; set; }
    //    public string MembershipNo { get; set; }
    //    public string PhoneNo { get; set; }
    //    public string Address { get; set; }
    //    public string Insurer { get; set; }
    //    public string PolicyNo { get; set; }
    //}
}
