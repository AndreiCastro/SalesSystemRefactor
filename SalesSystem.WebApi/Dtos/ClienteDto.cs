namespace SalesSystem.WebApi.Dtos;

public sealed class ClienteDto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? CpfCnpj { get; set; }

    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    public string? Uf { get; set; }

    public string? Cep { get; set; }

    public string? Cidade { get; set; }

    public string? Telefone { get; set; }
}
