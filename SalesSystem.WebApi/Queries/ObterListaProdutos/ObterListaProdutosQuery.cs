using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.ObterListaProdutos;

public sealed record ObterListaProdutosQuery() : IRequest<Result<List<ObterListaProdutosResponse>>>;

public sealed record ObterListaProdutosResponse(
    int Id,
    string? Nome,
    string? Descricao,
    decimal Preco,
    string? UnidadeMedida,
    int Quantidde,
    int Peso,
    DateTime DataValidade);
