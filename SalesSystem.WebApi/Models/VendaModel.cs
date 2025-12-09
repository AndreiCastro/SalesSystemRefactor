using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Mvc.Models;

public class VendaModel
{
    [Key()]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Data")]
    public DateTime Data { get; set; }

    [Column("Total")]
    public decimal Total { get; set; }

    [Column("Quantidade_Produto")]
    public int QuantidadeProduto { get; set; }

    [ForeignKey("Cliente")]
    [Column("IdCliente")]
    public int IdCliente { get; set; }

    public virtual ClienteModel Cliente { get; set; }

    [ForeignKey("Produto")]
    [Column("IdProduto")]
    public int IdProduto { get; set; }

    public virtual ProdutoModel Produto { get; set; }

    [ForeignKey("Vendedor")]
    [Column("IdVendedor")]
    public int IdVendedor { get; set; }

    //public virtual VendedorModel Vendedor { get; set; }
}
