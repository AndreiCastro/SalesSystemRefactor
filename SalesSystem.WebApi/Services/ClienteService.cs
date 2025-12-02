using FluentResults;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Repositories;

namespace SalesSystem.WebApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<List<ClienteDto>>> ObterTodosClientesAsync(CancellationToken cancellationToken)
    {
        var output = await _clienteRepository.GetAllClientesAsync(cancellationToken);        
        return output;
    }

    public async Task<Result<ClienteDto>> ObterClientePorIdAsync(int idCliente, CancellationToken cancellationToken)
    {
        var output = await _clienteRepository.GetClientForIdAsync(idCliente, cancellationToken);
        return output;
    }
}
