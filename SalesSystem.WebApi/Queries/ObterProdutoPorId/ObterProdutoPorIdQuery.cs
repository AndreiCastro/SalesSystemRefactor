using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.ObterProdutoPorId;

public sealed record ObterProdutoPorIdQuery(int Id) : IRequest<Result<ObterProdutoPorIdResponse>>;

public sealed record ObterProdutoPorIdResponse(
    int Id,
    string? Nome,
    string? Descricao,
    decimal Preco,
    int Quantidade,
    string? UnidadeMedida,
    int Peso,
    DateTime DataValidade
);
