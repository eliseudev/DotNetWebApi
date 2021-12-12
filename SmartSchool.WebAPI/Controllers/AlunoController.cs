using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Elias",
                Sobrenome = "Ataides",
                Telefone = "6299999999"
            },
            new Aluno(){
                Id = 2,
                Nome = "Elaine",
                Sobrenome = "Oliveira",
                Telefone = "6299999999"
            },
            new Aluno(){
                Id = 3,
                Nome = "Anderson",
                Sobrenome = "Oliveira",
                Telefone = "6299999999"
            },
        };
        public AlunoController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //Ex: api/aluno/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi Encontrado!");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
                a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
                );
            if (aluno == null) return BadRequest("O Aluno não foi Encontrado!");
            return Ok(aluno);
        }
    }
}
