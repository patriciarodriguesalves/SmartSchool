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
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/professor
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GET api/professor/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            return Ok(professor);
        }

        // GET api/professor/nome
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (professor == null) return BadRequest("Professor não foi encontrado");

            return Ok(professor);
        }

        // POST api/professor
        [HttpPost]
        public IActionResult Post(int id, Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        // PUT api/professor/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var _professor = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (_professor == null) return BadRequest("Professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            
            return Ok(professor);
        }

        // PATCH api/professor/id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var _professor = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (_professor == null) return BadRequest("Professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        // DELETE api/professor/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok(professor);
        }
    }
}
