using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Domain.Models;
using DapperStudy.Infra.Persistence.Repositories.Generico;
using Microsoft.Extensions.Configuration;

namespace DapperStudy.Infra.Persistence.Repositories
{
    public class FuncionarioRepository : RepositorioGenerico<FuncionarioModel, int>, IFuncionarioRepository
    {
        public FuncionarioRepository(IConfiguration configuration) : base(configuration, "DapperDb")
        {
        }
    }
}