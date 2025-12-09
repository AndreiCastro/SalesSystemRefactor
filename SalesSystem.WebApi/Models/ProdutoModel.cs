using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Mvc.Models;

public class ProdutoModel
{
    [Key()]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Nome")]
    public string? Nome { get; set; }

    [Column("Descricao")]
    public string? Descricao { get; set; }

    [Column("Preco")]
    public decimal Preco { get; set; }

    [Column("Quantidade")]
    public int Quantidade { get; set; }

    [Column("UnidadeMedida")]
    public string? UnidadeMedida { get; set; }

    [Column("Peso")]
    public int Peso { get; set; }

    [Column("DataValidade")]
    public DateTime DataValidade { get; set; }
}
