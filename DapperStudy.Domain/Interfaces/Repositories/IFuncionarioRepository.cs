using DapperStudy.Domain.Interfaces.Repositories.Generico;
using DapperStudy.Domain.Models;

namespace DapperStudy.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IRepositorioGenerico<FuncionarioModel, int>
    {
    }
}