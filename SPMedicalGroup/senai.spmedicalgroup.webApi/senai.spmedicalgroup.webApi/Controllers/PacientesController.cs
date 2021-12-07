using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _Repository { get; set; }

        public PacientesController()
        {
            _Repository = new Repositories.PacienteRepository();
        }

        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_Repository.ListarTodos());
        }

    }
}
