using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.Venda.ObterListaVendas;

public sealed class ObterListaVendasHandler : IRequestHandler<ObterListaVendasQuery, Result<List<ObterListaVendasResponse>>>
{
    private readonly IVendaService _vendaService;

    public ObterListaVendasHandler(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    public async Task<Result<List<ObterListaVendasResponse>>> Handle(ObterListaVendasQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listVendas = new List<ObterListaVendasResponse>();
            var result = await _vendaService.ObterTodasVendasAsync(cancellationToken);

            if (result.Value.Count <= 0)
                return Result.Fail("Nenhuma venda encontrada");

            foreach (var item in result.Value)
            {
                listVendas.Add(
                    new ObterListaVendasResponse(
                        item.Id,
                        item.DataVenda,
                        item.QuantidadeProduto,
                        item.ValorTotal,
                        item.Descricao,
                        item.Desconto));
            }
            return listVendas;
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error: {ex.Message}");
        }        
    }
}

