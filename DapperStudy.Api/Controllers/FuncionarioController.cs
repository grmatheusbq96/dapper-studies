using DapperStudy.Domain.Interfaces.Services;
using DapperStudy.Domain.Responses;
using DapperStudy.Domain.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DapperStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [ProducesResponseType(typeof(ResponseBase<FuncionarioResponse>), (int)HttpStatusCode.OK)]
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarFuncionarioPorId([FromQuery] int id)
        {
            var retorno = _funcionarioService.BuscarFuncionarioPorId(id);

            return StatusCode(retorno.GetStatusCode(), retorno.Data);
        }
    }
}