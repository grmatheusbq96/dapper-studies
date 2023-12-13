using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Domain.Interfaces.Services;
using DapperStudy.Domain.Models;
using DapperStudy.Domain.Responses;

namespace DapperStudy.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public FuncionarioResponse<FuncionarioModel> BuscarFuncionarioPorId(int id)
        {
            var funcionario = _funcionarioRepository.GetById(id);

            return new FuncionarioResponse<FuncionarioModel>(funcionario);
        }
    }
}