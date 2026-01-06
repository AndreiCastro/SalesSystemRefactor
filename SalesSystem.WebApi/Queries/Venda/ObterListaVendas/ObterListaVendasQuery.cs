using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.Venda.ObterListaVendas;

public sealed record ObterListaVendasQuery() : IRequest<Result<List<ObterListaVendasResponse>>>;

public sealed record ObterListaVendasResponse(
    int Id,
    DateTime DataVenda,
    int QuantidadeProduto,
    decimal ValorTotal,
    string? Descricao,
    decimal? Desconto);

