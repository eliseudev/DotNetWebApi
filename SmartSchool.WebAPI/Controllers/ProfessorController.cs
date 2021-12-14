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
        private readonly IRepository _repo;

        public ProfessorController(SmartContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) BadRequest("O Professor não doi encontrado!");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges()) return Ok(professor);
            return Ok("Professor não Cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var proff = _repo.GetProfessorById(id, false);
            if (proff == null) BadRequest("O Professor não foi encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);
            return Ok("Professor não Atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var proff = _repo.GetProfessorById(id, false);
            if (proff == null) BadRequest("O Professor não foi encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);

            return Ok("Professor não Atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            _repo.Delete(professor);
            if (_repo.SaveChanges()) return Ok("Professor Deletado!");
            return BadRequest("Professor não Deletado!");
        }
    }
}
