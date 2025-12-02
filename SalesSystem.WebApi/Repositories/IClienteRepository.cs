using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Repositories;

public interface IClienteRepository
{
    Task<List<ClienteDto>> GetAllClientesAsync(CancellationToken cancellationToken);

    Task<ClienteDto> GetClientForIdAsync(int idCliente, CancellationToken cancellationToken);
}
