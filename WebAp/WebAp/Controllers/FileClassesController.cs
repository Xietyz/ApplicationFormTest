using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAp.Models;

namespace WebAp.Controllers
{
    [Route("api/filetest")]
    [ApiController]
    public class FileClassesController : ControllerBase
    {
        private readonly MyClassContext _context;

        public FileClassesController(MyClassContext context)
        {
            _context = context;
        }

        // GET: api/FileClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileClass>>> GetFileClass()
        {
            return await _context.FileClass.ToListAsync();
        }

        // GET: api/FileClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileClass>> GetFileClass(long id)
        {
            var fileClass = await _context.FileClass.FindAsync(id);

            if (fileClass == null)
            {
                return NotFound();
            }

            return fileClass;
        }

        // PUT: api/FileClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileClass(long id, FileClass fileClass)
        {
            if (id != fileClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileClassExists(id))
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

        [HttpPost]
        [Route("file")]
        public async Task PostFile(IFormFile file)
        {
            FileClass newFile = new FileClass(file);
            await newFile.ContainerUpload();
         
        }

        // POST: api/FileClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FileClass>> PostFileClass(FileClass fileClass)
        {
            _context.FileClass.Add(fileClass);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFileClass", new { id = fileClass.Id }, fileClass);
            return CreatedAtAction(nameof(GetFileClass), new { id = fileClass.Id }, fileClass);
        }

        // DELETE: api/FileClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FileClass>> DeleteFileClass(long id)
        {
            var fileClass = await _context.FileClass.FindAsync(id);
            if (fileClass == null)
            {
                return NotFound();
            }

            _context.FileClass.Remove(fileClass);
            await _context.SaveChangesAsync();

            return fileClass;
        }

        private bool FileClassExists(long id)
        {
            return _context.FileClass.Any(e => e.Id == id);
        }
    }
}
