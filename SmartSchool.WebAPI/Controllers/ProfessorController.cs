using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (professor == null) BadRequest("O Professor não doi encontrado!");
            return Ok(professor);
        }

        [HttpGet("byName")]
        public IActionResult ByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Nome == nome);
            if (professor == null) BadRequest("O Professor não foi encontrado!");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var proff = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (proff == null) BadRequest("O Professor não foi encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var proff = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (proff == null) BadRequest("O Professor não foi encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (professor == null) BadRequest("O Professor não foi encontrado!");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
