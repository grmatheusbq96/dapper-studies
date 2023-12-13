using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Domain.Interfaces.Services;
using DapperStudy.Domain.Models;

namespace DapperStudy.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public FuncionarioModel BuscarFuncionarioPorId(int id)
        {
            var funcionario = _funcionarioRepository.GetById(id);

            return funcionario;
        }
    }
}