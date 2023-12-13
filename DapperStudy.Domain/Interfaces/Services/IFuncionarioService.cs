using DapperStudy.Domain.Models;
using DapperStudy.Domain.Responses;

namespace DapperStudy.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        FuncionarioResponse<FuncionarioModel> BuscarFuncionarioPorId(int id);
    }
}