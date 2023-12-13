using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperStudy.Domain.Models
{
    [Table("Funcionario")]
    public class FuncionarioModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Idade")]
        public int Idade { get; set; }

        [Column("Documento")]
        public string Documento { get; set; }

        [Column("Salario")]
        public decimal Salario { get; set; }
    }
}