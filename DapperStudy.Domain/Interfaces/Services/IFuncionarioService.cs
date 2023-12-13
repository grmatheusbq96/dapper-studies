using DapperStudy.Domain.Models;

namespace DapperStudy.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        FuncionarioModel BuscarFuncionarioPorId(int id);
    }
}