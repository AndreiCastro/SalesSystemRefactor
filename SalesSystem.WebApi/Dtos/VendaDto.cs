namespace SalesSystem.WebApi.Dtos;

public class VendaDto
{
    public int Id { get; set; }

    public DateTime DataVenda { get; set; }

    public int QuantidadeProduto { get; set; }

    public decimal ValorTotal { get; set; }

    public string? Descricao { get; set; }

    public decimal? Desconto { get; set; }
}
