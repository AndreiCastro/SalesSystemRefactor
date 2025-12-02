using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.ObterListaClientes;

public sealed class ObterListaClientesQueryHandler : IRequestHandler<ObterListaClientesQuery, Result<List<ObterListaClientesResponse>>>
{
    private readonly IClienteService _clienteService;

    public ObterListaClientesQueryHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<Result<List<ObterListaClientesResponse>>> Handle(ObterListaClientesQuery request, CancellationToken cancellation)
    {
        try
        {
            var listClient = new List<ObterListaClientesResponse>();
            var result = await _clienteService.ObterTodosClientesAsync(cancellation);

            if (result.Value.Count <= 0)
                return Result.Fail("Nenhum cliente encontrado.");

            foreach (var item in result.Value)
            {
                listClient.Add(
                    new ObterListaClientesResponse(
                        item.Id,
                        item.Nome,
                        item.Email,
                        item.CpfCnpj,
                        item.Logradouro,
                        item.Bairro,
                        item.Uf,
                        item.Cep,
                        item.Cidade,
                        item.Telefone
                    ));
            }
            return Result.Ok(listClient);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }        
    }
}
