namespace SalesSystem.WebApi.Dtos;

public class ProdutoDto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public string? UnidadeMedida { get; set; }

    public int Quantidade { get; set; }

    public int Peso { get; set; }

    public DateTime DataValidade { get; set; }
}
