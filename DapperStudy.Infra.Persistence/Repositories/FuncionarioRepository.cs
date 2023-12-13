using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Domain.Models;
using DapperStudy.Infra.Persistence.Repositories.Generico;

namespace DapperStudy.Infra.Persistence.Repositories
{
    public class FuncionarioRepository : RepositorioGenerico<FuncionarioResponse, int>, IFuncionarioRepository
    {
    }
}