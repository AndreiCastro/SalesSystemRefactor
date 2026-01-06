using SalesSystem.Mvc.Models;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Repositories;

public interface IVendaRepository
{
    Task<List<VendaModel>> GetAllVendasAsync(CancellationToken cancellationToken);

    Task<VendaModel> GetVendaByIdAsync(int idVenda, CancellationToken cancellationToken);
}
