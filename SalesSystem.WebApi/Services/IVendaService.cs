using FluentResults;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Services;

public interface IVendaService
{
    Task<Result<List<VendaDto>>> ObterTodasVendasAsync(CancellationToken cancellationToken);

    Task<Result<VendaDto>> ObterVendaPorId(int idVenda, CancellationToken cancellationToken);
}
