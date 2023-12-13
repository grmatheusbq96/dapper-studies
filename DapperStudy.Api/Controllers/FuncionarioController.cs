using DapperStudy.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarFuncionarioPorId([FromQuery] int id)
        {
            var retorno = _funcionarioService.BuscarFuncionarioPorId(id);
            return Ok();
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}