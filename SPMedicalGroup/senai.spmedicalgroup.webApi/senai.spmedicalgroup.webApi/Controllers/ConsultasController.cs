using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using senai.spmedicalgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultumRepository _Repository { get; set; }

        public ConsultasController()
        {
            _Repository = new ConsultumRepository();
        }

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_Repository.ListarTodos());
        }

        /// <summary>
        /// Lê todas as consultas cadastradas para esse médico
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [Authorize(Roles = "MED")]
        [HttpGet("med/{email}")]
        public IActionResult LerMed(string email)
        {
            Repositories.MedicoRepository m = new Repositories.MedicoRepository();
            return Ok(_Repository.ListarPorMed(m.BuscarPorEmail(email).IdMedico));
        }

        /// <summary>
        /// Lê todas as consultas cadastradas para esse médico
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [Authorize(Roles = "PAC")]
        [HttpGet("pac/{email}")]
        public IActionResult LerPac(string email)
        {
            Repositories.PacienteRepository p = new Repositories.PacienteRepository();
            return Ok(_Repository.ListarPorPac(p.BuscarPorEmail(email).IdPaciente));
        }

        /// <summary>
        /// Busca objeto atráves do ID
        /// </summary>
        /// <returns>Lista apenas o objeto selecionado</returns>
        [Authorize(Roles = "ADM,MED")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_Repository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um objeto
        /// </summary>
        /// <returns>Cadastra o objeto solicitado</returns>
        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum obj)
        {
            _Repository.Cadastrar(obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza a descrição da descrição
        /// </summary>
        /// <param name="obj">Objeto consulta com respectivo id</param>
        /// <returns></returns>
        [Authorize(Roles = "MED")]
        [HttpPut()]
        public IActionResult AtualizarDescricao(Consultum obj)
        {
            _Repository.Atualizar(obj.IdConsulta, obj);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um objeto
        /// </summary>
        /// <returns>Deleta o objeto solicitado</returns>
        [Authorize(Roles = "ADM")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _Repository.Deletar(id);
            return StatusCode(204);
        }
    }
}
