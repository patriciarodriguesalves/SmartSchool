using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            return Ok(aluno);
        }


        // GET api/aluno/nome
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            return Ok(aluno);
        }


        // POST api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        // PUT api/aluno/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var _aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (_aluno == null) return BadRequest("Aluno não encontrado");


            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        // PATCH api/aluno/id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var _aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (_aluno == null) return BadRequest("Aluno não encontrado");
            
            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        // DELETE api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }
    }
}
