using FluentResults;
using MediatR;

namespace SalesSystem.WebApi.Queries.Venda.ObterVendaPorId;

public sealed record ObterVendaPorIdQuery(int Id) : IRequest<Result<ObterVendaPorIdResponse>>;

public sealed record ObterVendaPorIdResponse(
    int Id,
    DateTime DataVenda,
    int QuantidadeProduto,
    decimal ValorTotal,
    string? Descricao,
    decimal? Desconto
    );

