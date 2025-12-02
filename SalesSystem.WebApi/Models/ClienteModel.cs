using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Mvc.Models
{
    public class ClienteModel
    {
        [Key()]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string? Nome { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("CpfCnpj")]
        public string? CpfCnpj { get; set; }

        [Column("Logradouro")]
        public string? Logradouro { get; set; }

        [Column("Bairro")]
        public string? Bairro { get; set; }

        [Column("Uf")]
        public string? Uf { get; set; }

        [Column("Cep")]
        public string? Cep { get; set; }

        [Column("Cidade")]
        public string? Cidade { get; set; }

        [Column("Telefone")]
        public string? Telefone { get; set; }

    }
}
