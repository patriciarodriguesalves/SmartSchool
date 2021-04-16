using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using SmartSchool.API.V1.Dtos;
using System.Collections.Generic;

namespace SmartSchool.API.V1.Controllers
{
    /// <summary>
    /// Versão 1 do meu controlador de Professores
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {       
            _repo = repo;
            _mapper = mapper;
        }

        /// <returns></returns>
        // GET: api/professor
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        // GET api/professor/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id,false);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);
                
            return Ok(professor);
        }

        // POST api/professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado");
        }

        // PUT api/professor/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não foi encontrado");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(_mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado");
        }

        // PATCH api/professor/id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não foi encontrado");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(_mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado");
        }

        // DELETE api/professor/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }
    }
}
