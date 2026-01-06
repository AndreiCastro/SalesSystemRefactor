using SalesSystem.Mvc.Models;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Repositories;

public interface IClienteRepository
{
    Task<List<ClienteModel>> GetAllClientesAsync(CancellationToken cancellationToken);

    Task<ClienteModel> GetClientForIdAsync(int idCliente, CancellationToken cancellationToken);
}
