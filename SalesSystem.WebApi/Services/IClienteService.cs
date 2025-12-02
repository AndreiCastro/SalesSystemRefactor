using FluentResults;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Services;

public interface IClienteService
{
    Task<Result<List<ClienteDto>>> ObterTodosClientesAsync(CancellationToken cancellationToken);

    Task<Result<ClienteDto>> ObterClientePorIdAsync(int idCliente, CancellationToken cancellationToken);
}
