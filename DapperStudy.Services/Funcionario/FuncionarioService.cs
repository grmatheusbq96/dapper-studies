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
                    return ResponseBase<FuncionarioResponse>.CreateBadRequest();

                var funcionarioResponse = new FuncionarioResponse(funcionarioModel);

                return ResponseBase<FuncionarioResponse>.CreateSuccess(funcionarioResponse);
            }
            catch
            {
                return ResponseBase<FuncionarioResponse>.CreateInternalServerError();
            }
        }
    }
}