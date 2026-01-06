using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.Venda.ObterVendaPorId;

public sealed class ObterVendaPorIdHandler : IRequestHandler<ObterVendaPorIdQuery, Result<ObterVendaPorIdResponse>>
{
    private readonly IVendaService _service;

    public ObterVendaPorIdHandler(IVendaService service)
    {
        _service = service;
    }

    public async Task<Result<ObterVendaPorIdResponse>> Handle(ObterVendaPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _service.ObterVendaPorId(request.Id, cancellationToken);            
            if (result.Value is null)
                return Result.Fail("Nenhuma venda encontrada.");

            var venda = new ObterVendaPorIdResponse(
                        result.Value.Id,
                        result.Value.DataVenda,
                        result.Value.QuantidadeProduto,
                        result.Value.ValorTotal,
                        result.Value.Descricao,
                        result.Value.Desconto);

            return Result.Ok(venda);
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error: {ex.Message}");
        }
    }
}
