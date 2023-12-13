using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Domain.Interfaces.Services;
using DapperStudy.Domain.Responses;
using DapperStudy.Domain.Responses.Base;

namespace DapperStudy.Services.Funcionario
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public ResponseBase<FuncionarioResponse> BuscarFuncionarioPorId(int id)
        {
            try
            {
                var funcionarioModel = _funcionarioRepository.GetById(id);
                if (funcionarioModel == null)
                    return ResponseBase<FuncionarioResponse>.CreateError(404)
                        .AddMessage("Cliente não encontrado.");

                var funcionarioResponse = new FuncionarioResponse(funcionarioModel);

                return ResponseBase<FuncionarioResponse>.CreateSuccess(funcionarioResponse, 200)
                    .AddMessage("Mensagem de sucesso!");
            }
            catch (Exception)
            {
                return ResponseBase<FuncionarioResponse>.CreateError(500)
                        .AddMessage("Ocorreu um erro interno.");
            }
        }
    }
}