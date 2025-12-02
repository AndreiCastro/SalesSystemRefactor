using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.ObterListaClientes;

public sealed record ObterListaClientesQuery() : IRequest<Result<List<ObterListaClientesResponse>>>;

public sealed record ObterListaClientesResponse(
    int Id,
    string? Nome,
    string? Email,
    string? CpfCnpj,
    string? Logradouro,
    string? Bairro,
    string? Uf,
    string? Cep,
    string? Cidade,
    string? Telefone

    //[NotMapped]
    //string ComparaEmail
);
