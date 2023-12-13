using DapperStudy.Domain.Responses;
using DapperStudy.Domain.Responses.Base;

namespace DapperStudy.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        ResponseBase<FuncionarioResponse> BuscarFuncionarioPorId(int id);
    }
}