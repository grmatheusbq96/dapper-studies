using DapperStudy.Domain.Models;

namespace DapperStudy.Domain.Responses
{
    public class FuncionarioResponse<T>
        where T : FuncionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Documento { get; set; }
        public decimal Salario { get; set; }

        public FuncionarioResponse(T model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Idade = model.Idade;
            Documento = model.Documento;
            Salario = model.Salario;
        }
    }
}