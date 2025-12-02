using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.ObterClientePorId;

public sealed record ObterClientePorIdQuery(int Id) : IRequest<Result<ObterClientePorIdResponse>>;

public sealed record ObterClientePorIdResponse(
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
);
