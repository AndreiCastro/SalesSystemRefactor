using FluentResults;
using SalesSystem.Mvc.Models;
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
        try
        {
            var clientes = await _clienteRepository.GetAllClientesAsync(cancellationToken);
            var listClients = new List<ClienteDto>();
            foreach (var item in clientes)
            {
                listClients.Add(
                    new ClienteDto()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Email = item.Email,
                        CpfCnpj = item.CpfCnpj,
                        Logradouro = item.Logradouro,
                        Bairro = item.Bairro,
                        Uf = item.Uf,
                        Cep = item.Cep,
                        Cidade = item.Cidade,
                        Telefone = item.Telefone
                    });
            }
            return listClients;
        }
        catch (Exception)
        {
            throw;
        }        
    }

    public async Task<Result<ClienteDto>> ObterClientePorIdAsync(int idCliente, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = await _clienteRepository.GetClientForIdAsync(idCliente, cancellationToken);
            if (cliente is not null)
            {
                return new ClienteDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    CpfCnpj = cliente.CpfCnpj,
                    Logradouro = cliente.Logradouro,
                    Bairro = cliente.Bairro,
                    Uf = cliente.Uf,
                    Cep = cliente.Cep,
                    Cidade = cliente.Cidade,
                    Telefone = cliente.Telefone
                };
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
